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

namespace UnityEngine.EventSystems
{
    public class BattleButt_Component : MonoBehaviour
    {
        public GameObject[] mainPanels;
        public GameObject itemInfoPanel;
        public GameObject attackInfoPanel;
        public GameObject arkeonInfoPanel;

        private Stack<GameObject> activeInfoPanels = new Stack<GameObject>();

        public struct MainPanel
        {
            public GameObject panel;
            public int id;
        };

        public MainPanel[] s_mainPanels = new MainPanel[3];

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

        void Start()
        {
            InitializeMainPanels();
            ShowSubMenu((int)currentSubMenuIndex);
            currentSubMenu = mainPanels[(int)currentSubMenuIndex];
        }

        private void InitializeMainPanels()
        {
            for (int i = 0; i < mainPanels.Length; i++)
            {
                s_mainPanels[i].panel = mainPanels[i].GetComponent<BattleButt_PanelComponent>().panel;
                s_mainPanels[i].id = mainPanels[i].GetComponent<BattleButt_PanelComponent>().id;
            }
        }

        // Index Based SubMenus
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

        // ID Based SubMenus
        public void ShowSubMenuID(int _id)
        {
            for (int i = 0; i < s_mainPanels.Length; i++)
            {
                if (_id == s_mainPanels[i].id)
                {
                    HideAllMenus();
                    s_mainPanels[i].panel.SetActive(true);
                }
            }
        }

        public void HideAllMenus()
        {
            for (int i = 0; i < s_mainPanels.Length; i++)
            {
                s_mainPanels[i].panel.SetActive(false);
            }
        }

        // Index Based SubOptions
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

        public void ShowObjInfo()
        {
            Debug.Log("Clicked " + EventSystem.current.currentSelectedGameObject.name);
            // TODO
            // Initialize Panel Data
            switch (EventSystem.current.currentSelectedGameObject.tag)
            {
                case "BM_Item":
                    itemInfoPanel.SetActive(true);
                    activeInfoPanels.Push(itemInfoPanel);
                    break;

                case "BM_Attack":
                    attackInfoPanel.SetActive(true);
                    activeInfoPanels.Push(attackInfoPanel);
                    break;

                case "BM_Arkeon":
                    arkeonInfoPanel.SetActive(true);
                    activeInfoPanels.Push(arkeonInfoPanel);
                    break;
            }
        }

        public void CloseObjInfo()
        {
            activeInfoPanels.Pop().SetActive(false);
        }

        void Update()
        {
            // Temp Testing Methods

            if (Input.GetKeyDown(KeyCode.P))
            {
                CloseObjInfo();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ShowSubMenuID(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ShowSubMenuID(5);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ShowSubMenuID(20);
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
}
