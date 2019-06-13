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

            CharacterOptions(myScript.player, ref allyState, ref enemyState, ref allyChosen);

            EditorGUILayout.LabelField("Enemy options", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("HP: ", myScript.enemy.HP.ToString());
            EditorGUILayout.LabelField("MP: ", myScript.enemy.MP.ToString());
            
            CharacterOptions(myScript.enemy, ref enemyState, ref allyState, ref enemyChosen);

            //EditorGUI.DrawRect(new Rect(50, 500, 100, 70), Color.green);
        }



        void CharacterOptions(PlayerCharacterBattle _chara, ref State _state, ref State _enemyState, ref int _chosen)
        {
            switch (_state)
            {
                case State.TURN:
                    if (GUILayout.Button("Summon"))
                    {
                        _state = State.SUMMON;
                    }
                    if (GUILayout.Button("Attack"))
                    {
                        _state = State.ATTACK;
                    }
                    if (GUILayout.Button("End turn"))
                    {
                        _state = State.NOT_TURN;
                        _enemyState = State.TURN;
                        ManagerStaticBattle.battleManager.ChangeTurns();
                    }
                    break;
                case State.SUMMON:
                    for (int i = 0; i < _chara.arkeonTeam.Count; i++)
                    {
                        if (GUILayout.Button("Invoke " + _chara.arkeonTeam[i].originalName + " (" + _chara.arkeonTeam[i].stats.Cost + ")"))
                        {
                            if (_chara.InvokeArkeon(i))
                            {
                                _state = State.TURN;
                            }
                        }
                    }
                    if (GUILayout.Button("Go back"))
                    {
                        _state = State.TURN;
                    }
                    break;
                case State.ATTACK:
                    for (int i = 0; i < _chara.arkeonsOut.Count; i++)
                    {
                        if (GUILayout.Button("Attack with " + _chara.arkeonsOut[i].arkeon.spirit.originalName))
                        {
                            if (_chara.ChooseAttacker(i))
                            {
                                _chosen = i;
                                _state = State.CHOOSING;
                            }
                        }
                    }
                    if (GUILayout.Button("Go back"))
                    {
                        _state = State.TURN;
                    }
                    break;
                case State.CHOOSING:
                    if (_chara.arkeonsOut.Count == 0) break;
                    for (int i = 0; i < _chara.arkeonsOut[_chosen].arkeon.spirit.attacks.Count; i++)
                    {
                        if (GUILayout.Button(_chara.arkeonsOut[_chosen].arkeon.spirit.attacks[i].myName + " (" + _chara.arkeonsOut[_chosen].arkeon.spirit.attacks[i].cost + ")"))
                        {
                            if (_chara.CommandArkeonAttack(_chosen, i))
                            {
                                if (_chara.arkeonsOut[_chosen].arkeon.spirit.attacks[i].targetsEnemy)
                                {
                                    _state = State.WAITING;
                                    _enemyState = State.SHIELDING;
                                }
                                else
                                {
                                    _state = State.SHIELDING;
                                    returnToTurn = true;
                                }
                            }
                        }
                    }
                    if (GUILayout.Button("Cancle"))
                    {
                        _chara.StepBackAttacker();
                        _state = State.ATTACK;
                    }
                    break;
                case State.SHIELDING:
                    for (int i = 0; i < _chara.arkeonsOut.Count; i++)
                    {
                        if (GUILayout.Button("Block with " + _chara.arkeonsOut[i].arkeon.spirit.originalName))
                        {
                            if (_chara.CommandArkeonShield(i))
                            {
                                if (!returnToTurn)
                                {
                                    _state = State.NOT_TURN;
                                }
                                else
                                {
                                    _state = State.TURN;
                                    returnToTurn = false;
                                }
                            }
                        }
                    }
                    break;
                case State.NOT_TURN:
                    break;
                case State.WAITING:
                    if (GUILayout.Button("Stop waiting"))
                    {
                        _state = State.TURN;
                    }
                    break;
            }
        }

    }
}