using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valla : MonoBehaviour
{
    public GameObject Luz;
    public GameObject Trampa;
    public Animator anim;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ObjetoEmpujable")
        {
            Luz.SetActive(true);
            anim.SetTrigger("Positivo");

        }
    }
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
