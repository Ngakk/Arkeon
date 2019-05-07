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

    [CreateAssetMenu]
    public class ArkeonAttack : ScriptableObject
    {
        public string Name;
        public string Description;
        public int Power;
        public int Cost;
        public int Accuaracy;
        public ArkeonTypes Type;
        public bool IsPhysical;

        //TODO: 
        // - hacer mas funciones para que se hagan cosas tanto a un jugador/familiar como a un arkeon
        // - hacer clase que guarde stats de hp, mana etc para jugador/familiar
        // - llamar las funciones de arkeon atack desde battle manager en sus respectivas funciones (sin importar si debe o no)

        /// <summary>
        /// Que hacer antes del golpe, si se cambian stats.
        /// </summary>
        public virtual void PreHit(ArkeonStats _attacker, ArkeonStats _target)
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