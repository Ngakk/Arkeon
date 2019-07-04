using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleButt_SubComponent : MonoBehaviour
{
    public GameObject[] defaultStates;
    public GameObject[] options;

    public void LoadDefaultState()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].SetActive(false);
        }
        for (int i = 0; i < defaultStates.Length; i++)
        {
            defaultStates[i].SetActive(true);
        }
    }
}
