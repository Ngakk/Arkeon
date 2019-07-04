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
        SetAllData(attackSO.name, attackSO.type, attackSO.cost, attackSO.glyph);
        atkButton.onClick.AddListener(InspectAttack);
    }

    public void SetAllData(string _name, ArkeonElement _type, int _cost, Sprite _glyph)
    {
        atkName.text = _name;
        atkType.sprite = _type.sprite;
        atkCost.text = _cost.ToString();
        atkGlyph.sprite = _glyph;
    }

    public void InspectAttack()
    {
        infoPanel.GetComponent<BattleMenu_InfoMain>().InspectAttack(attackSO);
    }
}
