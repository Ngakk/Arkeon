﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GestureRecognizer;

namespace ArkeonBattle
{

    public enum AttackTypes : int
    {
        PHYSICAL,
        SPECIAL
    }

    public enum AttackAnimations : int
    {
        NOTHING = 0,
        MELEE_ATTACK = 1,
        RANGED_ATTACK = 2,
        HEAL = 3,
    }

    public enum AttackTargets : int
    {
        SELF,
        NON_TARGETED_ENEMY,
        TARGETED_ENEMY,
        TARGETED_ALLY,
        TARGETED_ALLY_OR_ENEMY
    }

    //[CreateAssetMenu(fileName = "BaseAttack", menuName = "Arkeon Creature/Arkeon Attacks/Base Attack", order = 3)]
    public class ArkeonAttack : ScriptableObject
    {        
        public GesturePattern pattern;
        public string myName;
        public string description;
        public int power;
        public int cost;
        public int accuaracy;
        public ArkeonElement type;
        public bool isPhysical;
        public AttackTargets targetType;
        public AttackAnimations animation;

        [Header("Deprecated")]
        public int db_id;
        public Sprite glyph;

        /// <summary>
        /// Que hacer antes del golpe, si se cambian stats.
        /// </summary>
        public virtual void PreBattle(ArkeonInBattle _attacker, ArkeonInBattle _target)
        {
            
        }

        /// <summary>
        /// Que hacer antes del golpe, si se cambian stats.
        /// </summary>
        public virtual void PreBattle(ArkeonInBattle _attacker, PlayerCharacterBattle _target)
        {

        }

        /// <summary>
        /// Que hacer en el momento del golpe.
        /// </summary>
        public virtual void OnBattle(ArkeonInBattle _attacker, ArkeonInBattle _target, Action<HitTypes> _onHitCallback)
        {
            _attacker.animEvents.onAttackHitAction = () =>
            {
                _onHitCallback.Invoke(HitTypes.HIT);
                _attacker.AnimGoBack();
            };
        }

        /// <summary>
        /// Que hacer en el momento del golpe.
        /// </summary>
        public virtual void OnBattle(ArkeonInBattle _attacker, PlayerCharacterBattle _target, Action<HitTypes> _onHitCallback)
        {
            _attacker.animEvents.onAttackHitAction = () => 
            {
                _onHitCallback.Invoke(HitTypes.HIT);
                _attacker.AnimGoBack();
            };
        }

        /// <summary>
        /// Que hacer despues de el golpe. Por ejemplo, un debuff. Siempre debe de llamar el callback cuando termina
        /// </summary>
        public virtual void PostBattle(ArkeonInBattle _attacker, ArkeonInBattle _target, Action _onEndCallback)
        {
            _onEndCallback.Invoke();
        }

        /// <summary>
        /// Que hacer despues de el golpe. Por ejemplo, un debuff.
        /// </summary>
        public virtual void PostBattle(ArkeonInBattle _attacker, PlayerCharacterBattle _target, Action _onEndCallback)
        {
            _onEndCallback.Invoke();
        }

        public virtual void GetInfoFromDatabase()
        {

        }

        public enum HitTypes
        {
            HIT,
            MISS,
            CRIT,
            NO_DAMAGE
        }
    }

    

}