﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ArkeonBattle
{
    public class BattleManager : MonoBehaviour
    {
        public enum State
        {
            NOTHING,
            ATTACK_SET,
            ITEM_SET,
            DEFENDER_SET,
            BATTLING
        }

        [Header("Setup en editor")]
        public ArenaPointReference arenaPointReference;
        [Header("Setup Al iniciar escena")]
        public PlayerCharacterBattle playerCharacter;
        public PlayerCharacterBattle enemyCharacter;
        public GameObject singleEnemy;
        public bool isSingleEnemy = true;
        public State state;

        private ArkeonInBattle attacker;
        private ArkeonInBattle defender;
        private PlayerCharacterBattle characterDefender;
        private ArkeonAttack attack;
        private int itemIdOnInventory;
        private bool anArkeonIsShield = false;
        private bool isAllyAttacking = true;

        //IMPORTANTE: Un id de un arkeon es la posicion del arkeon en su respectivo equipo, empezando por 0. Los equipos se constituyen de todas los arkeons que el jugador trae cargando

        private void Awake()
        {
            ManagerStaticBattle.battleManager = this;
        }

        private void Start()
        {

        }

        private void ResetVariables()
        {
            state = State.NOTHING;
            attack = null;
            attacker = null;
            defender = null;
            anArkeonIsShield = false;
        }

        // ------------------ Batalla ------------------
        public void SetAttack(ArkeonInBattle _attacker, ArkeonAttack _attack, bool _isAlly)
        {
            if (state == State.NOTHING)
            {
                state = State.ATTACK_SET;
                attacker = _attacker;
                attack = _attack;
                isAllyAttacking = _isAlly;
            }
        }

        public bool SetDefender(ArkeonInBattle _defender)
        {
            if (_defender == null)
            {
                return false;
            }

            if (state == State.ATTACK_SET)
            {
                state = State.DEFENDER_SET;

                anArkeonIsShield = true;
                defender = _defender;
                StartBattleAvA();
                return true;
            }

            if(state == State.ITEM_SET)
            {
                state = State.DEFENDER_SET;

                defender = _defender;
                StartUseItem();
            }

            return false;
        }

        public bool SetCharacterDefender(PlayerCharacterBattle _defender)
        {
            if (_defender == null)
            {
                return false;
            }

            if (state == State.ATTACK_SET)
            {
                characterDefender = _defender;
                anArkeonIsShield = false;
                StartBattleAvP();
                return true;
            }
            return false;
            
        }

        public void StartBattleAvA()
        {
            state = State.BATTLING;

            attack.PreBattle(attacker, defender);
            attacker.AttackStart(attack, defender, OnHitAvA);
        }

        public void StartBattleAvP()
        {
            state = State.BATTLING;

            attack.PreBattle(attacker, characterDefender);
            attacker.AttackStart(attack, characterDefender, OnHitAvP);
        }

        public void SetItemToUse(int _itemId, PlayerCharacterBattle _user)
        {
            if (state != State.NOTHING)
                return;

            itemIdOnInventory = _itemId;
            characterDefender = _user;

            state = State.ITEM_SET;
        }

        public void StartUseItem()
        {
            state = State.BATTLING;
            characterDefender.inventory[itemIdOnInventory].item.Use(characterDefender, defender.myInstance, OnItemEffect);
            characterDefender.inventory.Consume(itemIdOnInventory);
        }

        //Callback on hit
        public void OnHitAvA(ArkeonAttack.HitTypes _hit)
        {
            if (state != State.BATTLING)
                return;

            switch (_hit)
            {
                case ArkeonAttack.HitTypes.HIT:
                case ArkeonAttack.HitTypes.CRIT:
                    defender.Squeal();
                    break;
                case ArkeonAttack.HitTypes.MISS:
                    defender.Dodge();
                    break;
                case ArkeonAttack.HitTypes.NO_DAMAGE:
                    defender.Laugh();
                    break;
                default:
                    break;
            }
        }

        public void OnHitAvP(ArkeonAttack.HitTypes _hit)
        {
            if (state != State.BATTLING)
                return;

            switch(_hit)
            {
                case ArkeonAttack.HitTypes.HIT:
                case ArkeonAttack.HitTypes.CRIT:
                    characterDefender.Squeal();
                    break;
                case ArkeonAttack.HitTypes.MISS:
                    characterDefender.Dodge();
                    break;
                case ArkeonAttack.HitTypes.NO_DAMAGE:
                    characterDefender.Laugh();
                    break;
                default:
                    break;
            }
        }

        //Callback on item
        public void OnItemEffect()
        {
            //DO some particle effects or something

            defender = null;
            characterDefender = null;
            itemIdOnInventory = -1;
            state = State.NOTHING;
        }

        //Respuesta a animaciones
        public void OnHit()
        {

        }

        public void OnAttackEnd()
        {
            if(anArkeonIsShield) { OnAttackEndAvA(); }
            else { OnAttackEndAvP(); }
        }

        public void OnAttackEndAvA()
        {
            if (state != State.BATTLING)
                return;

            attack.PostBattle(attacker, defender, OnPostBattleEnd);

            //TODO: checar si ya se ganó o perdió
        }

        public void OnAttackEndAvP()
        {
            if (state != State.BATTLING)
                return;

            attack.PostBattle(attacker, characterDefender, OnPostBattleEnd);
        }

        public void OnPostBattleEnd()
        {
            Debug.Log("On post battle end");
            state = State.NOTHING;
            attack = null;
            attacker = null;
            defender = null;
            anArkeonIsShield = false;

            for(int i = playerCharacter.arkeonsOut.Count-1; i >= 0; i--)
            {
                playerCharacter.arkeonsOut[i].isOnFront = false;
                if(playerCharacter.arkeonsOut[i].arkeon.myInstance.currentHp <= 0)
                {
                    Debug.Log("Arkeon is dead");
                    playerCharacter.arkeonsOut[i].arkeon.Die();
                    playerCharacter.arkeonsOut.RemoveAt(i);
                }
            }

            for (int i = enemyCharacter.arkeonsOut.Count - 1; i >= 0; i--)
            {
                enemyCharacter.arkeonsOut[i].isOnFront = false;
                if (enemyCharacter.arkeonsOut[i].arkeon.myInstance.currentHp <= 0)
                {
                    Debug.Log("Arkeon is dead");
                    enemyCharacter.arkeonsOut[i].arkeon.Die();
                    enemyCharacter.arkeonsOut.RemoveAt(i);
                }
            }
        }


        public void ChangeTurns()
        {
            if (isAllyAttacking)
            {
                enemyCharacter.OnTurnStart();
                isAllyAttacking = false;
            }
            else{
                playerCharacter.OnTurnStart();
                isAllyAttacking = false;
            }
            //TODO: hacer que se hagan cosas al inicio del turno.
        }
    }
}
