using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkeonBattle
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

                float modifier = MatchupMultiplier(_arkAtk.type, _defender.myInstance.stats.type) /*TODO: crit*/;

                float lvlMod = (2f * _attacker.myInstance.stats.lvl) / 5f;
                float statMod = ((float)_attacker.myInstance.stats.atk / (float)_defender.myInstance.stats.def);

                damageDone = Mathf.FloorToInt(((lvlMod * (float)_arkAtk.power * statMod) /25f) * modifier);
                Debug.Log("Damage calculated: " + damageDone);
                Debug.Log("lvlMod: " + lvlMod);
                Debug.Log("statMod: " + statMod);


            }
            else
            {
                hitType = ArkeonAttack.HitTypes.MISS;
                damageDone = 0;
            }

            return new ArkeonCombatResult(hitType, damageDone);
        }

        public static float MatchupMultiplier(ArkeonElement _type1, ArkeonElement _type2)
        {
            if(_type2.defeatedBy.Contains(_type1))
            {
                return 2f;
            }

            if(_type1.defeatedBy.Contains(_type2))
            {
                return 0.5f;
            }

            return 1f;
        }

    }
}