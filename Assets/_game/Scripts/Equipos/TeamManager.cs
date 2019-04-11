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
        public int PokeLuz;

        public List<GameObject> LibroOscuridad = new List<GameObject>();
        public int PokeOscuro;

        public List<GameObject> LibroTierra = new List<GameObject>();
        public int PokeTierra;

        // Pokemon que siempre esta con el jugador
        // Este wey no ocupa espacio en los libros
        public GameObject Familiar;

        // Equipo para la batalla
        public List<GameObject> EquipoCombate = new List<GameObject>();

        public Camera cam;
        public LayerMask mascara;

    // Start is called before the first frame update
        void Start()
        {
            LibroLuz.Capacity = PokeLuz;
            LibroOscuridad.Capacity = PokeOscuro;
            LibroTierra.Capacity = PokeTierra;

            EquipoCombate.Capacity = 9;

            cam = Camera.main;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                RaycastHit hit;

                // Linea invisible que se lanzara en la posicion donde tocamos la pantalla
                Ray rayo = cam.ScreenPointToRay(Input.mousePosition);

                // Si el rayo colisiona con el objeto con el layer indicado
                if (Physics.Raycast(rayo, out hit, Mathf.Infinity, mascara))
                {
                    Poke elPoke = hit.collider.gameObject.GetComponent<Poke>();
                    
                    if (elPoke.tipo == Poke.Tipos.Luz)
                    {
                        if (LibroLuz.Count < LibroLuz.Capacity)
                        {
                            LibroLuz.Add(hit.collider.gameObject);
                            EquipoCombate.Add(hit.collider.gameObject);
                            hit.collider.gameObject.SetActive(false);
                        }
                    }
                    
                    if (elPoke.tipo == Poke.Tipos.Oscuridad)
                    {
                        if (LibroOscuridad.Count < LibroOscuridad.Capacity)
                        {
                            LibroOscuridad.Add(hit.collider.gameObject);
                            EquipoCombate.Add(hit.collider.gameObject);
                            hit.collider.gameObject.SetActive(false);
                        }
                    }
                    
                    if (elPoke.tipo == Poke.Tipos.Tierra)
                    {
                        if (LibroTierra.Count < LibroTierra.Capacity)
                        {
                            LibroTierra.Add(hit.collider.gameObject);
                            EquipoCombate.Add(hit.collider.gameObject);
                            hit.collider.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }
}
