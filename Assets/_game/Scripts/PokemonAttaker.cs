using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonAttaker : Pokemon {
    private MyCharacter player;
    private Material mat;

    protected override void Init()
    {
        player = FindObjectOfType<MyCharacter>();
        mat = GetComponent<MeshRenderer>().material;
    }

    protected override bool SeesPlayer()
    {
        bool isClose = Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) < 3;
        mat.color = isClose ? Color.red : Color.blue;
        return isClose;
    }

    protected override void GoToPlayer()
    {
        newDirection = (player.transform.position - transform.position).normalized;
    }
}
