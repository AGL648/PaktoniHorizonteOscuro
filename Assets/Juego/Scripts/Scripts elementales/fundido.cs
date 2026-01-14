using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fundido : MonoBehaviour
{
    public float velocidadTransicion; // ¿cuan rapido quieres que funcione el negro?
    public float velocidadfundidonegro;
    public int cambio;
    public Image negro;
    public bool desenfoqueNegro; 
    public bool enfoquenegro; 
   public bool permitirpulsar;
    public puertas puerta;

    public bool permiteseguir=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (desenfoqueNegro) // iniciar con negro desvaneciendose
        {
            transicion();
        }
        if (enfoquenegro) // ¿permitira que salga el negro o aparecer el negro?
        {
            Ennegrecer();
        }
    }
    void transicion()
    {

        negro.color = new Color(negro.color.r, negro.color.g, negro.color.b, Mathf.MoveTowards(negro.color.a, 0f, velocidadTransicion * Time.deltaTime));
        //Mathf.MoveTowards (Moverse hacia) -> el valor que queremos cambiar, valor al que lo queremos cambiar, velocidad a la que lo queremos cambiar
        //Si el color ya es totalmente transparente
        permiteseguir = false;
        if (negro.color.a == 0f)
        {
            //Paramos de hacer fundido a transparente
            desenfoqueNegro = false;
            
        }

    }
    public void Ennegrecer()
    {

        Debug.Log("ejecutando");
        permiteseguir = false;
        negro.color = new Color(negro.color.r, negro.color.g, negro.color.b, Mathf.MoveTowards(negro.color.a, 1f, velocidadfundidonegro * Time.deltaTime));
        //Mathf.MoveTowards (Moverse hacia) -> el valor que queremos cambiar, valor al que lo queremos cambiar, velocidad a la que lo queremos cambiar
        //Si el color ya es totalmente transparente
        if (negro.color.a == 1f)
        {
            Debug.Log("se volvio negro");
            enfoquenegro = false;
            permiteseguir = true;
           
        }
    }
 
}
