﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace ArkeonBattle
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
            NOT_TURN,
            ITEM
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
            EditorGUILayout.LabelField("HP: ", myScript.player.currentHp.ToString());
            EditorGUILayout.LabelField("MP: ", myScript.player.currentMp.ToString());

            CharacterOptions(myScript.player, ref allyState, ref enemyState, ref allyChosen);

            EditorGUILayout.LabelField("Enemy options", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("HP: ", myScript.enemy.currentHp.ToString());
            EditorGUILayout.LabelField("MP: ", myScript.enemy.currentMp.ToString());
            
            CharacterOptions(myScript.enemy, ref enemyState, ref allyState, ref enemyChosen);

            //EditorGUI.DrawRect(new Rect(50, 500, 100, 70), Color.green);

            CharacterTeam(myScript.player);
            CharacterTeam(myScript.enemy);
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
                    if(GUILayout.Button("Use Item"))
                    {
                        _state = State.ITEM;
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
                        if (GUILayout.Button("Invoke " + _chara.arkeonTeam[i].arkeonData.originalName + " (" + _chara.arkeonTeam[i].stats.cost + ")"))
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
                        if (GUILayout.Button("Attack with " + _chara.arkeonsOut[i].arkeon.myInstance.arkeonData.originalName))
                        {
                            if (_chara.ChooseAttacker(i))
                            {
                                _chosen = i;
                                _state = State.CHOOSING;
                            }
                        }
                    }
                    if (GUILayout.Button("Attack with " + _chara.familiar.arkeonData.originalName))
                    {
                        if(_chara.ChooseFamiliarAttacker())
                        {
                            _chosen = -1;
                            _state = State.CHOOSING;
                        }
                    }
                    if (GUILayout.Button("Go back"))
                    {
                        _state = State.TURN;
                    }
                    break;
                case State.CHOOSING:

                    PlayerCharacterBattle.ArkeonBattleStatus status = _chosen >= 0 ? _chara.arkeonsOut[_chosen] : _chara.familiarOut;

                    for (int i = 0; i < status.arkeon.myInstance.attacks.Count; i++)
                    {
                        if (GUILayout.Button(status.arkeon.myInstance.attacks[i].myName + " (" + status.arkeon.myInstance.attacks[i].cost + ")"))
                        {
                            if (_chara.CommandArkeonAttack(status, i))
                            {
                                if (status.arkeon.myInstance.attacks[i].targetsEnemy)
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
                        if (_chosen >= 0)
                            _chara.StepBackAttacker();
                        else
                            _chara.StepBackFamiliar();

                        _state = State.ATTACK;
                    }
                    break;
                case State.SHIELDING:
                    for (int i = 0; i < _chara.arkeonsOut.Count; i++)
                    {
                        if (GUILayout.Button("Block with " + _chara.arkeonsOut[i].arkeon.myInstance.arkeonData.originalName))
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
                    if(GUILayout.Button("Block with Familiar"))
                    {
                        if(_chara.CommandFamiliarShield())
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
                    if(GUILayout.Button("No block"))
                    {
                        if(_chara.CommandNoShield())
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
                    break;
                case State.NOT_TURN:
                    break;
                case State.WAITING:
                    if (GUILayout.Button("Stop waiting"))
                    {
                        _state = State.TURN;
                    }
                    break;
                case State.ITEM:
                    for(int i = 0; i < _chara.inventory.Count; i++)
                    {
                        if(GUILayout.Button(_chara.inventory.items[i].item.name))
                        {
                            returnToTurn = true;
                            _chara.UseItem(i);
                            _state = State.SHIELDING;
                        }
                    }
                    if(GUILayout.Button("Cancle"))
                    {
                        _state = State.TURN;
                    }
                    break;
            }
        }

        void CharacterTeam(PlayerCharacterBattle _chara)
        {
            string header = _chara.enemySide ? "Enemy team" : "Ally team";
            
            EditorGUILayout.LabelField(header, EditorStyles.boldLabel);
            if (_chara.familiarOut != null)
            {
                if (_chara.familiarOut.arkeon.myInstance.currentHp > 0)
                {
                    EditorGUILayout.LabelField("Familiar HP:", (_chara.familiar.currentHp + "/" + _chara.familiar.stats.maxHp));
                }
            }
            for (int i = 0; i < _chara.arkeonsOut.Count; i++)
            {
                EditorGUILayout.LabelField(_chara.arkeonsOut[i].arkeon.myInstance.myName + " HP:", (_chara.arkeonsOut[i].arkeon.myInstance.currentHp + "/" + _chara.arkeonsOut[i].arkeon.myInstance.stats.maxHp));
            }
        }
    }
}
