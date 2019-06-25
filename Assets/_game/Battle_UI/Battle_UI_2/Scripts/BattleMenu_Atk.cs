using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ArkeonBattle;

public class BattleMenu_Atk : MonoBehaviour
{
    public TextMeshProUGUI atkName;
    public Image atkType;
    public TextMeshProUGUI atkCost;
    public Image atkGlyph;

    public void SetAllData(string _name, ArkeonElement _type, int _cost, Sprite _glyph)
    {
        atkName.text = _name;
        atkType.sprite = _type.sprite;
        atkCost.text = _cost.ToString();
        atkGlyph.sprite = _glyph;
    }
}
