using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonAttaker : Pokemon {
    private CharacterController player;

    protected override void Init()
    {
        base.Init();
        player = FindObjectOfType<CharacterController>();
    }

    protected override bool SeesPlayer()
    {
        bool isClose = Mathf.Abs(Vector3.Distance(transform.position, player.transform.position)) < 3;
        Srenderer.color = isClose ? Color.red : Color.white;
        return isClose;
    }

    protected override void GoToPlayer()
    {
        newDirection = (player.transform.position - transform.position).normalized;
    }
}
