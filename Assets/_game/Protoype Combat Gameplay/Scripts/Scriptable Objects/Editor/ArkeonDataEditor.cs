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

        showStats = EditorGUILayout.Foldout(showStats, "Base stats:");
        if(showStats)
        {
            s.baseStats.hp = EditorGUILayout.IntField("HP:", s.baseStats.hp);
            s.baseStats.atk = EditorGUILayout.IntField("ATK:", s.baseStats.atk);
            s.baseStats.def = EditorGUILayout.IntField("DEF:", s.baseStats.def);
            s.baseStats.cost = EditorGUILayout.IntField("COST:", s.baseStats.cost);
        }
    }
}
