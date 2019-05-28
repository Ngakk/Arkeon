using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMenu_Main : MonoBehaviour
{
    public enum MENUSTATES
    {
        SMN = 0,
        ATK = 1,
        ITM = 2,
        RUN = 3,
        BOOKA = 4,
        BOOKB = 5,
        BOOKC = 6,
        ARKEONCMD = 7
    };

    public GameObject[] panels;

    private MENUSTATES currentMenuState = MENUSTATES.SMN;
    private GameObject[] summonedAkeons;

    public void HideAllPanels()
    {
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }
    }

    public void SetActivePanel(int _index)
    {
        bool validPanel = false;

        if (_index < panels.Length)
        {
            if (_index > 4)
            {
                if (currentMenuState == MENUSTATES.SMN && (_index == 4 || _index == 5 || _index == 6))
                {
                    validPanel = true;
                }
                else if (currentMenuState == MENUSTATES.ATK && (_index == 7))
                {
                    validPanel = true;
                }
            }
            else
                validPanel = true;

            if (validPanel)
            {
                HideAllPanels();
                panels[_index].SetActive(true);
            }
            else
            {
                Debug.Log("Invalid Panel");
            }
        } else
        {
            Debug.Log("Invalid Panel");
        }
    }

    public void SummonArkeon(int _arkId)
    {
        // Summon Arkeon from current book with ID _arkId
    }

    public void DismissArkeon(int _arkId)
    {
        // Dissmiss Arkeon from summoned arkeons with ID _arkId
    }

    public void LoadArkeons()
    {
        
    }

    void Start()
    {
        SetActivePanel((int)currentMenuState);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActivePanel(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActivePanel(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetActivePanel(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetActivePanel(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetActivePanel(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SetActivePanel(5);
        }
    }
}
