using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    public int[] summonedArkeonIds;
    private GameObject[] summonedAkeons;
    private int selectedArkeon;

    public int testGlyph;

    public void TestGlyph()
    {
        ProcessGlyph(testGlyph);
    }

    public void ProcessGlyph(int _glyphId)
    {
        if (_glyphId >= 0 && _glyphId < 10)
        {
            SetActivePanel(_glyphId); 
        } else if (_glyphId >= 10 && _glyphId < 99)
        {
            ProcessArkeonSelection(_glyphId);
        } else if (_glyphId >= 100)
        {

        }
    }

    public void ProcessArkeonSelection(int _arkId)
    {
        if (currentMenuState == MENUSTATES.BOOKA || currentMenuState == MENUSTATES.BOOKB || currentMenuState == MENUSTATES.BOOKC)
        {
            SummonArkeon(_arkId);
        }
        else if (currentMenuState == MENUSTATES.ATK)
        {
            SelectSummonedArkeon(_arkId);
        }
    }

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
            if (_index > 3)
            {
                if (currentMenuState == MENUSTATES.SMN && (_index == 4 || _index == 5 || _index == 6))
                    validPanel = true;
                else if (currentMenuState == MENUSTATES.ATK && _index == 7)
                    validPanel = true;
            }
            else
                validPanel = true;

            if (validPanel)
            {
                HideAllPanels();
                panels[_index].SetActive(true);
                currentMenuState = (MENUSTATES)_index;
                Debug.Log("Current Menu State: " + currentMenuState);
            }
            else
                Debug.Log("Invalid Panel");
        } else
            Debug.Log("Invalid Panel");
    }

    public void SummonArkeon(int _arkId)
    {
        // Summon Arkeon with id _arkID from current opened book 
        switch (currentMenuState)
        {
            case MENUSTATES.BOOKA:
                Debug.Log("Arkeon #" + _arkId + " from Book A");
                break;

            case MENUSTATES.BOOKB:
                Debug.Log("Arkeon #" + _arkId + " from Book B");
                break;

            case MENUSTATES.BOOKC:
                Debug.Log("Arkeon #" + _arkId + " from Book C");
                break;

            default:
                Debug.Log("Invalid Option");
                break;
        }
    }

    public void DismissArkeon(int _arkId)
    {
        // TODO: How to dismiss arkeons
        // Dissmiss Arkeon from summoned arkeons with ID _arkId
    }

    public void LoadArkeons(int _bookId)
    {
        // Load Saved Arkeons from Book with id _bookId
    }

    public void SelectSummonedArkeon(int _arkId)
    {
        // Select summoned Arkeon to command

        // Check if arkeon with id _arkId exists & is summoned
        // Set selectedArkeon to _arkId
        // Change panel to ArkeonCmd
        // Load attacks from selectedArkeon

        bool isSummoned = false;

        if (currentMenuState == MENUSTATES.ATK)
        {
            for (int i = 0; i < summonedArkeonIds.Length; i++)
            {
                if (summonedArkeonIds[i] == _arkId)
                    isSummoned = true;
            }

            if (isSummoned)
            {
                Debug.Log("Selected Arkeon #" + _arkId);
                selectedArkeon = _arkId;
                SetActivePanel((int)MENUSTATES.ARKEONCMD);
                panels[(int)MENUSTATES.ARKEONCMD].GetComponentInChildren<TextMeshProUGUI>().text = "Selected Arkeon #" + _arkId;
            }
            else
                Debug.Log("Invalid Arkeon Id");
        }
    }

    public void LoadArkeonAttacks(int _arkId)
    {
        // Load current selected Arkeon attacks
    }

    public void SelectAttack(int _atkId)
    {
        // Select Attack from current selected Arkeon
        if (currentMenuState == MENUSTATES.ARKEONCMD)
            Debug.Log("Selected Attack #" + _atkId + "from Arkeon #" + selectedArkeon);
    }

    public void SelectItem(int _itemId)
    {
        // Select Item
    }

    public void Run()
    {
        // Run form battle
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
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SetActivePanel(6);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SetActivePanel(7);
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            SummonArkeon(100);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            SummonArkeon(105);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SummonArkeon(210);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            SummonArkeon(169);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            SelectSummonedArkeon(110);
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            SelectSummonedArkeon(150);
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            SelectSummonedArkeon(169);
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            SelectSummonedArkeon(420);
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            SelectAttack(20);
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            
        }
    }
}
