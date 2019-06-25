using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkeonBattle;

public class BattleMenu_InfoMain : MonoBehaviour
{
    public GameObject[] infoElements;

    public void InspectArkeon(ArkeonInstance _arkeon)
    {
        infoElements[0].GetComponent<BattleMenu_ArkeonInfo>().EnableInfoPanel();
        infoElements[0].GetComponent<BattleMenu_ArkeonInfo>().SetAllData(_arkeon);
    }

    public void InspectAttack()
    {
        infoElements[1].GetComponent<BattleMenu_AttackInfo>().EnableInfoPanel();
    }

    public void InspectItem()
    {
        infoElements[2].GetComponent<BattleMenu_ItemInfo>().EnableInfoPanel();
    }
}
