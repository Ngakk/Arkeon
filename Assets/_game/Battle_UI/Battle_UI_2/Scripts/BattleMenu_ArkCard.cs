using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ArkeonBattle;

public class BattleMenu_ArkCard : MonoBehaviour
{
    public Image arkImg;
    public TextMeshProUGUI arkName;
    public Slider arkHp;
    public GameObject costPanel;
    public TextMeshProUGUI arkCostText;

    public ArkeonInstance arkeonInstanceSO;

    public GameObject infoPanel;
    public BattleMenu_Main menuMain;

    private Button cardButton;

    private void Awake()
    {
        infoPanel = GameObject.FindGameObjectWithTag("BM_InfoMain");
        menuMain = GameObject.FindGameObjectWithTag("BM_Main").GetComponent<BattleMenu_Main>();
        cardButton = GetComponent<Button>();
    }

    private void Start()
    {
        //Data Fill
        SetAllData(arkeonInstanceSO.sprite, arkeonInstanceSO.myName, arkeonInstanceSO.stats.maxHp, (int)arkeonInstanceSO.currentHp, arkeonInstanceSO.stats.cost);
        cardButton.onClick.AddListener(SelectArkeon);
    }

    public void SetAllData(Sprite _img, string _name, int _maxHp, int _hp, int _cost)
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
        arkCostText.text = _hp + " / " + _maxHp;
    }

    public void SelectArkeon()
    {
        menuMain.ProcessArkeonSelection(arkeonInstanceSO);
    }

    public void InspectArkeon()
    {
        infoPanel.GetComponent<BattleMenu_InfoMain>().InspectArkeon(arkeonInstanceSO);
    }
}
