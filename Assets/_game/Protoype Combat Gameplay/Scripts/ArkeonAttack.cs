using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public enum ArkeonTypes : int
    {
        LIGHT,
        DARK,
        NATURE
    }

    public class ArkeonAttackStats
    {
        public string Name;
        public string Description;
        public int Power;
        public int Cost;
        public int Accuaracy;
        public ArkeonTypes Type;
        public bool IsPhysical;
    }

    public class ArkeonAttackEffect
    {
        /// <summary>
        /// Que hacer antes del golpe.
        /// </summary>
        public virtual void PreHit()
        {

        }

        /// <summary>
        /// Que hacer en el momento del golpe.
        /// </summary>
        public virtual void OnHit()
        {

        }

        /// <summary>
        /// Que hacer despues de el golpe. Por ejemplo, un debuff.
        /// </summary>
        public virtual void PostHit()
        {

        }
    }

    public static class ArkeonBattleUtility
    {
        /// <summary>
        /// Regresa el daño que se va hacer usando el los stats del los arkeons atacante y defensor.
        /// </summary>
        /// <param name="_atk"></param>
        /// <param name="_pwr"></param>
        /// <param name="_def"></param>
        /// <returns></returns>
        private static int CalculateDamage(int _atk, int _pwr, int _def)
        {
            return (int)Mathf.Round((_atk * _pwr) / _def);
        }
    }


    [CreateAssetMenu]
    public class ArkeonAttack : ScriptableObject
    {
        //ArkeonAttackStats Stats;

        public string Name;
        public string Description;
        public int Power;
        public int Cost;
        public int Accuaracy;
        public ArkeonTypes Type;
        public bool IsPhysical;

        public int AttackEffectId = 0;
    }
}