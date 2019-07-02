using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkeonBattle;


public class Item : ScriptableObject
{
    public string name = "item";
    public string description = "description";

    public int value;

    public virtual void Use(PlayerCharacterBattle _user, ArkeonInstance _target, Action _apexCallback)
    { 
        _user.animEvents.animationApex = _apexCallback;
        _user.UseItemAnimation();
    }

    public virtual List<bool> GetCanUseList(ArkeonTeam _team)
    {
        return new List<bool>(_team.Count);
    }
}
