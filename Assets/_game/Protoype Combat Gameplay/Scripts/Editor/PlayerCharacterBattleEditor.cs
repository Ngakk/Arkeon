using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Mangos
{
    [CustomEditor(typeof(PlayerCharacterBattle))]
    public class PlayerCharacterBattleEditor : Editor
    {
        public override void OnInspectorGUI()
        {

            DrawDefaultInspector();

            PlayerCharacterBattle myScript = (PlayerCharacterBattle)target;
            
            if(GUILayout.Button("Fully Heal team"))
            {
                for(int i = 0; i < myScript.arkeonTeam.Count; i++)
                {
                    myScript.arkeonTeam[i].stats.HP = myScript.arkeonTeam[i].stats.MaxHP;
                }
            }
        }
    }
}