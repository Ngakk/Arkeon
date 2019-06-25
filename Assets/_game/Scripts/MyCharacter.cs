using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

[RequireComponent(typeof(Rigidbody))]
public class MyCharacter : MonoBehaviour 
{
    public GameObject playerModel;
    [SerializeField]
    private int playerID = 0;
    [SerializeField]
    private float moveSpeed= 2.5f;
    private bool direction; // true = left
    [SerializeField]
    private Camera mainCamera;
    private Player player;
    private Rigidbody cc;
    private Vector3 moveVector;
    private Vector3 rotationVector;
    private float AnguloR;

    private void Awake() {
        player = ReInput.players.GetPlayer(playerID);

        cc = GetComponent<Rigidbody>();
    }

	
	// Update is called once per frame
	void Update () {
        GetInput();
        ProcessInput();
        mainCamera.transform.position = new Vector3(transform.position.x, mainCamera.transform.position.y, transform.position.z);
	}

    private void GetInput() {
        rotationVector.x = moveVector.x = player.GetAxis("Move Horizontal");
        rotationVector.z = moveVector.z = player.GetAxis("Move Vertical");
    }

    private void ProcessInput() {
        if(moveVector.x != 0.0f || moveVector.z != 0.0f)
        {
            cc.velocity = moveVector * moveSpeed;
            //if(rotationVector.)
            AnguloR = Mathf.Atan2 (rotationVector.x, rotationVector.z) * Mathf.Rad2Deg;
        }
        if(moveVector.x == 0.0f && moveVector.z == 0.0f)
        {
            cc.velocity = Vector3.zero;
        }
        playerModel.transform.localRotation = Quaternion.AngleAxis (AnguloR, Vector3.up);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Pokemon>() != null)
        {
            Destroy(col.gameObject);
        }
    }

    
}
