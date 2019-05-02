using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaPointReference : MonoBehaviour
{
    public Transform AllyMain, AllyFamiliar, AllyRight, AllyCenter, AllyLeft, AllyFront, EnemyMain, EnemyFamiliar, EnemyRight, EnemyCenter, EnemyLeft, EnemyFront;

    /// <summary>
    /// Regresa el punto en el mundo respecto a si es aliado o enemigo y el numero de invocación que es. Regresa la posición del jugador si los valores estan mal.
    /// </summary>
    /// <param name="_team"></param>
    /// <param name="_invocation"></param>
    /// <returns></returns>
    public Transform GetInvokePoint(bool _ally, int _invocation)
    {
        if (_ally)
        {
            switch (_invocation)
            {
                case 0: return AllyCenter;
                case 1: return AllyRight;
                case 2: return AllyLeft;
            }
        }
        else
        {
            switch (_invocation)
            {
                case 0: return EnemyCenter;
                case 1: return EnemyRight;
                case 2: return EnemyLeft;
            }
        }

        return AllyMain;

    }
}
