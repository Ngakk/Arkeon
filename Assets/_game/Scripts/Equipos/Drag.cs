using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Equipos;

public class Drag : MonoBehaviour
{
    public Camera cam;

    public LayerMask mascara;

    public GameObject libro;

    bool Seleccionado = false;

    public GameObject PokeSeleccionado;

    TeamManager manager;

    Teams teams;

    Vector3 PosicionOriginal;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit hit;

            // Linea invisible que se lanzara en la posicion donde tocamos la pantalla
            Ray rayo = cam.ScreenPointToRay(Input.mousePosition);

            // Si el rayo colisiona con el objeto con el layer indicado
            if (Physics.Raycast(rayo, out hit, Mathf.Infinity, mascara))
            {
                if (Seleccionado == false)
                {
                    PokeSeleccionado = hit.collider.gameObject;
                    PosicionOriginal = hit.transform.position;
                }

                Seleccionado = true;

                Vector3 tmp = hit.transform.position;

                PokeSeleccionado.transform.position = new Vector3(hit.point.x, hit.point.y - 1, tmp.z);
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Seleccionado = false;

            PokeSeleccionado.transform.position = PosicionOriginal;

            PokeSeleccionado = null;
        }
    }

    void Agregar(GameObject ArkeonAgregado)
    {
        manager.AgregarEquipo(ArkeonAgregado);
        teams.MostrarTodos();
    }
}
