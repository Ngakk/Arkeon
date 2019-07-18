using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using ArkeonBattle;

[CustomEditor(typeof(ArkeonData))]
public class ArkeonDataEditor : Editor
{
    bool showStats = false;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ArkeonData s = (ArkeonData)target;

        /*showStats = EditorGUILayout.Foldout(showStats, "Base stats:");
        if(showStats)
        {
            EditorGUILayout.PrefixLabel("HP");
            s.baseStats.hp = EditorGUILayout.IntField(s.baseStats.hp);
            EditorGUILayout.PrefixLabel("ATK");
            s.baseStats.atk = EditorGUILayout.IntField(s.baseStats.atk);
            EditorGUILayout.PrefixLabel("DEF");
            s.baseStats.def = EditorGUILayout.IntField(s.baseStats.def);
            EditorGUILayout.PrefixLabel("Cost");
            s.baseStats.cost = EditorGUILayout.IntField(s.baseStats.cost);
        }*/
    }
}
