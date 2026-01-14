using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transparencias : MonoBehaviour
{
   
    public Transform personaje;
    public Transform plano;
    public int colorAlfa;


    // Coger informacion del personaje O LA POSICION si esta  por debajo de en eje Y la transparencia sera de 80 
    // Start is called before the first frame update

    void Start()
    {
        // coger ubicacoin de prota nota esta mal
        plano = GetComponent<Transform>(); // ubicacion actual
        
    }

    // Update is called once per frame
    void Update()
    {
        // ahi que poner que cuanto mas cerca estan de uno a otro bajar la transparencia
        // hacer una cuenta entre x e y si es menor a x numero empezara a sumarse conforme se acerque
        print(plano.position.y);
        print(personaje.position.y);
        if (plano.position.y < personaje.position.y)
        {
          
        }
    }
 
}
