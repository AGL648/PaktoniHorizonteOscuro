using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloVictoria : MonoBehaviour
{
    public GameObject Menu;
    private void OnCollisionEnter(Collision collision)
    {
        Menu.SetActive(true);
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
