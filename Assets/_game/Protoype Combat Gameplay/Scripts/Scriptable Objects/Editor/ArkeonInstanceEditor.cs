using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ArkeonBattle
{
    [CustomEditor(typeof(ArkeonInstance))]
    public class ArkeonInstanceEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ArkeonInstance script = (ArkeonInstance)target;
            
            if(GUILayout.Button("Get stats from level"))
            {
                //script.stats = script.arkeonData.GetStatsFromBD(script.stats.lvl);
            }

            GUILayout.BeginHorizontal();
            if(GUILayout.Button("Get attack from level", GUILayout.MinWidth(140)))
            {

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
}
