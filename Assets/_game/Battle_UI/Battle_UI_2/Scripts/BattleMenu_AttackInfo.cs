using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ArkeonBattle;

public class BattleMenu_AttackInfo : MonoBehaviour
{
    public TextMeshProUGUI atknName;
    public Image glyph;
    public TextMeshProUGUI description;
    public Image type;
    public TextMeshProUGUI power;
    public TextMeshProUGUI accuracy;
    public Toggle isPhysical;
    public TextMeshProUGUI cost;

    public void SetAllData(ArkeonAttack _attack)
    {
        atknName.text = _attack.name;
        glyph.sprite = _attack.glyph;
        description.text = _attack.description;
        type.sprite = _attack.type.sprite;
        power.text = _attack.power.ToString();
        accuracy.text = _attack.accuaracy.ToString();
        isPhysical.isOn = _attack.isPhysical;
        cost.text = _attack.cost.ToString();
    }

    public void EnableInfoPanel()
    {
        this.gameObject.SetActive(true);
    }

    public void DisableInfoPanel()
    {
        this.gameObject.SetActive(false);
    }
}
