using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class panelDeTexto : MonoBehaviour
{
    public GameObject PanelDeTexto;
    public Text texto1;
    public bool escribiendo;
    public float temporizador;
    int tiempoeliminarTexto = 4;

    public void IniciarCorroutinaEsribir(string texto)
    {
        StartCoroutine(EscribirTexto(texto));
    }
    public IEnumerator EscribirTexto(string texto)
    {
        if(!escribiendo)
        {
            texto1.text = "";
            escribiendo = true;
            PanelDeTexto.SetActive(true);
            foreach(char letra in texto) // hace bucle por cada palabra
            {
                texto1.text = texto1.text + letra;
                yield return new WaitForSeconds(tiempoeliminarTexto);

            }
            yield return new WaitForSecondsRealtime(tiempoeliminarTexto);
            texto1.text = "";

            PanelDeTexto.SetActive(false);
            escribiendo = false;
        }
        yield return null;
    }
    
}
