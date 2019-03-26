using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkeonAttack : MonoBehaviour
{
    /// <summary>
    /// What to do before the hit. Examples are incrementing stats
    /// </summary>
    public void PreHit()
    {

    }

    /// <summary>
    /// What to do when attack hits.
    /// </summary>
    public void OnHit()
    {
        
    }

    public void PostHit()
    {

    }

    /// <summary>
    /// Regresa el daño que se va hacer usando el ... TODO
    /// </summary>
    /// <param name="_atk"></param>
    /// <param name="_pwr"></param>
    /// <param name="_def"></param>
    /// <returns></returns>
    private int CalculateDamage(int _atk, int _pwr, int _def)
    {
        return (int)Mathf.Round((_atk * _pwr) / _def);
    }
}
