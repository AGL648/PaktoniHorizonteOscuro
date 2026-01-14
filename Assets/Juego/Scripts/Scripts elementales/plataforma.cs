using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.VisualScripting.StickyNote;

public class plataforma : MonoBehaviour
{
    public Transform ub_personaje;
    public Transform este_objeto;
    public GameObject personaje;
    public Renderer platform;

    // Start is called before the first frame update
    void Start()
    {
        este_objeto = GetComponent<Transform>();
        platform = GetComponent<MeshRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {

        ////print(ub_personaje.position.y);
        if (ub_personaje.position.y < este_objeto.position.y)
        {
  
            platform.material.color = new Color(1f, 1f, 1f, 0.2f);
    
        }
        else
        {
            platform.material.color = new Color(1f, 1f, 1f, 1f);
        }



    }
}
