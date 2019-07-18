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
    public int arkeonTeamId = -1;
    public int arkeonOutId = -1;

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
        cardButton.onClick.AddListener(SelectArkeon);
    }

    public void SetAllData(ArkeonInstance _ark)
    {
        arkImg.sprite = _ark.sprite;
        arkName.text = _ark.myName;
        arkHp.maxValue = _ark.stats.maxHp;
        arkHp.value = _ark.currentHp;
        int i = 0;
        foreach(Transform child in costPanel.transform)
        {
            child.gameObject.SetActive(false);
            if (i < _ark.stats.cost)
            {
                child.gameObject.SetActive(true);
                i++;
            }
        }
        arkCostText.text = _ark.currentHp + " / " + _ark.stats.maxHp;
        arkeonInstanceSO = _ark;
    }

    public void SelectArkeon()
    {
        menuMain.ProcessArkeonSelection(this);
    }

    public void InspectArkeon()
    {
        infoPanel.GetComponent<BattleMenu_InfoMain>().InspectArkeon(arkeonInstanceSO);
    }
}
