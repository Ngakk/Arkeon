using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleButt_AtkInfoComponent : BattleButt_InfoComponent
{
    // Attack Data
    [Header("Attack Data")]
    public Image atkStatType;
    public Text atkStatPhysical;
    public Text atkStatAccuracy;
    public Text atkStatPower;
    public Text atkStatCost;

    public void SetAttackData(Sprite _type, bool _isPhysical, float _accuarcy, float _power, int _cost)
    {
        atkStatType.sprite = _type;
        /*
        if (_isPhysical)
            atkStatPhysical.sprite = tick_spr;
        else
        atkStatPhysical.sprite = cross_spr;
        */
        atkStatAccuracy.text = _accuarcy.ToString();
        atkStatPower.text = _power.ToString();
        atkStatCost.text = _cost.ToString();
    }
}
