using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public static class ArkeonBattleUtility
    {
        public enum HitLevel
        {
            MISS,
            HIT,
            CRIT
        }

        //Struct para transportar resultados de un combate o ataque
        public struct ArkeonCombatResult
        {
            public ArkeonCombatResult(HitLevel _hitLevel, int _damageDone)
            {
                hitLevel = _hitLevel;
                damageDone = _damageDone;
            }

            public HitLevel hitLevel;   //Nos dice si el ataque fue hit, miss o crit
            public int damageDone;      //Cuanto daño fue hecho, ya incluye multiplicador de crit y se vuelve 0 si fue miss.
        }

        /// <summary>
        /// Regresa el daño que se va hacer usando el los stats del los arkeons atacante, defensor y el poder del ataque.
        /// </summary>
        /// <param name="_atk"></param>
        /// <param name="_pwr"></param>
        /// <param name="_def"></param>
        /// <returns></returns>
        public static int CalculateDamage(int _atk, int _pwr, int _def)
        {
            return (int)Mathf.Round((_atk * _pwr) / _def);
        }

        /// <summary>
        /// Calcula el resultado de una pelea utilizando el atacante, el ataque y el defensor.
        /// </summary>
        /// <param name="_atkStat"></param>
        /// <param name="_arkAtk"></param>
        /// <param name="_defStat"></param>
        /// <returns></returns>
        public static ArkeonCombatResult GetCombatResult(ArkeonStats _atkStat, ArkeonAttack _arkAtk, ArkeonStats _defStat)
        {
            //TODO: calcular bien que pdo
            return new ArkeonCombatResult(HitLevel.HIT, 10);
        }
    }
}