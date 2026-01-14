using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class opciones : MonoBehaviour
{
  
    public Image fondoNegro;
    public GameObject profundiades;
    public GameObject principal;
    public int velocidadTransicion;
    public MoveCamera move;
    public Transform ubicacion;
    int cambio;
    bool enfoquenegro;
    bool desenfoqueNegro;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (enfoquenegro) // ¿permitira que salga el negro o aparecer el negro?
        {
            Enegrecer();
        }
        if (desenfoqueNegro)
        {
            Desenfocar();
        }
    }
    public void Enegrecer()
    {
        enfoquenegro = true;
        
        fondoNegro.gameObject.SetActive(true);
        fondoNegro.color = new Color(fondoNegro.color.r, fondoNegro.color.g, fondoNegro.color.b, Mathf.MoveTowards(fondoNegro.color.a, 1f, velocidadTransicion * Time.deltaTime));
        if (fondoNegro.color.a == 1f && cambio == 0)
        {

            Debug.Log("se volvio negro");
            enfoquenegro = false;

            profundiades.gameObject.SetActive(true);
            desenfoqueNegro = true;

        }
        if (cambio == 1 && fondoNegro.color.a == 1f)
        {

            profundiades.gameObject.SetActive(false);
            principal.gameObject.SetActive(true);
            desenfoqueNegro = true;
            enfoquenegro = false;
            move.changeTarget(ubicacion);
            cambio = 0;

        }
        
        
       
    }
    public void Desenfocar()
    {
        print("desenfocando");
        fondoNegro.color = new Color(fondoNegro.color.r, fondoNegro.color.g, fondoNegro.color.b, Mathf.MoveTowards(fondoNegro.color.a, 0f, velocidadTransicion * Time.deltaTime));
        if (fondoNegro.color.a == 0f)
        {
            
            fondoNegro.gameObject.SetActive(false);
            //Paramos de hacer fundido a transparente
            desenfoqueNegro = false;
        }
    }
    public void volver()
    {
        fondoNegro.gameObject.SetActive(true);
        cambio = 1;
        enfoquenegro = true;
        
    }
}
   

