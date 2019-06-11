﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleMenu_Item : MonoBehaviour
{
    public TextMeshProUGUI itmName;
    public Image itmImg;
    public TextMeshProUGUI itmQty;

    public void SetAllData(Sprite _spr, string _name, int _qty)
    {
        itmImg.sprite = _spr;
        itmName.text = _name;
        itmQty.text = _qty.ToString();
    }
}
