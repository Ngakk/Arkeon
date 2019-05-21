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

    public enum AttackAnimations : int
    {
        NOTHING,
        MELEE_ATTACK,
        RANGED_ATTACK,
        HEAL,
    }

    [CreateAssetMenu]
    public class ArkeonAttack : ScriptableObject
    {
        public string myName;
        public string description;
        public int power;
        public int cost;
        public int accuaracy;
        public ArkeonTypes type;
        public bool isPhysical;
        public AttackAnimations animation;

        //TODO: pensar en sistema de pre, on y post hit, ademas de cosas al inicio de los turnos y la madre.

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
        public virtual void OnBattle(ArkeonInBattle _attacker, ArkeonInBattle _target, Action<HitTypes, int> _onHitCallback)
        {
            _attacker.animEvents.onAttackHitAction = () => { _onHitCallback.Invoke(HitTypes.HIT, 0); };
            _attacker.AnimAttack(animation);
            _attacker.AnimGoBack();
        }

        /// <summary>
        /// Que hacer en el momento del golpe.
        /// </summary>
        public virtual void OnBattle(ArkeonInBattle _attacker, PlayerCharacterBattle _target, Action<HitTypes, int> _onHitCallback)
        {
            _attacker.animEvents.onAttackHitAction = () => { _onHitCallback.Invoke(HitTypes.HIT, 0); };
            _attacker.AnimAttack(animation);
            _attacker.AnimGoBack();
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