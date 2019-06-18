using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkeonBattle
{
    [CreateAssetMenu(fileName = "SimpleHeal", menuName = "Arkeon Creature/Arkeon Attacks/Simple Heal", order = 0)]
    public class SimpleHeal : ArkeonAttack
    {
        public override void OnBattle(ArkeonInBattle _attacker, ArkeonInBattle _target, Action<HitTypes> _onHitCallback)
        {
            _attacker.animEvents.onAttackHitAction = () =>
            {
                _target.myInstance.currentHp += power;
                if (_target.myInstance.currentHp > _target.myInstance.stats.maxHp)
                    _target.myInstance.currentHp = _target.myInstance.stats.maxHp;

                _attacker.AnimGoBack();
            };
            _attacker.AnimAttack(AttackAnimations.HEAL);

        }

        public override void OnBattle(ArkeonInBattle _attacker, PlayerCharacterBattle _target, Action<HitTypes> _onHitCallback)
        {
            base.OnBattle(_attacker, _target, _onHitCallback);
        }
    }
}