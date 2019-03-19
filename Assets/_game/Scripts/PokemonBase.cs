using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonBase : MonoBehaviour {
    protected float speed = 2.35f;
    //This would usually get all the creature's shit like life stats and stuff.

    public static Quaternion GetRotation()
    {
        return Quaternion.Euler(65.25f, 0, 0);
    }

    protected virtual bool SeesPlayer()
    {
        return false;
    }

    protected virtual void Init() { } 
}
