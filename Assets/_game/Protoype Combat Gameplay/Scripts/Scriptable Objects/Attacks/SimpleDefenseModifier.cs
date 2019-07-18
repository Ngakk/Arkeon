using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArkeonBattle
{
    [CreateAssetMenu(fileName = "SimpleDefenseModifier", menuName = "Arkeon Creature/Arkeon Attacks/Simple Defense Modifier", order = 0)]
    public class SimpleDefenseModifier : ArkeonAttack
    {
        [Tooltip("Este valor es lo que se le va a agregar a los stats del arkeon, puede ser negativo o positivo")]
        public int value = 0;

        public override void OnBattle(ArkeonInBattle _attacker, ArkeonInBattle _target, Action<HitTypes> _onHitCallback)
        {
            _attacker.animEvents.onAttackHitAction = () =>
            {
                _target.inBattleModifiers.def += value;
            };

            _attacker.AnimAttack(animation);
            //_attacker.AnimGoBack();
        }

        public override void OnBattle(ArkeonInBattle _attacker, PlayerCharacterBattle _target, Action<HitTypes> _onHitCallback)
        {
            _attacker.animEvents.onAttackHitAction = () =>
            {
                _target.inBattleModifiers.def += value;
            };

            _attacker.AnimAttack(animation);
            //_attacker.AnimGoBack();
        }
    }
}