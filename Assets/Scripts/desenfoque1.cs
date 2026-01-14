using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class desenfoque1 : MonoBehaviour
{
   
    public float velocidadTransicion; // ¿cuan rapido quieres que funcione el negro?
    public float velocidadfundidonegro;
    public int cambio;
    public Image negro;
    public bool desenfoqueNegro;
    public bool enfoquenegro;
    public bool permitirpulsar;
    public Transform objetivo;
    public GameObject texto;
    public AudioSource Audio;
    public MoveCamera camaraSitio;

  //  public render
  

    // Start is called before the first frame update
    void Start()
    {
        desenfoqueNegro = true;
        enfoquenegro = false;
        permitirpulsar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            print("escape");
            Application.Quit();
        }
        if (desenfoqueNegro) // iniciar con negro desvaneciendose
        {
            transicion();
        }
        if (enfoquenegro) // ¿permitira que salga el negro o aparecer el negro?
        {
            Ennegrecer();
        }

        if (negro.color.a == 0)
        {
            if (permitirpulsar == true)
                if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Jump")) //////////////////
                {
                    print("Boton a");
                    Audio.Play();
                    camaraSitio.changeTarget(objetivo);
                    if (texto != null)
                    {
                        Destroy(texto);
                    }
                    enfoquenegro = false;
                    

                    

                }

        }
        if (cambio == 1)
        {
            SceneManager.LoadScene("pruebas");
        }
    }
    void transicion()
    {

        negro.color = new Color(negro.color.r, negro.color.g, negro.color.b, Mathf.MoveTowards(negro.color.a, 0f, velocidadTransicion * Time.deltaTime));
       //(Moverse hacia) -> el valor que queremos cambiar, valor al que lo queremos cambiar, velocidad a la que lo queremos cambiar
        // Si el color ya es totalmente transparente
        if (negro.color.a == 0f)
      {
           //Paramos de hacer fundido a transparente
          permitirpulsar = true ;
}

    }
    public void Ennegrecer()
    {

        print("ejecutando");
        negro.color = new Color(negro.color.r, negro.color.g, negro.color.b, Mathf.MoveTowards(negro.color.a, 1f, velocidadfundidonegro * Time.deltaTime));
        //Mathf.MoveTowards (Moverse hacia) -> el valor que queremos cambiar, valor al que lo queremos cambiar, velocidad a la que lo queremos cambiar
        //Si el color ya es totalmente transparente
        if (negro.color.a == 1f)
        {
            print("se volvio negro");
            enfoquenegro = false;
        }
    }
   /* public static void convertirImagenATextura()
    {
        RenderTexture.active = renderTexture;
        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false, false);
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture.Apply();

        byte[] bytes = texture.EncodeToPNG();
        UnityEngine.Object.Destroy(texture);

        System.IO.File.WriteAllBytes(file, bytes);

    }

    */
    IEnumerator ESPERA(int num)
    {

        yield return new WaitForSeconds(num);
        cambio = 1;
    }
   
    public void Nivel()
    {
        SceneManager.LoadScene("Instrucciones");
    }

}
