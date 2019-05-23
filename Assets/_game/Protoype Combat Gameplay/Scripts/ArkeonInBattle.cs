﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ArkeonStats:
 *  - Guardar stats
 *  
 * Arkeonspirit:
 *  - Una instancia de arkeon en asset
 * 
 * ArkeonInBattle:
 *  - Hacer Animaciones
 *  - Atacar
 *  - Tener Stats
 *  - Tener ataques
 */
namespace Mangos
{
    public class ArkeonInBattle : MonoBehaviour
    {
        public ArkeonSpirit spirit;
        [HideInInspector]
        public ArkeonAnimEvents animEvents;
        public bool isAlly;
        public bool showOnStart = true;

        private Animator anim;

        public int HP;
        public int AtkMod;
        public int DefMod;

        private void Start()
        {
            anim = GetComponent<Animator>();
            if (showOnStart)
                AnimShow();

            animEvents = GetComponent<ArkeonAnimEvents>();
            if (animEvents == null)
                animEvents = gameObject.AddComponent<ArkeonAnimEvents>();

            //Cambiar despues, a que agarre hp y no maxhp
            HP = spirit.stats.MaxHP;
            spirit.stats.HP = HP;
        }


        //Combate
        public void GoForward()
        {
            AnimGoForward();
        }

        public void AttackSet(int _attack)
        {
            ManagerStaticBattle.battleManager.SetAttack(this, spirit.attacks[_attack], isAlly);
        }

        public void AttackStart(ArkeonAttack _attack, ArkeonInBattle _target, Action<ArkeonAttack.HitTypes> _onHitCallback)
        {
            _attack.OnBattle(this, _target, _onHitCallback);
        }

        public void AttackStart(ArkeonAttack _attack, PlayerCharacterBattle _target, Action<ArkeonAttack.HitTypes> _onHitCallback)
        {
            _attack.OnBattle(this, _target, _onHitCallback);
        }

        public void Squeal()
        {
            AnimGetHit();

        }
        
        public void Dodge()
        {

        }

        public void Laugh()
        {

        }

        public void Die()
        {
            AnimDie();
            Invoke("SelfDestroy", 5.0f);
            //spirit.stats.HP = 0;
        }

        // ---------------- Animations ----------------
        private void AnimShow()
        {
            anim.SetTrigger("Show");
        }
        private void AnimHide()
        {

        }
        private void AnimGoForward()
        {
            anim.SetTrigger("GoForward");
        }
        private void AnimBackward()
        {

        }
        public void AnimAttack(AttackAnimations _type)
        {
            anim.SetTrigger("Attack");
        }
        public void AnimGoBack()
        {
            anim.SetTrigger("GoBack");
        }
        private void AnimGetHit()
        {
            anim.SetTrigger("Squirm");
        }
        private void AnimDie()
        {
            anim.SetTrigger("Die");
        }

        private void SelfDestroy()
        {
            Destroy(gameObject);
        }
    }
}
