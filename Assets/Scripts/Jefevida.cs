using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jefevida : MonoBehaviour
{
    public GameObject CajadeFuerza;
    public GameObject CajadeFuerza2;
    public GameObject EfectodeGolpe;
    public Image barradevidaenemigo;
    public BarraDeVidaEnemigo HP;
    public Animator Jefe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AnimationCheck()
    {

            if (Jefe.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            CajadeFuerza.SetActive(true);
            CajadeFuerza2.SetActive(true);
        }
        else
        {
            CajadeFuerza.SetActive(false);
            CajadeFuerza2.SetActive(false);
        }

    }

    public void TakeDamage(int damageAmount)
    {
        HP.vidaactual -= damageAmount;
        if (HP.vidaactual <= 0)
        {
            Jefe.SetBool("Death", true);
            GetComponent<Collider>().enabled = false;
            //Destroy(gameObject, 10);
            Jefe.speed = 1;

        }
        else
        {
            Jefe.SetTrigger("Hurt");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            TakeDamage(20);
            Jefe.SetTrigger("Hurt");
        }
    }

}
