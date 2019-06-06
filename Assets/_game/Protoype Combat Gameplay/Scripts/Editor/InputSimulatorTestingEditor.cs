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
        //1=2 //TODO hacer que se pueda curar a si mismo el picashu
        State allyState = State.TURN, enemyState = State.NOT_TURN;

        int allyChosen = 0, enemyChosen = 0;
        bool returnToTurn = false;

        public override void OnInspectorGUI()
        {

            DrawDefaultInspector();

            InputSimulatorTesting myScript = (InputSimulatorTesting)target;

            EditorGUILayout.LabelField("Ally options", EditorStyles.boldLabel);
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
                        ManagerStaticBattle.battleManager.ChangeTurns();
                    }
                    break;
                case State.SUMMON:
                    for(int i = 0; i < myScript.player.arkeonTeam.Count; i++)
                    {
                        if(GUILayout.Button("Invoke " + myScript.player.arkeonTeam[i].Name + " (" + myScript.player.arkeonTeam[i].stats.Cost + ")"))
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
                        if (GUILayout.Button(myScript.player.arkeonsOut[allyChosen].arkeon.spirit.attacks[i].myName + " (" + myScript.player.arkeonsOut[allyChosen].arkeon.spirit.attacks[i].cost + ")"))
                        {
                            myScript.player.CommandArkeonAttack(allyChosen, i);
                            if (myScript.player.arkeonsOut[allyChosen].arkeon.spirit.attacks[i].targetsEnemy)
                            {
                                allyState = State.WAITING;
                                enemyState = State.SHIELDING;
                            }
                            else
                            {
                                allyState = State.SHIELDING;
                                returnToTurn = true;
                            }
                        }
                    }
                    if (GUILayout.Button("Cancle"))
                    {
                        myScript.player.StepBackAttacker();
                        allyState = State.ATTACK;
                    }
                    break;
                case State.SHIELDING:
                    for (int i = 0; i < myScript.player.arkeonsOut.Count; i++)
                    {
                        if (GUILayout.Button("Block with " + myScript.player.arkeonsOut[i].arkeon.spirit.Name))
                        {
                            myScript.player.CommandArkeonShield(i);
                            if (!returnToTurn)
                            {
                                allyState = State.NOT_TURN;
                            }
                            else
                            {
                                allyState = State.TURN;
                                returnToTurn = false;
                            }
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
                        ManagerStaticBattle.battleManager.ChangeTurns();
                    }
                    break;
                case State.SUMMON:
                    for (int i = 0; i < myScript.enemy.arkeonTeam.Count; i++)
                    {
                        if (GUILayout.Button("Invoke " + myScript.enemy.arkeonTeam[i].Name + " (" + myScript.player.arkeonTeam[i].stats.Cost + ")"))
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
                            Debug.Log("Enemy chosen = " + i);
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
                    Debug.Log("CHOOSING with enemy " + enemyChosen + ", attack count: " + myScript.enemy.arkeonsOut[enemyChosen].arkeon.spirit.attacks.Count);
                    for (int i = 0; i < myScript.enemy.arkeonsOut[enemyChosen].arkeon.spirit.attacks.Count; i++)
                    {
                        Debug.Log("Creating button " + i);
                        if (GUILayout.Button(myScript.enemy.arkeonsOut[enemyChosen].arkeon.spirit.attacks[i].myName + " (" + myScript.enemy.arkeonsOut[enemyChosen].arkeon.spirit.attacks[i].cost + ")"))
                        {
                            myScript.enemy.CommandArkeonAttack(enemyChosen, i);

                            if (myScript.enemy.arkeonsOut[enemyChosen].arkeon.spirit.attacks[i].targetsEnemy)
                            {
                                enemyState = State.WAITING;
                                allyState = State.SHIELDING;
                            }
                            else
                            {
                                enemyState = State.SHIELDING;
                                returnToTurn = true;
                            }
                        }
                    }
                    if(GUILayout.Button("Cancle"))
                    {
                        myScript.enemy.StepBackAttacker();
                        enemyState = State.ATTACK;
                    }
                    break;
                case State.SHIELDING:
                    for (int i = 0; i < myScript.enemy.arkeonsOut.Count; i++)
                    {
                        if (GUILayout.Button("Block with " + myScript.enemy.arkeonsOut[i].arkeon.spirit.Name))
                        {
                            myScript.enemy.CommandArkeonShield(i);
                            if (!returnToTurn)
                            {
                                enemyState = State.NOT_TURN;
                            }
                            else
                            {
                                enemyState = State.TURN;
                                returnToTurn = false;
                            }
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

            EditorGUILayout.LabelField("Ally team", EditorStyles.boldLabel);
            for (int i = 0; i < myScript.player.arkeonsOut.Count; i++)
            {
                EditorGUILayout.LabelField(myScript.player.arkeonsOut[i].arkeon.spirit.Name + " HP: ", myScript.player.arkeonsOut[i].arkeon.spirit.stats.HP.ToString() + "/" + myScript.player.arkeonsOut[i].arkeon.spirit.stats.MaxHP.ToString());
            }

            EditorGUILayout.LabelField("Enemy team", EditorStyles.boldLabel);
            for (int i = 0; i < myScript.enemy.arkeonsOut.Count; i++)
            {
                EditorGUILayout.LabelField(myScript.enemy.arkeonsOut[i].arkeon.spirit.Name + " HP: ", myScript.enemy.arkeonsOut[i].arkeon.spirit.stats.HP.ToString() + "/" + myScript.enemy.arkeonsOut[i].arkeon.spirit.stats.MaxHP.ToString());
            }

            //EditorGUI.DrawRect(new Rect(50, 500, 100, 70), Color.green);
        }
    }
}