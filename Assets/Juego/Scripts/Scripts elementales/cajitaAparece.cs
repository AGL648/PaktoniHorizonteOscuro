using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cajitaAparece : MonoBehaviour
{
    public GameObject[] enemigosEnPie;
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (num > 0)
        {
            if (enemigosEnPie[num].activeInHierarchy)
            {
                print("Menos 1");
                num = num - 1;
            }
        }
        print("Sin enemigos");
        this.gameObject.SetActive(true);
        //si enemigos estan todos en setactive 0 aparecer
    }
}
