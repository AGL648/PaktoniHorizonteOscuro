using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    public EnemyHealth Vida; //DJonde se encuentra el manager de la vida
    public int damage; //Lo que quita al tocar este objeto;
    //public Animator anim_Enemy;
    public GameObject CajadeFuerza;
    //private float FuerzaEmpuje = 3;
    public Transform player;


    /*void Update()
    {
        if (anim_Enemy.GetCurrentAnimatorStateInfo(0).IsTag("locomotion"))
        {
            CajadeFuerza.SetActive(true);
        }
        
        else if (anim_Enemy.GetCurrentAnimatorStateInfo(0).IsTag("locomotion"))
        {
            CajadeFuerza.SetActive(false);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {

        
        if (other.tag == "Enemy")
        {
           //other.GetComponent<Animator>().SetTrigger("Death");
            
            other.transform.LookAt(new Vector3(player.transform.position.x, other.transform.position.y, player.transform.position.z));
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            // GetComponent<Rigidbody>().AddForce(FuerzaEmpuje * DireccionEmpuje * 100);

            //transform.parent = other.transform;
            Debug.Log("quitovidaalenemy");

        }
    }
}

