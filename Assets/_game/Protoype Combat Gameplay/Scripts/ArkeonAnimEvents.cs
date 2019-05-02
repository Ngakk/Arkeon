using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class ArkeonAnimEvents : MonoBehaviour
    {
        public Animator Anim;

        private void Start()
        {
            Anim = GetComponent<Animator>();
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
        public void OnAttackApex()
        {
            
        }
    }
}