using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    private  GameObject []pared;
    Vector3 touchPosition;
    public Vector3 PosicionCamara;
    private  float distancia;
    public GameObject jugador;
    public Vector3 desplazamiento, rotacion;
    private int cam_camara;
    [Space(10,order =0)]
    [Tooltip("Configuracion 1 : Entrada: La camara no se mueve  sigue al personaje solo izquierda y derecha ///Configuracion 2 : interiores: por encima y persigue al personaje y cosas" +
        "//Configuracion 3: Jefes vista aerea // Configuracoin 4: Nada")]
    [Space(10, order = 1)]
    public TestEnum CamaraPosicion;
    public enum TestEnum {
        //Nombre de posición de cada cámara
        camPasilloJefe = 1,
        cam2=2,
        cam3=3,
        camNormal = 4
    }
 
    private void Start()
    {
    
    }
    private void Paredes()
    {
        //si el ray deja de tocar al jugador transparentar el objeto
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, distancia));
            transform.LookAt(touchPosition, Vector3.up);
        }
    }

  
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
       
        // https://docs.unity3d.com/es/530/ScriptReference/Vector3.Distance.html
        // calcular la distancia de entre los dos para que nunca sea distinta con el ray
        // cuando no sea la misma distancia hacer que sea la misma distancia
        // Hacer 2º opcion que es que coge todo el mapa y no se mueva la camara
        transform.position = jugador.transform.position + desplazamiento;
        transform.rotation = Quaternion.Euler(rotacion);
        //hacer una lista de paredes para transparentar
        //transform.rotation = jugador.transform.rotation + rotacion; // quaterion

        //mirar el cinemachine para la pared
       
        Ray ray = new Ray(transform.position, transform.forward);
         
        //hacer un lookat
        Debug.DrawRay(ray.origin, ray.direction * 30,Color.red);
        Camaras();
    }
    public void Camaras()
    {
        switch (CamaraPosicion)
        {
            case TestEnum.camPasilloJefe:
                Debug.Log("camara1");
                desplazamiento = new Vector3(6.25f, 0.86f, -1);
                rotacion = new Vector3(-7.5f, -80, 1);
                break;
            case TestEnum.cam2:
                desplazamiento = new Vector3(0, 10, -3);
                //rotacion = new Quaternion(45, 0, 0, 1);
                Debug.Log("camara2");
                break;
            case TestEnum.cam3:
                desplazamiento = new Vector3(0, 10, -7);
                Debug.Log("camara3");
                break;
            case TestEnum.camNormal:
                desplazamiento = new Vector3(4, 5, -4);
                rotacion = new Vector3(40, -45, 0);
                Debug.Log("camara4");
                break;

        }
    }
}
