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

    public enum AttackTypes : int
    {
        PHYSICAL,
        SPECIAL
    }

    [CreateAssetMenu]
    public class ArkeonAttack : ScriptableObject
    {
        public string myName;
        public string description;
        public int power;
        public int Cost;
        public int accuaracy;
        public ArkeonTypes type;
        public bool isPhysical;

        //TODO: pensar en sistema de pre, on y post hit, ademas de cosas al inicio de los turnos y la madre.

        /// <summary>
        /// Que hacer antes del golpe, si se cambian stats.
        /// </summary>
        public virtual void PreHit(List<ArkeonStats> _attacker, ArkeonStats _target)
        {

        }

        /// <summary>
        /// Que hacer antes del golpe, si se cambian stats.
        /// </summary>
        public virtual void PreHit(ArkeonStats _attacker, PlayerCharacterBattle _target)
        {

        }

        /// <summary>
        /// Que hacer en el momento del golpe.
        /// </summary>
        public virtual void OnHit(ArkeonStats _attacker, ArkeonStats _target)
        {

        }

        /// <summary>
        /// Que hacer en el momento del golpe.
        /// </summary>
        public virtual void OnHit(ArkeonStats _attacker, PlayerCharacterBattle _target)
        {

        }

        /// <summary>
        /// Que hacer despues de el golpe. Por ejemplo, un debuff.
        /// </summary>
        public virtual void PostHit(ArkeonStats _attacker, ArkeonStats _target)
        {

        }

        /// <summary>
        /// Que hacer despues de el golpe. Por ejemplo, un debuff.
        /// </summary>
        public virtual void PostHit(ArkeonStats _attacker, PlayerCharacterBattle _target)
        {

        }
    }

    

}