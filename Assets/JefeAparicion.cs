using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeAparicion : MonoBehaviour
{
    public GameObject Jefe;
    public GameObject personaje;

    private void OnCollisionEnter(Collision collision)
    {
        Jefe.SetActive(true);
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
