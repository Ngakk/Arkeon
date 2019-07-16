﻿using System.Collections;
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
    public Image[] mainOptions;
    public GameObject item_pfb;
    public GameObject atk_pfb;
    public GameObject ark_pfb;

    public ArkeonTeam team;

    private MENUSTATES currentMenuState = MENUSTATES.SMN;
    private List<ArkeonInstance> summonedArkeons = new List<ArkeonInstance>();
    private ArkeonInstance selectedArkeon;
    public string[] itemNames;
    public Sprite itmImg;

    private Color activeMenuColor = new Color(0.39f, 0.23f, 0.45f);

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
            {
                validPanel = true;
                for (int i = 0; i < mainOptions.Length; i++)
                {
                    mainOptions[i].color = Color.black;
                    if (_index == i)
                        mainOptions[_index].color = activeMenuColor;
                }
            } 

            if (validPanel)
            {
                HideAllPanels();
                panels[_index].SetActive(true);
                currentMenuState = (MENUSTATES)_index;
                Debug.Log("Current Menu State: " + currentMenuState);
            }
            else
                Debug.Log("Invalid Panel " + _index);
        } else
            Debug.Log("Invalid Panel");
    }

    public void SummonArkeon(ArkeonInstance _ark)
    {
        if (summonedArkeons.Count < 2)
        {
            bool duplicate = false;
            for (int i = 0; i < summonedArkeons.Count; i++)
            {
                if (summonedArkeons[i] == _ark)
                    duplicate = true;
            }

            if (!duplicate)
            {
                summonedArkeons.Add(_ark);
                LoadSummonedArkeons();
                SetActivePanel((int)MENUSTATES.ATK);
            } else
            {
                Debug.Log("Arkeon Already Summoned");
            }
        } else
        {
            Debug.Log("Arkeon Limit Reached");
        }
    }

    public void LoadArkeons()
    {
        // Load Book A Arkeons
        Debug.Log(team);

        for (int i = 0; i < team.lightBook.Count; i++)
        {
            GameObject ark = Instantiate(ark_pfb, panels[(int)MENUSTATES.BOOKA].transform);
            ark.GetComponent<BattleMenu_ArkCard>().SetAllData(team.lightBook[i]);
        }

        // Load Book B Arkeons
        for (int i = 0; i < team.darkBook.Count; i++)
        {
            GameObject ark = Instantiate(ark_pfb, panels[(int)MENUSTATES.BOOKB].transform);
            ark.GetComponent<BattleMenu_ArkCard>().SetAllData(team.darkBook[i]);
        }

        // Load Book C Arkeons
        for (int i = 0; i < team.natureBook.Count; i++)
        {
            GameObject ark = Instantiate(ark_pfb, panels[(int)MENUSTATES.BOOKC].transform);
            ark.GetComponent<BattleMenu_ArkCard>().SetAllData(team.natureBook[i]);
        }
    }

    public void LoadSummonedArkeons()
    {
        foreach(Transform child in panels[(int)MENUSTATES.ATK].transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < summonedArkeons.Count; i++)
        {
            GameObject ark = Instantiate(ark_pfb, panels[(int)MENUSTATES.ATK].transform);
            ark.GetComponent<BattleMenu_ArkCard>().SetAllData(summonedArkeons[i]);
        }
    }

    public void SelectSummonedArkeon(ArkeonInstance _ark)
    {

        bool isSummoned = false;

        if (currentMenuState == MENUSTATES.ATK)
        {
            for (int i = 0; i < summonedArkeons.Count; i++)
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
        {
            ArkeonAttack selectedAttack = null;
            for (int i = 0; i < selectedArkeon.attacks.Count; i++)
            {
                if (selectedArkeon.attacks[i].db_id == _atkId)
                    selectedAttack = selectedArkeon.attacks[i];
            }

            if (selectedAttack != null)
            {
                Debug.Log(selectedArkeon.myName + " used " + selectedAttack.myName + "!");
            }
        }
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
        LoadArkeons();
        LoadSummonedArkeons();
    }
}
