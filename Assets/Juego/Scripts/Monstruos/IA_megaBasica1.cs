using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class IA_megaBasica1 : MonoBehaviour
{
    public Transform miPlayer;
    public Animator miAnim;
    public NavMeshAgent miAgent;
    public float velocidad = 1f;
    public Vector3 posicionOriginal;
    public GameObject CajadeFuerza;
    public GameObject EfectodeGolpe;
    public GameObject Pocion;
    public int RadioPocion;
    public Image barradevidaenemigo;


    [Header("Interfaz")]
    public BarraDeVidaEnemigo HP;

    // Start is called before the first frame update
    void Start()
    {

        posicionOriginal = transform.position;
    }
    void Update()
    {
        //Código de distancia para detectar al jugador
        if (Vector3.Distance(transform.position, miPlayer.position) > 5)
        {
            miAgent.SetDestination (posicionOriginal);
        }
        else
        {
            miAgent.SetDestination(miPlayer.transform.position);
        }
        AnimationCheck();
        
    }

    void AnimationCheck()
    {


        //VALORES
        miAnim.SetFloat("Speed", miAgent.velocity.magnitude);

        //CHECK
        if (miAnim.GetCurrentAnimatorStateInfo(0).IsTag("locomotion"))
        {

            if (miAgent.remainingDistance < miAgent.stoppingDistance)
            {
                transform.LookAt(new Vector3(miPlayer.transform.position.x, transform.position.y , miPlayer.transform.position.z));
                CheckAttack();
                
            }
            miAgent.speed = velocidad;
        }
        else
        {
            //miAnim.ResetTrigger("Attack");
            miAgent.speed = 0;
        }

        if (miAnim.GetCurrentAnimatorStateInfo(0).IsTag("locomotion"))

        if (miAnim.GetCurrentAnimatorStateInfo(0).IsTag("damage"))
        {
            miAgent.speed = 0;
            atrasfunction();
        }
        if (miAnim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            CajadeFuerza.SetActive(true);
        }

        else
        {
            CajadeFuerza.SetActive(false);
        }
    }
    // Update is called once per frame
    public void TakeDamage(int damageAmount)
    {
        //RadioPocion = Random.Range(0, 10);
        HP.vidaactual -= damageAmount;
        if (HP.vidaactual <= 0)
        {
           miAnim.SetBool("Death", true);
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject, 2);
            miAgent.speed = 0;           
            if (RadioPocion == 5)
            {
                //Pocion.SetActive(true);
                Instantiate(Pocion, transform.position, Quaternion.identity);
            }


        }

        else
        {
            miAnim.SetTrigger("Hurt");
        }
    }

 

    void CheckAttack()
    {
       
            RaycastHit hit;
            if (Physics.Raycast((transform.position-(Vector3.up)), transform.forward, out hit, 2))
            {
            
            if (hit.transform.tag == "Player")
                {
                    miAnim.SetTrigger("Attack");
                }
            }

        
    }
    void atrasfunction()
    {

        Vector3 direction =  transform.position -miPlayer.transform.position ;
        transform.LookAt(new Vector3(miPlayer.transform.position.x, transform.position.y, miPlayer.transform.position.z));
        transform.Translate(direction * Time.deltaTime * 1.5f, Space.World);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sword")
        {

            TakeDamage(20);
            GameObject particle = Instantiate(EfectodeGolpe, transform.position, transform.rotation);
            Destroy(particle, 3);
        }
    }

  
    
}
