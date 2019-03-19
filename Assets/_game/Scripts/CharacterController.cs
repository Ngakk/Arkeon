using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {

    private float speed = 2.5f;
    private bool direction; // true = left
    [SerializeField]
    private Camera Mcamera;
    SpriteRenderer srenderer;

	// Use this for initialization
	void Start () {
        srenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //Get horizontal axis. This is for movement and sprite direction
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        float deltaSpeed = Time.deltaTime * speed;

        transform.Translate(horizontalAxis * deltaSpeed, 0, verticalAxis * deltaSpeed, Space.World);
        Mcamera.transform.Translate(horizontalAxis * deltaSpeed, 0, verticalAxis * deltaSpeed, Space.World);

        if (horizontalAxis > 0)
            srenderer.flipX = true;
        else if (horizontalAxis < 0)
            srenderer.flipX = false;
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<Pokemon>() != null)
        {
            Destroy(col.gameObject);
        }
    }

    
}
