using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleMenu_ArkCard : MonoBehaviour
{
    public Image arkImg;
    public TextMeshProUGUI arkName;
    public Slider arkHp;
    public GameObject costPanel;
    public TextMeshProUGUI arkCostText;

    [Header("Testing Data Fill")]
    public string arkeonName;
    public Sprite arkeonImg;
    public int arkeonMaxHP;
    public int arkeonHP;
    public int arkeonCost;

    private void Start()
    {
        SetAllData(arkeonImg, arkeonName, arkeonMaxHP, arkeonHP, arkeonCost);
    }

    void SetAllData(Sprite _img, string _name, int _maxHp, int _hp, int _cost)
    {
        arkImg.sprite = _img;
        arkName.text = _name;
        arkHp.maxValue = _maxHp;
        arkHp.value = _hp;
        int i = 0;
        foreach(Transform child in costPanel.transform)
        {
            child.gameObject.SetActive(false);
            if (i < _cost)
            {
                child.gameObject.SetActive(true);
                i++;
            }
        }
        arkCostText.text = arkeonHP + " / " + arkeonMaxHP;
    }
}
