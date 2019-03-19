using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonBase : MonoBehaviour {

    [SerializeField]
    private Sprite[] PossiblePokes;
    protected float speed = 2.35f;
    protected SpriteRenderer Srenderer;
    //This would usually get all the creature's shit like life stats and stuff.

    protected virtual void Init()
    {
        float localScaleFactor = 1.7f;
        Srenderer = GetComponent<SpriteRenderer>();
        Srenderer.sprite = PossiblePokes[Random.Range(0, PossiblePokes.Length - 1)];
        transform.localScale = new Vector3(localScaleFactor, localScaleFactor, localScaleFactor);
    }

    public static Quaternion GetRotation()
    {
        return Quaternion.Euler(65.25f, 0, 0);
    }

    protected virtual bool SeesPlayer()
    {
        return false;
    }
}
