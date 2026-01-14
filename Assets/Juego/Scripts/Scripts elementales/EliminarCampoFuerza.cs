using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarCampoFuerza : MonoBehaviour
{
    public GameObject en1, en2, en3, en4, en5;
    public GameObject CampodeFuerza;
    // Start is called before the first frame update
    public void Update()
    {
        if(en1.gameObject == null && en2.gameObject == null && en3.gameObject == null && en4.gameObject == null && en5.gameObject == null)
        {
            Destroy(gameObject);
        }
    }
}
