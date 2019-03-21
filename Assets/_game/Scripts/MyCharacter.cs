using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

[RequireComponent(typeof(Rigidbody))]
public class MyCharacter : MonoBehaviour 
{
    [SerializeField]
    private int playerID = 0;
    [SerializeField]
    private float moveSpeed= 2.5f;
    private bool direction; // true = left
    [SerializeField]
    private Camera Mcamera;
    private Player player;
    private Rigidbody cc;
    private Vector3 moveVector;

    private void Awake() {
        player = ReInput.players.GetPlayer(playerID);

        cc = GetComponent<Rigidbody>();
    }

	
	// Update is called once per frame
	void Update () {
        GetInput();
        ProcessInput();
        Mcamera.transform.position = new Vector3(transform.position.x, Mcamera.transform.position.y, transform.position.z);
	}

    private void GetInput() {
        moveVector.x = player.GetAxis("Move Horizontal");
        moveVector.z = player.GetAxis("Move Vertical");
    }

    private void ProcessInput() {
        if(moveVector.x != 0.0f || moveVector.z != 0.0f)
        {
            cc.velocity = moveVector * moveSpeed;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Pokemon>() != null)
        {
            Destroy(col.gameObject);
        }
    }

    
}
