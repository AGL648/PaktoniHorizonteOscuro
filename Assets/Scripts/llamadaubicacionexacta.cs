using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llamadaubicacionexacta : MonoBehaviour
{
    public MoveCamera lacamara;
    public Transform Camaraprincipal;
    public Transform Miubicacion;
    public Transform Siguiente_Ubicacion;
    // Start is called before the first frame update
    void start()
    {
        Miubicacion = this.GetComponent<Transform>();
    }
   

    // Update is called once per frame
    void Update()
    {
        if(Camaraprincipal.transform.position== Miubicacion.transform.position)
        {
            lacamara.changeTarget_lento(Siguiente_Ubicacion);
        }
    }
}
