using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ArkeonStats:
 *  - Guardar stats
 *  
 * ArkeonSpirit:
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
        public ArkeonSpirit Spirit;

        public bool ShowOnStart = true;

        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
            if (ShowOnStart)
                AnimShow();
        }


        //Combate
        public void Attack(int _attack)
        {

        }

        // ---------------- Animations ----------------
        public void AnimShow()
        {
            anim.SetTrigger("Show");
        }
        public void AnimHide()
        {

        }
        public void AnimGoForward()
        {
            anim.SetTrigger("GoForward");
        }
        public void AnimBackward()
        {

        }
        public void AnimAttack(AttackTypes _type)
        {

        }
        public void AnimGetHit()
        {

        }
        public void AnimDie()
        {

        }
    }
}
