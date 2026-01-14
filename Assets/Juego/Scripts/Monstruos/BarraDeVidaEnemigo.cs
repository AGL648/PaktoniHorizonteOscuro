using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVidaEnemigo : MonoBehaviour
{
    public Image barradevidaenemigo;
    public float vidaactual;
    public float vidamaxima;
    public Animator anim_Player;
    public GameObject Enemigo;
    public Collider CajaFuerza;
    public Collider CajaFuerza2;

    //public BarraDeVidaEnemigo HP;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (vidaactual <= 0)
        {
            print("Su vida esta a 0");
            anim_Player.SetTrigger("Death");
            Destroy(gameObject, 1);
        }
        

        barradevidaenemigo.fillAmount = vidaactual / vidamaxima;
        // fillAmount cantidad de imagen que se muestra EN PANTALLA = MINIMO/MAXIMO
    }
}
