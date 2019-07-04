using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ArkeonBattle
{
    [CustomEditor(typeof(ArkeonElement))]
    public class ArkeonElementEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ArkeonElement s = (ArkeonElement)target;

            if(GUILayout.Button("Overwrite database's path for element with id " + s.db_id))
            {

            }

            if(GUILayout.Button("Add this element to database"))
            {

            }
        }
    }
}