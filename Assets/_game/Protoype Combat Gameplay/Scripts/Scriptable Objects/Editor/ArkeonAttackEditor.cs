using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ArkeonBattle
{
    [CustomEditor(typeof(ArkeonAttack))]
    public class ArkeonAttackEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ArkeonAttack s = (ArkeonAttack)target;

            if(GUILayout.Button("Get info from database"))
            {
                s.GetInfoFromDatabase();
            }

            if(GUILayout.Button("Overwrite database's path of attack with id " + s.db_id))
            {
                Debug.Log("Button not implemented");
            }
        }
    }

    [CustomEditor(typeof(SimpleAttack))]
    public class SimpleAttackEditor : ArkeonAttackEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }

    [CustomEditor(typeof(SimpleHeal))]
    public class SimpleHealEditor : ArkeonAttackEditor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
}