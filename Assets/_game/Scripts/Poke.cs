using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Ataque;
using Equipos;

namespace Pokemon
{
    public class Poke : MonoBehaviour
    {
        public string Nombre;
        public int vidaMax;
        public int vida;
        public int nivel;
        
        public Tipos tipo;
        
        public TeamManager manager;

        public Teams teams;

        private bool Seleccionado = false;
        
        public GameObject Libro;

        public LayerMask mascaraLibro;

        private Vector3 originalPos;


        public enum Tipos
        {
            Luz,
            Oscuridad,
            Tierra
        };

        public Ataques[] LosAtaques;
        
        // Start is called before the first frame update
        void Start()
        {
            vida = vidaMax;
            
            Libro = GameObject.Find("Libro");

            manager = FindObjectOfType<TeamManager>();
            teams = FindObjectOfType<Teams>();

            originalPos = transform.position;

            /*Debug.Log("Nombre: " + Nombre);
            Debug.Log("Vida Maxima: " + vidaMax);
            Debug.Log("Vida: " + vida);
            Debug.Log("Nivel Actual: " + nivel);
            Debug.Log("Tipo: " + tipo);
            Debug.Log("Numero Ataques: " + LosAtaques.Length);
            for (int i = 0; i < LosAtaques.Length; i++)
            {
                int pos = i + 1;
                Debug.Log("Nombre Ataque " + pos + ": " + LosAtaques[i].nombre);
                Debug.Log("Daño Ataque " + pos + ": " + LosAtaques[i].daño);
                Debug.Log("Cantidad de usos Ataque " + pos + ": " + LosAtaques[i].cantidadUsos);
            }*/
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnMouseDrag()
        {
            Seleccionado = true;
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            point.z = 0;
            transform.position = point;
        }

        private void OnMouseUp()
        {
            if (Seleccionado)
            {
                RaycastHit hit;

                // Linea invisible que se lanzara en la posicion donde tocamos la pantalla
                Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);

                // Si el rayo colisiona con el objeto con el layer indicado
                if (Physics.Raycast(rayo, out hit, Mathf.Infinity, mascaraLibro))
                {
                    Agregar(gameObject);
                }
                else
                {
                    gameObject.transform.position = originalPos;
                }

                Seleccionado = false;
            }
        }

        void Agregar(GameObject ArkeonAgregado)
        {
            manager.AgregarEquipo(ArkeonAgregado);
            teams.MostrarTodos();
        }

    }
}