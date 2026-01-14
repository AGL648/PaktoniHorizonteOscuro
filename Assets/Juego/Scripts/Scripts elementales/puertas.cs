using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertas : MonoBehaviour
{
    //coger la posicion del personaje y ponerlo para que este ahi
    //desenfoque a negro
    // Utiliza la ID para acceder de uno a otro
    // instantiate coge un objeto
    // Start is called before the first frame update
    [TextArea(minLines: 2, maxLines: 4)]
    //[SerializeField] private string Descripcion= ("Prototipo de cambio de escenario");

    public fundido trans;
    public int ID;
    public CharacterController personaje;
    [Tooltip("La sala que descarta y la sala que carga...El 1º(0) lo descarta y la 2º(1) la carga")]

    public GameObject[] salas;
    public bool cambiocamara;
    public GameObject camara;
    
  
 
    public Transform Tpersonaje;
    
    public int x, y,z;
    [Tooltip("Ubicacion de la camara")]
    public int Rx, Ry, Rz;
    [Tooltip("Rotacion de la camara")]
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (trans.enfoquenegro == false)
        {
            trans.desenfoqueNegro = true;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player")){
            
            trans.enfoquenegro =true;
            personaje.enabled = false;

            print("Ha entrado");
            personaje.transform.position = Tpersonaje.transform.position;
            personaje.enabled = true;
            salas[0].SetActive(false);
            salas[1].SetActive(true);
            if (cambiocamara == true)
            {
                camara.transform.position = new Vector3(x, y, z);
                camara.transform.rotation = new Quaternion(x, y, z, 0f);

            }
            print("Se da la transformcion");
              
            }
        }
            //hace aqui desenfoque a negro y va hacia el transform cuando este al 100% a negro pasa al transform y quita el negro

        }


