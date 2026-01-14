using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class texturamoviendose : MonoBehaviour
{
    public float velocidad;
    private MeshRenderer imagenFondo;
    // Start is called before the first frame update
    void Start()
    {
        imagenFondo = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        imagenFondo.material.mainTextureOffset = new Vector3(Time.time * velocidad *  -1f,   0f, 0f);
        //time.time el momento que empieza el fotograma x velocidad 
        // basicamente lo que cambia es el offset donde empieza a dibujar la textura
    }
}
