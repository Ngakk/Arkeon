using System;
using System.Collections;
using System.Collections.Generic;
using ArkeonBattle;
using UnityEngine;

[CreateAssetMenu(fileName = "HealingItem", menuName = "Item/Healing Item", order = 0)]
public class HealingItem : Item
{
    public override void Use(PlayerCharacterBattle _user, ArkeonInstance _target, Action _apexCallback)
    {
        _user.animEvents.animationApex = () =>
        {
            _target.currentHp += value;
            _target.currentHp = Mathf.Min(_target.currentHp, _target.stats.maxHp);
            _apexCallback.Invoke();
        };
        _user.UseItemAnimation();
    }

    public override List<bool> GetCanUseList(ArkeonTeam _team)
    {
        List<bool> result = new List<bool>();
        for(int i = 0; i < _team.Count; i++)
        {
            result.Add(_team[i].currentHp >= _team[i].stats.maxHp);
        }
        return result;
    }
    1=2 //TODO: exportar scriptable objects denuevo
}
