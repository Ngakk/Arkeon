using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleButt_InfoComponent : MonoBehaviour
{
    public Image objImage;
    public Text objName;
    public Text objDescription;
    public Text objStatAtk;
    public Text objStatDef;
    public Text objStatHP;
    public Text objStatCost;
    public GameObject attacksPanel;
    
    public enum objType
    {
        ITEM,
        ATTACK,
        ARKEON
    }

    public void SetAttackData(string _name)
    {
        objName.text = _name;
    }

    public void SetItemData()
    {

    }

    public void SetArkeonData()
    {

    }
}
