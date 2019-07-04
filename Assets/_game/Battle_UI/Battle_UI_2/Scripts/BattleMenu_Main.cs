using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ArkeonBattle;

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

    public PlayerCharacterBattle player;
    public PlayerCharacterBattle enemy;

    public GameObject[] panels;
    public GameObject item_pfb;
    public GameObject atk_pfb;

    private MENUSTATES currentMenuState = MENUSTATES.SMN;
    public ArkeonInstance[] summonedArkeons;
    private ArkeonInstance selectedArkeon;
    public string[] itemNames;
    public Sprite itmImg;

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
        } else if (_glyphId >= 100)
        {
            SelectAttack(_glyphId);
        }
    }

    public void ProcessArkeonSelection(ArkeonInstance _ark)
    {
        if (currentMenuState == MENUSTATES.BOOKA || currentMenuState == MENUSTATES.BOOKB || currentMenuState == MENUSTATES.BOOKC)
        {
            SummonArkeon(_ark);
        }
        else if (currentMenuState == MENUSTATES.ATK)
        {
            SelectSummonedArkeon(_ark);
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

    public void SummonArkeon(ArkeonInstance _ark)
    {
        // Summon Arkeon with id _arkID from current opened book 
        switch (currentMenuState)
        {
            case MENUSTATES.BOOKA:
                Debug.Log("Arkeon " + _ark.myName + " from Book A");
                break;

            case MENUSTATES.BOOKB:
                Debug.Log("Arkeon " + _ark.myName + " from Book B");
                break;

            case MENUSTATES.BOOKC:
                Debug.Log("Arkeon " + _ark.myName + " from Book C");
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

    //TODO
    // Change SelectSummonedArkeon Function to work onClick

    public void SelectSummonedArkeon(ArkeonInstance _ark)
    {
        // Select summoned Arkeon to command
        // Check if arkeon with id _arkId exists & is summoned
        // Set selectedArkeon to _arkId
        // Change panel to ArkeonCmd
        // Load attacks from selectedArkeon

        bool isSummoned = false;

        if (currentMenuState == MENUSTATES.ATK)
        {
            for (int i = 0; i < summonedArkeons.Length; i++)
            {
                if (summonedArkeons[i] == _ark) // Check TODO
                {
                    isSummoned = true;
                }
            }

            if (isSummoned)
            {
                Debug.Log("Selected Arkeon " + _ark.myName);
                selectedArkeon = _ark;
                SetActivePanel((int)MENUSTATES.ARKEONCMD);
                panels[(int)MENUSTATES.ARKEONCMD].GetComponentInChildren<TextMeshProUGUI>().text = "Selected Arkeon " + _ark.myName;
                LoadArkeonAttacks();
            }
            else
                Debug.Log("Invalid Arkeon");
        }
    }

    public void LoadArkeonAttacks()
    {
        // Clear Previously Loaded Attacks
        foreach (Transform child in panels[(int)MENUSTATES.ARKEONCMD].transform)
        {
            Destroy(child.gameObject);
        }

        List<ArkeonAttack> atks = selectedArkeon.attacks;

        // Load current selected Arkeon attacks
        if (currentMenuState == MENUSTATES.ARKEONCMD)
        {
            for (int i = 0; i < selectedArkeon.attacks.Count; i++)
            {
                GameObject atk = Instantiate(atk_pfb, panels[(int)MENUSTATES.ARKEONCMD].transform);
                atk.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -75 - (125 * i), 0);
                atk.GetComponent<BattleMenu_Atk>().SetAllData(atks[i]);
            }
        }
    }

    public void SelectAttack(int _atkId)
    {
        // Select Attack from current selected Arkeon
        if (currentMenuState == MENUSTATES.ARKEONCMD)
            Debug.Log("Selected Attack #" + _atkId + " from Arkeon #" + selectedArkeon);
    }

    public void LoadItems()
    {
        // Load Carried Items Data from Database & Instantiate Buttons
        for (int i = 0; i < itemNames.Length; i++)
        {
            GameObject itm = Instantiate(item_pfb, panels[2].transform);
            itm.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -40-(90*i), 0);
            itm.GetComponent<BattleMenu_Item>().SetAllData(itmImg, itemNames[i], 99, i);
            itm.GetComponent<Button>().onClick.AddListener(delegate {SelectItem(itm.GetComponent<BattleMenu_Item>().itemId);});
        }
    }

    public void SelectItem(int _itemId)
    {
        // Select Item
        if (currentMenuState == MENUSTATES.ITM)
            Debug.Log("Selected item #" + _itemId);
    }

    public void Run()
    {
        // Run form battle
        Debug.Log("Ran Away");
    }

    void Start()
    {
        SetActivePanel((int)currentMenuState);
        LoadItems();
    }
}
