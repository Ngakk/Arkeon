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
namespace ArkeonBattle
{
    public class ArkeonInBattle : MonoBehaviour
    {
        public ArkeonInstance myInstance;
        [HideInInspector]
        public ArkeonAnimEvents animEvents;
        public bool isAlly;
        public bool showOnStart = true;

        private Animator anim;

        public ArkeonStats inBattleModifiers = new ArkeonStats();

        private void Start()
        {
            anim = GetComponent<Animator>();
            if (showOnStart)
                AnimShow();

            animEvents = GetComponent<ArkeonAnimEvents>();
            if (animEvents == null)
                animEvents = gameObject.AddComponent<ArkeonAnimEvents>();

            inBattleModifiers = new ArkeonStats();
        }
        
        public ArkeonStats GetStats()
        {
            return inBattleModifiers + myInstance.stats;
        }

        //Combate
        public void GoForward()
        {
            AnimGoForward();
        }

        public void StepBack()
        {
            AnimGoBack();
        }

        public void AttackSet(int _attack)
        {
            ManagerStaticBattle.battleManager.SetAttack(this, myInstance.attacks[_attack], isAlly);
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
        public void AnimAttack(AttackAnimations _type)
        {
            Debug.Log("Anim attack type: " + (int)_type);
            anim.SetInteger("Action", (int)_type);
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
