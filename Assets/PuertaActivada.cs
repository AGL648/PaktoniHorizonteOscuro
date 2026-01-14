using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaActivada : MonoBehaviour
{
    public GameObject Llave;
    public GameObject Llave1;
    public Animator anim;
    
// Start is called before the first frame update
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Llave.activeSelf && Llave1.activeSelf)
        {
            anim.SetTrigger("Activo");
        }
    }
}
