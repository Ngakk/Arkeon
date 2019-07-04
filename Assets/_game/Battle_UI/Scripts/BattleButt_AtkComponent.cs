using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleButt_AtkComponent : MonoBehaviour
{
    public int id;
    public Text atkName;
    public Text atkCost;
    public Image atkType;
    public Image atkGlyph;

    public void SetStats(string _name, string _cost, Color _type, Sprite _spr)
    {
        atkName.text = _name;
        atkCost.text = _cost;
        atkType.material.color = _type;
        atkGlyph.sprite = _spr;
    }
}
