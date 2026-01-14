using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Video;

public class Damage_trigger : MonoBehaviour
{
    public BarraDeVida Vida; //DJonde se encuentra el manager de la vida
    public int damage = 15; //Lo que quita al tocar este objeto;
    public Animator anim_Player;
    public GameObject CajadeFuerza;
    public float FuerzaEmpuje = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (anim_Player.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            CajadeFuerza.SetActive(true);
        }
        
        else 
        {
            CajadeFuerza.SetActive(false);
        }
    }

}

