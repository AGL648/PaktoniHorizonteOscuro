using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public int Enemigosmuertos;
    public GameObject Puerta;
    public List<GameObject> Enemigo = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void RemoverObjetodeLaLista()
    {
        /*for(int i = 0; i < Enemigo.Count; i++)
        {
            if (Enemigo.GameObject == null)
            {
                Enemigo.RemoveAt(i);
            }
        }*/
    }
    // Update is called once per frame
    void Update()
    {
        if (Enemigo[5])
        {
            Enemigosmuertos = 1;
        }
        if (Enemigosmuertos == 1)
        {
            Destroy(Puerta);
        }
    }
}
