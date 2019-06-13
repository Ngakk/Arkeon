using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mangos {
    [CreateAssetMenu(fileName = "SimpleAttack", menuName = "Arkeon Creature/Arkeon Attacks/Simple Attack", order = 0)]
    public class SimpleAttack : ArkeonAttack
    {
        public override void OnBattle(ArkeonInBattle _attacker, ArkeonInBattle _target, Action<HitTypes> _onHitCallback)
        {
            ArkeonBattleUtility.ArkeonCombatResult result = ArkeonBattleUtility.GetCombatResult(_attacker, this, _target);

            _attacker.animEvents.onAttackHitAction = () =>
            {
                _onHitCallback(result.hitType);
                _target.spirit.stats.HP -= result.damageDone;
            };

            _attacker.AnimAttack(animation);
            _attacker.AnimGoBack();
        }

        public override void OnBattle(ArkeonInBattle _attacker, PlayerCharacterBattle _target, Action<HitTypes> _onHitCallback)
        {
            base.OnBattle(_attacker, _target, _onHitCallback);
        }
    }
}