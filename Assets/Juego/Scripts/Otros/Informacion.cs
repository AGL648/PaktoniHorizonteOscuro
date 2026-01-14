using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informacion : MonoBehaviour
{

    public GameObject Info;

    public void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Info.SetActive(false);
        }
    }
   
    // Start is called before the first frame update
     void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Info.SetActive(true);
        }
       
    }
}
