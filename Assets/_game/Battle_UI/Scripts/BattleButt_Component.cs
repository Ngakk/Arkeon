using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * TODO
 * Missing a way to go back through menus
 * Items method 
 * 3+ sublevel options
 */

public class BattleButt_Component : MonoBehaviour
{
    public GameObject[] mainPanels;
    public GameObject infoPanel;

    public enum subMenus
    {
        SMN = 0,
        ATK = 1,
        ITM = 2,
        SMNARK = 10,
        ATKARK = 11
    };

    public enum books
    {
        BOOKA = 0,
        BOOKB = 1,
        BOOKC = 2
    }

    private subMenus currentSubMenuIndex = subMenus.ATK;
    private GameObject currentSubMenu;

    // PLACEHOLDER
    private string[] randomNames =
    {
        "Bust-a-nut Sword",
        "Homeward Bone",
        "PP Hard",
        "Blue Shell",
        "Soldier's Syringe",
        "AWP",
        "PK Fire",
        "Skullheart"
    };

    void Start()
    {
        ShowSubMenu((int)currentSubMenuIndex);
        currentSubMenu = mainPanels[(int)currentSubMenuIndex];
    }

    public void ShowSubMenu(int _index)
    {
        if (_index < mainPanels.Length)
        {
            for (int i = 0; i < mainPanels.Length; i++)
            {
                if (i == _index)
                    mainPanels[i].SetActive(true);
                else
                    mainPanels[i].SetActive(false);
            }
            mainPanels[_index].GetComponent<BattleButt_SubComponent>().LoadDefaultState();
            currentSubMenuIndex = (subMenus)_index;
            currentSubMenu = mainPanels[(int)currentSubMenuIndex];
        }
    }

    public void ShowSubOption(int _index)
    {
        int maxOptions = currentSubMenu.GetComponent<BattleButt_SubComponent>().options.Length;
        if (_index < maxOptions)
        {
            for (int i = 0; i < maxOptions; i++)
            {
                currentSubMenu.GetComponent<BattleButt_SubComponent>().options[i].SetActive(false);
                if (i == _index)
                {
                    currentSubMenu.GetComponent<BattleButt_SubComponent>().options[i].SetActive(true);
                }
            }
        }
    }

    public void ShowObjInfo(GameObject _obj)
    {
        infoPanel.SetActive(true);
        if (!_obj)
        {
            //infoPanel.GetComponent<BattleButt_InfoComponent>().SetName(randomNames[Random.Range(0, randomNames.Length)]);
        }
    }

    public void CloseObjInfo()
    {
        infoPanel.SetActive(false);
    }

    void Update()
    {
        // Temp Testing Methods

        if (Input.GetKeyDown(KeyCode.I))
        {
            ShowObjInfo(null);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            CloseObjInfo();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowSubMenu(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShowSubMenu(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShowSubMenu(2);
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            ShowSubOption(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            ShowSubOption(1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            ShowSubOption(2);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            ShowSubOption(3);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            ShowSubOption(4);
        }
    }
}
