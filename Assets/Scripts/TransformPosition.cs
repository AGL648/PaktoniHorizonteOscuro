using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPosition : MonoBehaviour
{
    public GameObject camara;
    public GameObject pared;
    public GameObject mazmorra;
    public GameObject enemigos;
    public GameObject Jefe;
    public GameObject Checkpoint;
    Vector3 PuntoReaparicion;
    public Protagonista protagonista;
    public Camara procamara;

    void Start()
    {
        PuntoReaparicion = gameObject.transform.position;
    }

    /*void Update()
    {
        if
    }*/

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pasadizo")
        {
            transform.position = new Vector3(30, -3.5f, -26.72f);
            //camara.position = new Vector3(24.77f, -3.49f, -26.92f);
        }
        if (other.gameObject.tag == "CambioCamara")
        {
            camara.SetActive(true);
            pared.SetActive(true);
            mazmorra.SetActive(false);
            enemigos.SetActive(false);
            protagonista.Camara = camara.transform;

            // accede a la camara y lo cambia de lugar en script camara del protagonista
        }
    }

    
}
