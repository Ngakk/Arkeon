using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMenu_AttackInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableInfoPanel()
    {
        this.gameObject.SetActive(true);
    }

    public void DisableInfoPanel()
    {
        this.gameObject.SetActive(false);
    }
}
