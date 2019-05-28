using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Mangos
{
    [CustomEditor(typeof(InputSimulatorTesting))]
    public class InputSimulatorTestingEditor : Editor
    {
        enum State
        {
            TURN,
            SUMMON,
            ATTACK,
            CHOOSING,
            WAITING,
            SHIELDING,
            NOT_TURN
        }

        State allyState = State.TURN, enemyState = State.NOT_TURN;

        int allyChosen = 0, enemyChosen = 0;

        public override void OnInspectorGUI()
        {

            DrawDefaultInspector();

            InputSimulatorTesting myScript = (InputSimulatorTesting)target;

            EditorGUILayout.LabelField("Ally", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("HP: ", myScript.player.HP.ToString());
            EditorGUILayout.LabelField("MP: ", myScript.player.MP.ToString());

            switch (allyState)
            {
                case State.TURN:
                    if (GUILayout.Button("Summon"))
                    {
                        allyState = State.SUMMON;
                    }
                    if (GUILayout.Button("Attack"))
                    {
                        allyState = State.ATTACK;
                    }
                    if (GUILayout.Button("End turn"))
                    {
                        allyState = State.NOT_TURN;
                        enemyState = State.TURN;
                    }
                    break;
                case State.SUMMON:
                    for(int i = 0; i < myScript.player.arkeonTeam.Count; i++)
                    {
                        if(GUILayout.Button("Invoke " + myScript.player.arkeonTeam[i].Name))
                        {
                            myScript.player.InvokeArkeon(i);
                        }
                    }
                    if (GUILayout.Button("Go back"))
                    {
                        allyState = State.TURN;
                    }
                    break;
                case State.ATTACK:
                    for (int i = 0; i < myScript.player.arkeonsOut.Count; i++)
                    {
                        if (GUILayout.Button("Attack with " + myScript.player.arkeonsOut[i].arkeon.spirit.Name))
                        {
                            myScript.player.ChooseAttacker(i);
                            allyChosen = i;
                            allyState = State.CHOOSING;
                        }
                    }
                    if (GUILayout.Button("Go back"))
                    {
                        allyState = State.TURN;
                    }
                    break;
                case State.CHOOSING:
                    if (myScript.player.arkeonsOut.Count == 0) break;
                    for (int i = 0; i < myScript.player.arkeonsOut[allyChosen].arkeon.spirit.attacks.Count; i++)
                    {
                        if (GUILayout.Button(myScript.player.arkeonsOut[allyChosen].arkeon.spirit.attacks[i].myName))
                        {
                            myScript.player.CommandArkeonAttack(allyChosen, i);
                            allyState = State.WAITING;
                            enemyState = State.SHIELDING;
                        }
                    }
                    break;
                case State.SHIELDING:
                    for (int i = 0; i < myScript.player.arkeonsOut.Count; i++)
                    {
                        if (GUILayout.Button("Block with " + myScript.player.arkeonsOut[i].arkeon.spirit.Name))
                        {
                            myScript.player.CommandArkeonShield(i);
                            allyState = State.NOT_TURN;
                        }
                    }
                    break;
                case State.NOT_TURN:
                    break;
                case State.WAITING:
                    if(GUILayout.Button("Stop waiting"))
                    {
                        allyState = State.TURN;
                    }
                    break;
            }

            EditorGUILayout.LabelField("Enemy options", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("HP: ", myScript.enemy.HP.ToString());
            EditorGUILayout.LabelField("MP: ", myScript.enemy.MP.ToString());

            switch (enemyState)
            {
                case State.TURN:
                    if (GUILayout.Button("Summon"))
                    {
                        enemyState = State.SUMMON;
                    }
                    if (GUILayout.Button("Attack"))
                    {
                        enemyState = State.ATTACK;
                    }
                    if (GUILayout.Button("End turn"))
                    {
                        enemyState = State.NOT_TURN;
                        allyState = State.TURN;
                    }
                    break;
                case State.SUMMON:
                    for (int i = 0; i < myScript.enemy.arkeonTeam.Count; i++)
                    {
                        if (GUILayout.Button("Invoke " + myScript.enemy.arkeonTeam[i].Name))
                        {
                            myScript.enemy.InvokeArkeon(i);
                        }
                    }
                    if (GUILayout.Button("Go back"))
                    {
                        enemyState = State.TURN;
                    }
                    break;
                case State.ATTACK:
                    for (int i = 0; i < myScript.enemy.arkeonsOut.Count; i++)
                    {
                        if (GUILayout.Button("Attack with " + myScript.enemy.arkeonsOut[i].arkeon.spirit.Name))
                        {
                            myScript.enemy.ChooseAttacker(i);
                            enemyChosen = i;
                            enemyState = State.CHOOSING;
                        }
                    }
                    if (GUILayout.Button("Go back"))
                    {
                        enemyState = State.TURN;
                    }
                    break;
                case State.CHOOSING:
                    if (myScript.enemy.arkeonsOut.Count == 0) break;
                    for (int i = 0; i < myScript.enemy.arkeonsOut[enemyChosen].arkeon.spirit.attacks.Count; i++)
                    {
                        if (GUILayout.Button(myScript.enemy.arkeonsOut[enemyChosen].arkeon.spirit.attacks[i].myName))
                        {
                            myScript.enemy.CommandArkeonAttack(enemyChosen, i);
                            enemyState = State.WAITING;
                            allyState = State.SHIELDING;
                        }
                    }
                    break;
                case State.SHIELDING:
                    for (int i = 0; i < myScript.enemy.arkeonsOut.Count; i++)
                    {
                        if (GUILayout.Button("Block with " + myScript.enemy.arkeonsOut[i].arkeon.spirit.Name))
                        {
                            myScript.enemy.CommandArkeonShield(i);
                            enemyState = State.NOT_TURN;
                        }
                    }
                    break;
                case State.NOT_TURN:
                    break;
                case State.WAITING:
                    if (GUILayout.Button("Stop waiting"))
                    {
                        enemyState = State.TURN;
                    }
                    break;
            }
        }
    }
}