using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    [SerializeField]
    private float speed = 2.5f;
    private bool direction; // true = left
    [SerializeField]
    private Camera Mcamera;
	
	// Update is called once per frame
	void Update () {
        //Get horizontal axis. This is for movement and sprite direction
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        float deltaSpeed = Time.deltaTime * speed;

        transform.Translate(horizontalAxis * deltaSpeed, 0, verticalAxis * deltaSpeed, Space.World);
        Mcamera.transform.Translate(horizontalAxis * deltaSpeed, 0, verticalAxis * deltaSpeed, Space.World);
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Pokemon>() != null)
        {
            Destroy(col.gameObject);
        }
    }

    
}
