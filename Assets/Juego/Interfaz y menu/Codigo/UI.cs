using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public BarraDeVida Vida;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Vida");
        GameObject Vida;
        Vida = this.gameObject;
        Destroy(Vida);
        //Vida.vidaactual += 2;
    }
}
