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

    public ArkeonAttack attackSO;

    private GameObject infoPanel;
    private Button atkButton;

    private void Awake()
    {
        infoPanel = GameObject.FindGameObjectWithTag("BM_InfoMain");
        atkButton = GetComponent<Button>();
    }

    private void Start()
    {
        //Data Fill
        if (attackSO)
            SetAllData(attackSO);

        atkButton.onClick.AddListener(InspectAttack);
    }

    public void SetAllData(ArkeonAttack _atk)
    {
        attackSO = _atk;
        atkName.text = _atk.myName;
        atkType.sprite = _atk.type.sprite;
        atkCost.text = _atk.cost.ToString();
        atkGlyph.sprite = _atk.glyph;
    }

    public void InspectAttack()
    {
        infoPanel.GetComponent<BattleMenu_InfoMain>().InspectAttack(attackSO);
    }
}
