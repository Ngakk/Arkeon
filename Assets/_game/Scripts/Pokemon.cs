using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pokemon : PokemonBase {
    protected float timeToChangeDirection;
    protected float wanderingTime = 1.0f;
    protected Vector3 newDirection;

    // Use this for initialization
    public void Start()
    {
        Init();
        ChangeDirection();
    }

    // Update is called once per frame
    public void Update()
    {
        if (!SeesPlayer())
        {
            timeToChangeDirection -= Time.deltaTime;

            if (timeToChangeDirection <= 0)
            {
                ChangeDirection();
            }
        }
        else
            GoToPlayer();
        transform.Translate(newDirection * Time.deltaTime * speed, Space.World);

        if (newDirection.x > 0)
            Srenderer.flipX = true;
        else if (newDirection.x < 0)
            Srenderer.flipX = false;
    }

    protected virtual void GoToPlayer()
    {

    }

    protected void ChangeDirection()
    {
        newDirection = new Vector3(Random.Range(-0.8f, 0.8f), 0, Random.Range(-0.8f, 0.8f));
        timeToChangeDirection = wanderingTime;
    }
}
