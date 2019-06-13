using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{

    public enum AttackTypes : int
    {
        PHYSICAL,
        SPECIAL
    }

    public enum AttackAnimations : int
    {
        NOTHING,
        MELEE_ATTACK,
        RANGED_ATTACK,
        HEAL,
    }

    //[CreateAssetMenu(fileName = "BaseAttack", menuName = "Arkeon Creature/Arkeon Attacks/Base Attack", order = 3)]
    public class ArkeonAttack : ScriptableObject
    {
        public string myName;
        public string description;
        public int power;
        public int cost;
        public int accuaracy;
        public ArkeonElement type;
        public bool isPhysical;
        public bool targetsEnemy = true;
        public AttackAnimations animation;

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

        public enum HitTypes
        {
            HIT,
            MISS,
            CRIT,
            NO_DAMAGE
        }
    }

    

}