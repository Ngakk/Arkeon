using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    // Libros
    public List<GameObject> LibroLuz = new List<GameObject>();
    public List<GameObject> LibroOscuridad = new List<GameObject>();
    public List<GameObject> LibroTierra = new List<GameObject>();
   
    // Pokemon que siempre esta con el jugador
    // Este wey no ocupa espacio en los libros
    public GameObject Familiar;

    // Equipo para la batalla
    private List<GameObject> EquipoCombate = new List<GameObject>();

    public Camera cam;
    public LayerMask mascara;

    // Start is called before the first frame update
    void Start()
    {
        LibroLuz.Capacity = 3;
        LibroOscuridad.Capacity = 3;
        LibroTierra.Capacity = 3;

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
                Debug.Log(hit.collider);

                if (LibroLuz.Count < 3)
                {
                    LibroLuz.Add(hit.collider.gameObject);
                    Debug.Log(LibroLuz);
                }
            }
        }
    }

    public void AgregarPoke(string NombreLibro)
    {
        if (NombreLibro == "Luz")
        {
            LibroLuz.Add(Familiar);
        }
        
        if (NombreLibro == "Oscuridad")
        {
            LibroOscuridad.Add(Familiar);
        }
        
        if (NombreLibro == "Tierra")
        {
            LibroTierra.Add(Familiar);
        }
    }
}
