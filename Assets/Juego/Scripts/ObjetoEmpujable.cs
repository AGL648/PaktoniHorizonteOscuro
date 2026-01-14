using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoEmpujable : MonoBehaviour
{
    public GameObject Trampa;
    public GameObject Activa;
    public Animator Puerta;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Receptor")
        {

            GetComponent<Rigidbody>().isKinematic = true;
            Puerta.SetTrigger("Positivo");
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (collision.gameObject.tag == "Receptor")
        {
            Activa.SetActive(true);
        }*/
    }
}
