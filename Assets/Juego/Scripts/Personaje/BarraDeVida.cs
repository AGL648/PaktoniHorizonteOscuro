using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Image barradevida;
    public float vidaactual;
    public float vidamaxima;
    public Text numero;
    public Text numero2;
    public Animator anim_Player;
    //RaycastHit hit;
    // Start is called before the first frame update

    
    // Update is called once per frame
    void Update()
    {
        if (vidaactual <= 0)
        {
            print("La vida esta a 0");
            //anim_Player.SetTrigger("Death");
            vidaactual = 0;
        }else if(vidaactual > vidamaxima)
        {
            vidaactual = vidamaxima;
        }
        

        barradevida.fillAmount = vidaactual / vidamaxima;
        numero.text = vidaactual.ToString("F0"); // F0 Limitar decimales
        numero2.text = vidamaxima.ToString("F0");
        // fillAmount cantidad de imagen que se muestra EN PANTALLA = MINIMO/MAXIMO
    }
}
