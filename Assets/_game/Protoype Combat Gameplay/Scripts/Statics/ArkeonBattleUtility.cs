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
        public static float CalculateBaseDamage(int _lvl, int _atk, int _pwr, int _def)
        {
            float lvlMod = (0.4f * _lvl);
            float statMod = ((float)_atk / (float)_def);

            return (lvlMod * (float)_pwr * statMod) / 25f;
        }

        /// <summary>
        /// Calcula el resultado de una pelea utilizando el atacante, el ataque y el defensor.
        /// </summary>
        /// <param name="_atkStat"></param>
        /// <param name="_arkAtk"></param>
        /// <param name="_defStat"></param>
        /// <returns></returns>
        public static ArkeonCombatResult GetCombatResult(ArkeonStats _attacker, ArkeonAttack _arkAtk, ArkeonStats _defender)
        {
            //TODO: calcular bien que pdo
            ArkeonAttack.HitTypes hitType;
            int damageDone = 0;

            float hitChance = _arkAtk.accuaracy;
            float rng = Random.Range(0.0f, 100.0f);

            if(hitChance > rng)
            {
                hitType = ArkeonAttack.HitTypes.HIT;

                Debug.Log("Combat result Defender: " + _defender + ", type: " + _defender.type);
                float modifier = MatchupMultiplier(_arkAtk.type, _defender.type) /*TODO: crit*/;

                damageDone = Mathf.FloorToInt((CalculateBaseDamage(_attacker.lvl, _attacker.atk, _arkAtk.power, _defender.def) * modifier));
                Debug.Log("Damage calculated: " + damageDone);
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
            Debug.Log(_type2);

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