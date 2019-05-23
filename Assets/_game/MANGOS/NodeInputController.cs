using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class NodeInputController : MonoBehaviour
{

    public Stack stack;
    public GameObject[] touchbuttons;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToStack(string button)
    {
        Debug.Log(button);
    }


    public void StartChain(GameObject startingButton)
    {

    }


}
