using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ataque
{
    [System.Serializable]
    public class Ataques
    {
        enum TipoAtaque
        {
            Luz,
            Oscuridad,
            Tierra
        };

        public string nombre;
        public int cantidadUsos;
        public int daño;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}