using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleButt_ArkInfoComponent : BattleButt_InfoComponent
{
    // Arkeon Data
    [Header("Arkeon Data")]
    public Text arkStatAtk;
    public Text arkStatDef;
    public Text arkStatHP;
    public Text arkStatCost;
    public GameObject arkAttacksPanel;

    public GameObject attackPrefab;

    public void SetArkeonData(float _atk, float _def, float _hp, float _maxHp, float _cost)
    {
        arkStatAtk.text = _atk.ToString();
        arkStatDef.text = _def.ToString();
        arkStatHP.text = _hp.ToString() + "/" + _maxHp.ToString();
        arkStatCost.text = _cost.ToString();
    }

    // WIP
    /*
    public void SetArkeonAttacks(List<ArkeonAttacks> _attacks)
    {
        for (int i = 0; i < _attacks.Count; i++){
            GameObject atk = Instantiate(attackPrefab, arkAttacksPanel);
            atk.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, (i * -27)-15, 0);
            foreach (Transform child in atk.transform){
                if (child.gameObject.name == "Name")
                    child.gameObject.getComponent<Text>().text = _attacks[i].myName;
                else if (child.gameObject.name == "Type")
                    child.gameObject.GetComponent<Image>().color = // Attack Type Color w/index '_attacks[i].type';
                else if (child.gameObject.name == "Cost")
                    child.gameObject.GetComponent<Text>().text = _attacks[i].cost;
                else if (child.gameObject.name == "Glyph")
                    child.gameObject.GetComponent<Image>().sprite = // Attack Glyph w/index '_attacks[i].glyph'?
            }
        }
    }
    */
}
