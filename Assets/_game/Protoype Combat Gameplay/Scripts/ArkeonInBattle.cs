using System;
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

        public bool isAlly;
        public bool showOnStart = true;

        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
            if (showOnStart)
                AnimShow();
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

        public void AttackStart(bool isPhysical, Action<ArkeonAttack.HitTypes> _onHitCallback)
        {
            AnimAttack(isPhysical ? AttackTypes.PHYSICAL : AttackTypes.SPECIAL);        //TODO NS: cambiar cosas para que ArkeonAttack se encargue de las animaciones con callbacks a este script y a battle manages
        }

        public void Squeal()
        {

        }

        public void Dodge()
        {

        }

        public void Laugh()
        {

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
        private void AnimAttack(AttackTypes _type)
        {
            anim.SetTrigger("Attack");
        }
        private void AnimGetHit()
        {

        }
        private void AnimDie()
        {

        }
    }
}
