using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkeonBattle
{
    [CreateAssetMenu(fileName = "SimpleAttack", menuName = "Arkeon Creature/Arkeon Attacks/Simple Attack", order = 0)]
    public class SimpleAttack : ArkeonAttack
    {
        public override void OnBattle(ArkeonInBattle _attacker, ArkeonInBattle _target, Action<HitTypes> _onHitCallback)
        {
            ArkeonBattleUtility.ArkeonCombatResult result = ArkeonBattleUtility.GetCombatResult(_attacker.myInstance.stats, this, _target.myInstance.stats);

            _attacker.animEvents.onAttackHitAction = () =>
            {
                _onHitCallback(result.hitType);
                _target.myInstance.currentHp -= result.damageDone;
            };

            _attacker.AnimAttack(animation);
            _attacker.AnimGoBack();
        }

        public override void OnBattle(ArkeonInBattle _attacker, PlayerCharacterBattle _target, Action<HitTypes> _onHitCallback)
        {
            ArkeonBattleUtility.ArkeonCombatResult result = ArkeonBattleUtility.GetCombatResult(_attacker.myInstance.stats, this, _target.stats);

            _attacker.animEvents.onAttackHitAction = () =>
            {
                _onHitCallback(result.hitType);
                _target.currentHp -= result.damageDone;
                Debug.Log("Damage done: " + result.damageDone);
            };

            _attacker.AnimAttack(animation);
            _attacker.AnimGoBack();
        }
    }
}