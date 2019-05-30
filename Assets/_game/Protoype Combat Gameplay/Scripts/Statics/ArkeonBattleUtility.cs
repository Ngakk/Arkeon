using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    public static class ArkeonBattleUtility
    {
        //Struct para transportar resultados de un combate o ataque
        public struct ArkeonCombatResult
        {
            public ArkeonCombatResult(ArkeonAttack.HitTypes _hitType, int _damageDone)
            {
                hitType = _hitType;
                damageDone = _damageDone;
            }

            public ArkeonAttack.HitTypes hitType;   //Nos dice si el ataque fue hit, miss o crit
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
        public static ArkeonCombatResult GetCombatResult(ArkeonInBattle _attacker, ArkeonAttack _arkAtk, ArkeonInBattle _defender)
        {
            //TODO: calcular bien que pdo
            ArkeonAttack.HitTypes hitType;
            int damageDone = 0;

            float hitChance = _arkAtk.accuaracy;
            float rng = Random.Range(0.0f, 100.0f);

            if(hitChance > rng)
            {
                hitType = ArkeonAttack.HitTypes.HIT;

                float modifier = MatchupMultiplier(_arkAtk.type, _defender.spirit.stats.Type) /*TODO: crit*/;

                damageDone = Mathf.FloorToInt(((((2f*_attacker.spirit.stats.LVL)/5f) * _arkAtk.power * (_attacker.spirit.stats.Atk/_defender.spirit.stats.Def))/50f) * modifier);

            }
            else
            {
                hitType = ArkeonAttack.HitTypes.MISS;
                damageDone = 0;
            }

            return new ArkeonCombatResult(hitType, damageDone);
        }

        public static int MatchupMultiplier(ArkeonTypes _type1, ArkeonTypes _type2)
        {
            switch(_type1)
            {
                case ArkeonTypes.DARK:
                    break;
                case ArkeonTypes.LIGHT:
                    break;
                case ArkeonTypes.WIND:
                case ArkeonTypes.WATER:
                case ArkeonTypes.EARTH:
                case ArkeonTypes.FIRE:
                    break;
            }

            return 1;
        }

    }
}