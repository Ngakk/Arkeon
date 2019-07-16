using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    GameObject[] PokePrefab;
    const int MaxNumber = 5;
    bool isSpawning;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < MaxNumber; i++) //We always start w/MaxNumber of pkm on screen
        {
            StartCoroutine(InstantiatePoke(false));
        }
	}

    public void RequestSpawn() // Attempt to spawn but checks max number and also may not respawn
    {
        if (FindObjectsOfType<PokemonBase>().Length >= MaxNumber)
        {
            isSpawning = false;
            return;
        }
            

        int n = Random.Range(0, 100); // 50% change wont it spawn nothin'
        if (n > 50)
        {
            isSpawning = false;
            return;
        }

        StartCoroutine(InstantiatePoke());
    }

    IEnumerator InstantiatePoke(bool wait = true) //Waits a lil and then spawns
    {
        yield return new WaitForSeconds(wait ? 1.3f : 0f); //We wait a lil (nullable for first instances)
        Instantiate(PokePrefab[SelectPrefabType()], new Vector3(Random.Range(-6f, 7f), 0.41f, Random.Range(-6f, 0)), PokemonBase.GetRotation());
        isSpawning = false;
    }

    int SelectPrefabType() //Selects index of which prefab will be instantiated
    {
        int n = Random.Range(0, 100);
        return n < 15 ? 1 : 0; // this means 15% chance of spawning an attkr
    }
	
	// Update is called once per frame
	void Update () {
        if (isSpawning) return;
		if (FindObjectsOfType<PokemonBase>().Length < MaxNumber)
        {
            isSpawning = true;
            RequestSpawn();
        }
	}
    
}
