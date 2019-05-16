using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleButt_InfoComponent : MonoBehaviour
{
    // General Data
    public Image objImage;
    public Text objName;
    public Text objDescription;

    public virtual void SetGeneralData(string _name, string _description, Sprite _img)
    {
        objImage.sprite = _img;
        objName.text = _name;
        objDescription.text = _description;
    }
}
