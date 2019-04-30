using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Equipos
{
    public class Teams : MonoBehaviour
    {
        public TeamManager manager;

        public List<Transform> PositionsLuz = new List<Transform>();
        public List<Transform> PositionsOscuro = new List<Transform>();
        public List<Transform> PositionsTierra = new List<Transform>();

        public void MostrarTodos()
        {
            MostrarLuz();
            MostrarOscuro();
            MostrarTierra();
        }

        public void MostrarLuz()
        {
            for (int i = 0; i < manager.LibroLuz.Count; i++)
            {
                manager.LibroLuz[i].SetActive(true);
                manager.LibroLuz[i].transform.position = PositionsLuz[i].position;
            }
        }

        public void MostrarOscuro()
        { 
            for (int i = 0; i < manager.LibroOscuridad.Count; i++)
            {
                manager.LibroOscuridad[i].SetActive(true);
                manager.LibroOscuridad[i].transform.position = PositionsOscuro[i].position;
            }
        }

        public void MostrarTierra()
        {
            for (int i = 0; i < manager.LibroTierra.Count; i++)
            {
                manager.LibroTierra[i].SetActive(true);
                manager.LibroTierra[i].transform.position = PositionsTierra[i].position;
            }
        }
    }
}
