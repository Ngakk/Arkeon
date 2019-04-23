using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public Camera cam;

    public LayerMask mascara;

    bool Seleccionado = false;

    public GameObject PokeSeleccionado;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Seleccionado == false)
            {
                RaycastHit hit;

                // Linea invisible que se lanzara en la posicion donde tocamos la pantalla
                Ray rayo = cam.ScreenPointToRay(Input.mousePosition);

                // Si el rayo colisiona con el objeto con el layer indicado
                if (Physics.Raycast(rayo, out hit, Mathf.Infinity, mascara))
                {
                    Seleccionado = true;
                    /*Vector3 tmp = hit.transform.position;
                    hit.collider.transform.position = new Vector3(hit.point.x, hit.point.y, tmp.z);*/
                    PokeSeleccionado = hit.collider.gameObject;
                }
            }
        }

        if(Seleccionado == true)
        {
            Vector3 tmp = PokeSeleccionado.transform.position;

            PokeSeleccionado.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, tmp.z);
        }
        
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            Seleccionado = false;
        }

    }
}
