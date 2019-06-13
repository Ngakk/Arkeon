using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos
{
    [CreateAssetMenu(fileName = "SimpleHeal", menuName = "Arkeon Creature/Arkeon Attacks/Simple Heal", order = 0)]
    public class SimpleHeal : ArkeonAttack
    {
        public override void OnBattle(ArkeonInBattle _attacker, ArkeonInBattle _target, Action<HitTypes> _onHitCallback)
        {
            _attacker.animEvents.onAttackHitAction = () =>
            {
                _target.spirit.stats.HP += power;
                if (_target.spirit.stats.HP > _target.spirit.stats.MaxHP)
                    _target.spirit.stats.HP = _target.spirit.stats.MaxHP;

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