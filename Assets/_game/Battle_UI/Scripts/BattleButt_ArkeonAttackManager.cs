using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleButt_ArkeonAttackManager : MonoBehaviour
{
    public GameObject[] arkeonCards = new GameObject[4];
    public GameObject[] arkeonAttacks = new GameObject[4];
    public GameObject atkPrefab;

    public void SetArkeonAttacks(int _index /*, attack[] _attacks */)
    {
        /*

        for (int i = 0; i < _attacks.Lenght(); i++){
            GameObject atkUI = Instantiate(atkPrefab, arksonAttacks[i]);
            atkUI.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -20-(35*i), 0);
            atkUI.GetComponent<BattleButt_AtkComponent>().SetStats(_attacks[i].name, _attacks[i].cost, _attacks[i].type, _attacks[i].glyph);
        }

        */
    }

    void Update()
    {
        
    }
}
