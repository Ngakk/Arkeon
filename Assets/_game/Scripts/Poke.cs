using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Ataque;
using UnityEngine.Video;

namespace Pokemon
{
    public class Poke : MonoBehaviour
    {
        public string Nombre;
        public int vidaMax;
        public int vida;
        public int nivel;
        
        public Tipos tipo;

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
            
            /*Debug.Log("Nombre: " + Nombre);
            Debug.Log("Vida Maxima: " + vidaMax);
            Debug.Log("Vida: " + vida);
            Debug.Log("Nivel Actual: " + nivel);
            Debug.Log("Tipo: " + tipo);
            Debug.Log("Numero Ataques: " + LosAtaques.Length);*/
            for (int i = 0; i < LosAtaques.Length; i++)
            {
                int pos = i + 1;
                Debug.Log("Nombre Ataque " + pos + ": " + LosAtaques[i].nombre);
                Debug.Log("Daño Ataque " + pos + ": " + LosAtaques[i].daño);
                Debug.Log("Cantidad de usos Ataque " + pos + ": " + LosAtaques[i].cantidadUsos);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        public string GetNombre()
        {
            return Nombre;
        }

        public void SetNombre(string newNombre)
        {
            Nombre = newNombre;
        }

        
        
        
    }
}