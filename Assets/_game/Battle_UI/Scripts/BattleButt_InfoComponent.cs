using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleButt_InfoComponent : MonoBehaviour
{
    public Text objName;

    public void SetName(string _name)
    {
        objName.text = _name;
    }
}
