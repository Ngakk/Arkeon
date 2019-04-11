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
            manager.LibroLuz[i].SetActive(true);
            manager.LibroLuz[i].transform.position = Positions[i].position;
        }
        for (int i = 0; i < manager.LibroOscuridad.Count; i++)
        {
            manager.LibroOscuridad[i].SetActive(false);
        }
        
        for (int i = 0; i < manager.LibroTierra.Count; i++)
        {
            manager.LibroTierra[i].SetActive(false);
        }
        
    }
    
    public void MostrarOscuro()
    {
        for (int i = 0; i < manager.LibroOscuridad.Count; i++)
        {
            manager.LibroOscuridad[i].SetActive(true);
            manager.LibroOscuridad[i].transform.position = Positions[i].position;
        }
        
        for (int i = 0; i < manager.LibroLuz.Count; i++)
        {
            manager.LibroLuz[i].SetActive(false);
        }
        
        for (int i = 0; i < manager.LibroTierra.Count; i++)
        {
            manager.LibroTierra[i].SetActive(false);
        }
    }
    
    public void MostrarTierra()
    {
        for (int i = 0; i < manager.LibroTierra.Count; i++)
        {
            manager.LibroTierra[i].SetActive(true);
            manager.LibroTierra[i].transform.position = Positions[i].position;
        }
        
        for (int i = 0; i < manager.LibroLuz.Count; i++)
        {
            manager.LibroLuz[i].SetActive(false);
        }
        
        for (int i = 0; i < manager.LibroOscuridad.Count; i++)
        {
            manager.LibroOscuridad[i].SetActive(false);
        }
    }
}
