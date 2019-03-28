using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public class ArkeonAttackEffectList : MonoBehaviour
    {
        private void Awake()
        {
            ManagerStatic.arkeonAttackEffectList = this;
        }

        public static Type[] AttackEffects = 
        {
            typeof(ArkeonAttackEffect)
        };
    }
}
