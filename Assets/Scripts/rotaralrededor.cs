using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using UnityEngine;

public class rotaralrededor : MonoBehaviour
{
    public float VelocidadRotacion = 50f;
    public Transform referencia;
    // Start is called before the first frame update
    void Start()
    {
    }
    

    // Update is called once per frame
    void Update()
    {
        //transform de este objeto( donde apunta,donde se mueve,velocidad
    this.transform.RotateAround(referencia.transform.position, Vector3.up, VelocidadRotacion * Time.deltaTime);
    }
}
