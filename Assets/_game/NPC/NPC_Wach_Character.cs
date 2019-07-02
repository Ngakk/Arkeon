using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Wach_Character : MonoBehaviour
{
    public GameObject characterObjective;
    public GameObject objectToRotate;
    public float speedRotation;
    Vector3 lookPos;
    Quaternion rotation;

    // Update is called once per frame
    /// <summary>El update se encarga de calcular la rotacion del objeto
    /// <para>Es parte de una formukla matemica en donde se tiene que convertir lor radianes obtenidos a el angulo relativo en el eje Y</para>
    /// </summary>
    void Update()
    {
        lookPos = characterObjective.transform.position - objectToRotate.transform.position;
        lookPos.y = 0;
        rotation = Quaternion.LookRotation(lookPos);
        objectToRotate.transform.localRotation = Quaternion.Slerp(objectToRotate.transform.localRotation, rotation, Time.deltaTime * speedRotation);
    }
}
