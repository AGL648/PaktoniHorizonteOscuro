using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform objetivo_Siguiente;
    public Transform optiones, profundidades;
    public Transform camara;
    public rotaralrededor RotacionIsla;

    // La velocidad de seguimiento
    private float speed = 444;
   

    // Método llamado en cada frame
    void start()
    {
       
    }
    void Update()
    {
        camara = this.GetComponent<Transform>();
        if (objetivo_Siguiente != null){
            // Utilizando Lerp para suavizar el movimiento de la cámara hacia el objetivo
            transform.position = Vector3.Lerp(transform.position, objetivo_Siguiente.position, Time.deltaTime * speed);

            // También aplicando Lerp a la rotación si es necesario seguir la rotación del objetivo
            transform.rotation = Quaternion.Lerp(transform.rotation, objetivo_Siguiente.rotation, Time.deltaTime * speed);
        }
       
    }

    // Método para cambiar dinámicamente el objetivo de la cámara
    public void changeTarget(Transform newTarget)
    {
        RotacionIsla.enabled = false;
        // Asignar el nuevo objetivo
        objetivo_Siguiente = newTarget;
        
        

    }
    public void changeTarget_lento(Transform newTarget)
    {
        speed = 1;
        objetivo_Siguiente = newTarget;
    }
   

    public void profundidad()
    {
        
        // cuando transform y camara esten en el mismo sitio coger la ubicacion del otro transform y luego coger la ubicacion
        //del siguiente y se diriga hacia el
    }
    
}