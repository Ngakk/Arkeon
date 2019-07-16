using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ArkeonBattle
{
    [CustomEditor(typeof(ArkeonInstance))]
    public class ArkeonInstanceEditor : Editor
    {
        bool editingAttacks = false;
        Vector2 attackScrollPos = new Vector2();

        int attackFetchLevel = 0;
        List<ArkeonAttack> avilableAttacks = new List<ArkeonAttack>();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ArkeonInstance script = (ArkeonInstance)target;

            if (editingAttacks)
            {
                if(GUILayout.Button("Back"))
                {
                    editingAttacks = false;
                }
                //Load current attacks:
                GUILayout.Label("Current attacks:", EditorStyles.boldLabel);
                for(int i = 0; i < script.attacks.Count; i++)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(new GUIContent(script.attacks[i].myName, script.attacks[i].description));
                    if(GUILayout.Button("X", GUILayout.Width(30)))
                    {
                        script.attacks.RemoveAt(i);
                        break;
                    }
                    if(GUILayout.Button("↓", GUILayout.Width(30)))
                    {
                        SwapAttacks(script.attacks, i, i+1);
                    }
                    if(GUILayout.Button("↑", GUILayout.Width(30)))
                    {
                        SwapAttacks(script.attacks, i, i - 1);
                    }
                    GUILayout.EndHorizontal();
                }

                if(attackFetchLevel != script.stats.lvl)
                {
                    //BD fetch attacks
                    attackFetchLevel = script.stats.lvl;
                }

                GUILayout.Label("Attacks unlocked at level "+ script.stats.lvl +":", EditorStyles.boldLabel);
                attackScrollPos = GUILayout.BeginScrollView(attackScrollPos);

                for (int i = 0; i < avilableAttacks.Count; i++)
                {
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(new GUIContent(avilableAttacks[i].myName, avilableAttacks[i].description));
                    
                    if(GUILayout.Button("Add", GUILayout.Width(80)))
                    {
                        if(script.attacks.Count < 4)
                        {
                            script.attacks.Add(avilableAttacks[i]);
                        }
                    }

                    GUILayout.EndHorizontal();
                }

                GUILayout.EndScrollView();
            }
            else
            {
                if (GUILayout.Button("Get stats from level"))
                {
                    //script.stats = script.arkeonData.GetStatsFromBD(script.stats.lvl);
                }

                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Edit attacks", GUILayout.MinWidth(140)))
                {
                    editingAttacks = true;
                }
                if (GUILayout.Button("Save", GUILayout.Width(55)))
                {

                }
                if (GUILayout.Button("Cancle", GUILayout.Width(55)))
                {

                }

                GUILayout.EndHorizontal();
            }
        }

        void SwapAttacks(List<ArkeonAttack> _atk, int _id1, int _id2)
        {
            if (_atk.Count <= _id1 || _atk.Count <= _id2)
                return;

            ArkeonAttack temp = _atk[_id1];
            _atk[_id1] = _atk[_id2];
            _atk[_id2] = temp;
        }
    }
}
