using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class abismo : MonoBehaviour
{
    public BarraDeVida Vida;    // Start is called before the first frame update
    public Rigidbody rbProtagonista;
    void Start()
    {
        //SampleScene
    }

    // Update is called once per frame
    void Update()
    {
    }
        private void OnTriggerEnter(Collider other)
        {


        Vida.vidaactual = 0;
        //PROTOTIPO PARA LA CAIDA INFINITA
        rbProtagonista.constraints = RigidbodyConstraints.FreezePositionZ| RigidbodyConstraints.FreezePositionX| RigidbodyConstraints.FreezePositionY;

    }
}

