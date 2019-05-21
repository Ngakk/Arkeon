using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Hacr que el ataque haga daño y las animaciones de daño y todo eso

/* Responsibilidades de cada entidad
 * 
 * Arkeon:
 *  - Hacer Animaciones
 *  - Atacar
 *  - Tener Stats
 *  - Tener ataques
 *  
 * Jugador:
 *  - Tener arkeons
 *  - Comandar arkeons
 *  - Invocar arkeons
 *  - usar al familiar
 *  - Tiene stats
 *  
 * Familiar:
 *  - Tiene stats
 *  - Invocar arkeons
 *  - Atacar
 *  - Tiene ataques 
 *  - Hacer animaciones
 *  - Tiene efectos pasivos
 *  
 * BattleManager:
 *  - Decirle a un personaje que hacer
 *  - Esperar eventos de animaciones
 *  - Setearle referencias a los que hacen las cosas
 *  
 * BattleTurnManager:
 *  - Saber en que estado esta
 *  - Cambiar de turnos
 *  - Empezar y terminar peleas
 *  - Decirle al controller si si puede hacer lo que quiere
 *  - Preguntarlo al BattleManager si se puede hacer lo que el controller quiere
 * 
 * Controller:
 *  - Pedirle al turn manager que haga cosas
 *  - decirle al jugador que onda
 * 
 */

namespace Mangos
{
    public class BattleManager : MonoBehaviour
    {
        public enum State
        {
            NOTHING,
            ATTACK_SET,
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
        private ArkeonAttack attack;
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

        private void Update()
        {
            /*//Testing
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                InvokeArkeonRequest(true, 0);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                InvokeArkeonRequest(true, 1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                InvokeArkeonRequest(true, 2);
            }

            if(Input.GetKeyDown(KeyCode.Q))
            {
                CallForthArkeonRequest(true, 0);
            }

            if(Input.GetKeyDown(KeyCode.W))
            {
                ArkeonSetAttackRequest(true, 0, 0);
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                
            }*/
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
            if(state == State.NOTHING)
            {
                state = State.ATTACK_SET;
                attacker = _attacker;
                attack = _attack;
                isAllyAttacking = _isAlly;
            }
        }

        public void SetDefender(ArkeonInBattle _defender)
        {
            if(state == State.ATTACK_SET)
            {
                state = State.DEFENDER_SET;

                if (_defender == null)
                {
                    anArkeonIsShield = false;
                    StartBattleAvP();
                }
                else
                {

                    anArkeonIsShield = true;
                    defender = _defender;
                    StartBattleAvA();
                }
            }
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

            attack.PreBattle(attacker, defender);
            attacker.AttackStart(attack, defender, OnHitAvP);
        }

        //Callback on hit
        public void OnHitAvA(ArkeonAttack.HitTypes _hit, int _dmg)
        {
            if (state != State.BATTLING)
                return;

            switch (_hit)
            {
                case ArkeonAttack.HitTypes.HIT:
                case ArkeonAttack.HitTypes.CRIT:
                    defender.Squeal(_dmg);
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

        public void OnHitAvP(ArkeonAttack.HitTypes _hit, int _dmg)
        {

        }

        //Respuesta a animaciones
        public void OnHit()
        {

        }

        public void OnAttackEndAvA()
        {
            if (state != State.BATTLING)
                return;

            attack.PostBattle(attacker, defender, OnPostBattleEnd);

            //TODO: checar si ya se ganó o perdió
        }

        public void OnPostBattleEnd()
        {
            state = State.NOTHING;
            attack = null;
            attacker = null;
            defender = null;
            anArkeonIsShield = false;

            for(int i = playerCharacter.arkeonsOut.Count-1; i >= 0; i--)
            {
                playerCharacter.arkeonsOut[i].isOnFront = false;
                if(playerCharacter.arkeonsOut[i].arkeon.HP <= 0)
                {
                    Debug.Log("Arkeon is dead");
                    playerCharacter.arkeonsOut[i].arkeon.Die();
                    playerCharacter.arkeonsOut.RemoveAt(i);
                }
            }
        }
    }
}
