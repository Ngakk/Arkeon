using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleButt_PanelComponent : MonoBehaviour
{
    [HideInInspector]
    public GameObject panel;
    public int id;

    void Awake()
    {
        panel = this.gameObject;
    }
}
