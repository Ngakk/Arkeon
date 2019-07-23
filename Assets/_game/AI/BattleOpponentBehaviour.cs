using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArkeonBattle;

public class BattleOpponentBehaviour : MonoBehaviour
{
    BattleMenu_Main battleMenu;
    public PlayerCharacterBattle AI;
    public PlayerCharacterBattle player;

    public void SelectNextAction()
    {
        if (AI.arkeonsOut.Count > 0)
        {
            int action = Random.Range(0, 1);
            switch (action)
            {
                case 0:
                    SummonArkeon();
                    break;

                case 1:
                    SelectSummonedArkeon();
                    break;

                default:
                    Debug.Log("Invalid Action: " + action);
                    EndTurn();
                    break;
            }
        } else
        {
            SummonArkeon();
        }
    }

    public void SummonArkeon()
    {
        int ark = Random.Range(0, AI.arkeonTeam.Count);
        AI.InvokeArkeon(ark);
        SelectNextAction();
    }

    public void SelectSummonedArkeon()
    {
        int ark = Random.Range(0, AI.arkeonsOut.Count);
        AI.ChooseAttacker(ark);
        SelectAttack(ark);
    }

    public void SelectAttack(int _ark)
    {
        int atk = Random.Range(0, AI.arkeonsOut[_ark].arkeon.myInstance.attacks.Count);

        if(AI.CommandArkeonAttack(AI.arkeonsOut[_ark], atk))
        {
            switch (AI.arkeonsOut[_ark].arkeon.myInstance.attacks[atk].targetType)
            {
                case AttackTargets.SELF:
                    AI.CommandArkeonShield(_ark);
                    break;

                case AttackTargets.NON_TARGETED_ENEMY:
                    Wait();
                    break;

                case AttackTargets.TARGETED_ALLY:
                    SelectTarget();
                    break;

                case AttackTargets.TARGETED_ALLY_OR_ENEMY:
                    SelectTarget();
                    break;

                case AttackTargets.TARGETED_ENEMY:
                    SelectTarget();
                    break;
            }
        }
        
    }

    public void SelectTarget()
    {
        
        SelectNextAction();
    }

    public void Shield()
    {
        SelectNextAction();
    }

    public void Wait()
    {
        // Wait for player action
    }

    public void EndTurn()
    {
        Debug.Log("Ended Turn");
        ManagerStaticBattle.battleManager.ChangeTurns();
    }
}
