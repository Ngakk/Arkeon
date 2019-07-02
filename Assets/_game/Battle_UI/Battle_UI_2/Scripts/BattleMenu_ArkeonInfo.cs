using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ArkeonBattle;

public class BattleMenu_ArkeonInfo : MonoBehaviour
{
    public TextMeshProUGUI arkName;
    public TextMeshProUGUI arkDescription;
    public Image arkImage;
    public Image arkType;
    public TextMeshProUGUI arkAttack;
    public TextMeshProUGUI arkDefense;
    public TextMeshProUGUI arkHP;
    public TextMeshProUGUI arkCost;

    public GameObject atkPfb;
    public GameObject arkAttacksPanel;

    public void SetAllData(ArkeonInstance _arkInst)
    {
        arkName.text = _arkInst.myName;
        arkDescription.text = _arkInst.arkeonData.description;
        arkImage.sprite = _arkInst.sprite;
        arkType.sprite = _arkInst.stats.type.sprite;
        arkAttack.text = _arkInst.stats.atk.ToString();
        arkDefense.text = _arkInst.stats.def.ToString();
        arkHP.text = _arkInst.stats.maxHp.ToString();
        arkCost.text = _arkInst.stats.cost.ToString();
    }

    public void SetAttacks(List<ArkeonAttack> _attacks)
    {
        for (int i = 0; i < _attacks.Count; i++)
        {
            GameObject atk = Instantiate(atkPfb, arkAttacksPanel.transform);
            atk.GetComponent<BattleMenu_Atk>().SetAllData(_attacks[i].myName, _attacks[i].type, _attacks[i].cost, _attacks[i].glyph);
        }
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
