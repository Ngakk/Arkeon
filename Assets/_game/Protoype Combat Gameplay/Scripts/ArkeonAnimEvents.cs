using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkeonBattle
{
    public class ArkeonAnimEvents : MonoBehaviour
    {
        public Animator anim;

        public Action onAttackHitAction;
        //public Action onAttackEndAction;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        //Metodos para ser llamados por eventos de animacion

        /// <summary>
        /// Es llamado cuando un arkeon termina de aparecer
        /// </summary>
        public void OnShowEnd()
        {
            //TODO: notify battle manager that to show ended
            
        }

        /// <summary>
        /// Es llamado justo en el golpe de la animacion de ataque
        /// </summary>
        public void OnAttackHit()
        {
            onAttackHitAction.Invoke();
        }

        public void OnAttackEnd()
        {
            ManagerStaticBattle.battleManager.OnAttackEnd();
        }
    }
}