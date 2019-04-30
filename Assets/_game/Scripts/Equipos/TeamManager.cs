using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pokemon;

namespace Equipos
{
    public class TeamManager : MonoBehaviour
    {
        // Libros
        public List<GameObject> LibroLuz = new List<GameObject>();
        //public int PokeLuz;

        public List<GameObject> LibroOscuridad = new List<GameObject>();
        //public int PokeOscuro;

        public List<GameObject> LibroTierra = new List<GameObject>();
        //public int PokeTierra;

        // Pokemon que siempre esta con el jugador
        // Este wey no ocupa espacio en los libros
        public GameObject Familiar;

        // Equipo para la batalla
        public List<GameObject> EquipoCombate = new List<GameObject>();

        // Start is called before the first frame update
        void Start()
        {
            LibroLuz.Capacity = 3;
            LibroOscuridad.Capacity = 3;
            LibroTierra.Capacity = 3;

            EquipoCombate.Capacity = 9;
        }

        public void AgregarEquipo(GameObject Arkeon)
        {
            Debug.Log("Agregando");
            
            Poke poke = Arkeon.GetComponent<Poke>();

            if (poke.tipo == Poke.Tipos.Luz)
            {
                if (LibroLuz.Count < LibroLuz.Capacity)
                {
                    LibroLuz.Add(Arkeon);
                    EquipoCombate.Add(Arkeon);
                }
            }

            if (poke.tipo == Poke.Tipos.Oscuridad)
            {
                if (LibroOscuridad.Count < LibroOscuridad.Capacity)
                {
                    LibroOscuridad.Add(Arkeon);
                    EquipoCombate.Add(Arkeon);
                }
            }

            if (poke.tipo == Poke.Tipos.Tierra)
            {
                if (LibroTierra.Count < LibroTierra.Capacity)
                {
                    LibroTierra.Add(Arkeon);
                    EquipoCombate.Add(Arkeon);
                }
            }
        }
    }
    
}
