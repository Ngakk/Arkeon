using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkeonBattle
{
    public class CharacterAnimEvents : MonoBehaviour
    {
        public Animator anim;

        public Action animationApex; 

        public void OnAnimationApex()
        {
            animationApex.Invoke();
        }
    }
}