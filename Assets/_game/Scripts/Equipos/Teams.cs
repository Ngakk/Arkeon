using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Equipos;

public class Teams : MonoBehaviour
{
    public TeamManager manager;
    
    public List<Transform> Positions = new List<Transform>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MostrarLuz()
    {
        for (int i = 0; i < manager.LibroLuz.Count; i++)
        {
            //Instantiate(manager.LibroLuz[i], Positions[i].position, Quaternion.identity);
            manager.LibroLuz[i].SetActive(true);
            manager.LibroLuz[i].transform.position = Positions[i].position;
        }
    }
}
