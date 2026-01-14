using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Protagonista : MonoBehaviour
{
    /// <summary>
    /// TIPOS DE CAMINAR
    /// </summary>
   

    /// <summary>
    /// NUESTRA VIDA
    /// </summary>
    [Header("Interfaz")]
    public BarraDeVida Vida;
    public MenuDesplegable menuDesplegar;
    private Animation anim;

    /// <summary>
    /// PARAMETROS DE MOVILIDAD
    /// </summary>
    // public Animator esqueleto;
   
    //[TextArea(minLines: 2, maxLines: 4)]
    //[SerializeField] private string Descripcion;
    [Header("Movimiento")]
    public int velocidad;
    public float velocidadImpulsada;
    [SerializeField] public float V_rotacion;
    public int sonido;
    public Rigidbody rb;
    public Material texturas;
    public GameObject Jefe;
    public GameObject SaltarEscena;
    public GameObject UIJefe;
    public GameObject UIVictoria;


    /// <summary>
    /// PARAMETROS DE SALTO
    /// </summary>
    [Space]
    bool suelo;
    bool permiso_audio;
    public float distancia_salto; // la altura de salto
    private SoundManager soundManager;
    private Vector3 Movimiento;
    public AudioSource Space;
    public AudioSource Ataque;
    public Animator PlataformaRompible;
    public Animator PlataformaRompible2;

    /// <summary>
    /// PARAMETROS DE MEN�
    /// </summary>
    [Header("Menu")]
    private bool p_mover =true; // para cuando muera
    private bool b_start;
    
    /*[Tooltip("Pantalla que saldra cuando quieras pausar el juego")]
    public GameObject armamento; //boton start*/

    [Tooltip("A que altura detecta que puede saltar")]
    private int salto; // distancia para dejar salto
    RaycastHit hit;

    //private GameObject Victoria;
    //Referencias para seleccion de armas
    /*public Button primero_en_Activarse_enPause;
    public Button primero_en_Activarse_enMuerte;*/
    bool yaestamuerto=false;


    [Tooltip("Capa de suelo que detectara al caminar")]
    public LayerMask Suelo_Detectar;

    [Tooltip("Dano que se detecta al ser golpeado")]
    public LayerMask Golpe_Detectar;
   
    [Header("Ataque")]
    [Tooltip("Arma que se usa")]
    public GameObject Espada;

    [Tooltip("Dano que recibes por segundo en un suelo peligroso")]
    public int Dano_Suelo;

    //Cosas de Animacion
    public Animator _anim;

    //Tocando el suelo

    public bool IsGrounded;

    //Detectando Da�o

    public bool IsColliding;

    //Referencia al LevelManager
    private LevelManager _lReference;

    public GameObject vida;
    public GameObject llave;
    public GameObject llave1;
    public GameObject LL;
    public GameObject LL1;


    public Transform Camara;

    //C�digo para efectos de sonido
    void Efectos_Audio()
    {

        //Debug.Log(sonido);
        Ray ray = new Ray(transform.position, transform.forward);
        Ray ray2suelo = new Ray(transform.position, -transform.up);

        //Debug.DrawRay(ray.origin, ray.direction* 30,Color.yellow);
        Debug.DrawRay(ray2suelo.origin, ray2suelo.direction * 2, Color.blue);

        /* if(Physics.Raycast(transform.position, Vector3.down, out hit))
         {

             //utiliar el layer para detectar el suelo y luego con Tag el tipo de Suelo
             //tambien poner que si el rayvast o detecte el suelo no deje saltar

         }
        */

        //Codigo para detectar suelo y sonido
        if (Physics.Raycast(ray2suelo, out hit, salto, Suelo_Detectar))
        {
            //permiso_audio = true;
            suelo = true; //permite saltar
           if (hit.collider.gameObject.tag == "suelo Lava")
            {
                
                print("El suelo es lava");
                //sonido = 6;
                Vida.vidaactual -= Dano_Suelo;
                _anim.SetBool("Hitme", true);
            }
            else
            {
                _anim.SetBool("hitme", false);
            }
       

            if (hit.collider.gameObject.tag == "Suelo piedras")
            {
                print("El suelo es piedra");
                sonido = 3;
            }
            /*
              if (hit.collider.gameObject.tag == "Suelo Agua")
              {
                  print("El suelo es agua");
                  sonido = 0;
              }

              if (hit.collider.gameObject.tag == "Suelo Cesped")
              {
                  print("El suelo es cesped");
                  sonido = 4;
              }
              if (hit.collider.gameObject.tag == "Suelo Madera")
              {
                  print("El suelo es madera");
                  sonido = 8;
              }
              if (hit.collider.gameObject.tag == "Suelo Alfombra")
              {
                  print("El suelo es alfombra");
                  sonido = 9;
              }
              if (hit.collider.gameObject.tag == "Suelo Arena")
              {
                  print("El suelo es arena");
                  sonido = 2;
              }
              if (hit.collider.gameObject.tag == "Suelo Muerte")
              {
                  print("Est�s muerto");
                 // _anim.SetTrigger("Death");

              }*/

        }
        else Debug.Log(0);

    }

    /// <summary>
    /// CODIGO PARA DETECTAR EL GOLPE DE UN ENEMIGO
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Golpe"))
        {
            _anim.SetBool("Hurt", true);
            Vida.vidaactual -= 5;

            fuerzahit();
        }

        if (other.CompareTag("ObjetoEmpujable"))
        {
            _anim.SetBool("PushObject", true);
            
        }

        if (other.tag == "CambioCamara")
        {
            Jefe.SetActive(true);
            UIJefe.SetActive(true);
        }

        if(other.tag == "SueloVictoria")
        {
            UIVictoria.SetActive(true);
        }

        
    }

    /// <summary>
    /// CODIGO VERDADERO PARA LA VIDA
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Vida")
        {
            print("Tienes vida");
            Vida.vidaactual += 5;
            Destroy(collision.gameObject);
            //anim.Play("ObtainHealth");
            //gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

        if (collision.collider.gameObject.tag == "PlataformaRompible")
        {
            PlataformaRompible.SetBool("Activate", true);
            
        }

        if (collision.collider.gameObject.tag == "PlataformaRompible2")
        {
            PlataformaRompible2.SetBool("Activate", true);
        }

        if (collision.collider.gameObject.tag == "Llave")
        {
            Destroy(LL);
            llave.SetActive(true);
        }

        if (collision.collider.gameObject.tag == "Llave1")
        {
            Destroy(LL1);
            llave1.SetActive(true);
        }
        if (collision.collider.gameObject.tag == "SaltoEscena")
        {
            SceneManager.LoadScene("pruebas");
        }
    }

    /// <summary>
    /// CODIGO PARA IMPLEMENTAR LOS CONTROLES
    /// </summary>
    void Controles()
    {

        //CALCULOS PARA EL CONTROL DE CAMERA
        //guardamos el vector 3 de la camara hacia delante y hacia un lado (hacia arriba no, vamos a omitir la y)
        Vector3 forwardCam = Camara.transform.forward;
        Vector3 rigthCam = Camara.transform.right;
        //borramos las y
        forwardCam.y = 0;
        rigthCam.y = 0;
        //y normalizamos(quiere decir que los valores tienen de máximo 1 o 0)
        forwardCam = forwardCam.normalized;
        rigthCam = rigthCam.normalized;

        //creamos vectores 3 con los inputs aplicados a las direcciones
        Vector3 forwarRelativeVertical = Input.GetAxisRaw("Vertical") * forwardCam;
        Vector3 RightRelativeHorizontal = Input.GetAxisRaw("Horizontal") * rigthCam;
        Vector3 cameraRelativeMovement = forwarRelativeVertical + RightRelativeHorizontal;//USAREMOS ESTE VECTOR CUANDO NECESITEMOS SABER LA DIRECCION
                                                                                          //FIN DE CALCULO PARA ELCONTROL DE CAMARA;


        if (p_mover==true)
          
        {
            //POSICION RELATIVA A CÁMARA (Sirve para cualquier cámara y para cualquier juego)
            //float horizontal = Input.GetAxisRaw("Vertical"); // -1,0,1 derecha a izquierda
            //float vertical = Input.GetAxisRaw("Horizontal");// -1,0,-1 arriba a abajo

            Vector3 Movimiento = cameraRelativeMovement;
            //Movimiento = Quaternion.Euler(0, 45f, 0) * Movimiento;// contiene la informacion de cambio que se hara mas adelante
            _anim.SetFloat("HVmagnitud", Movimiento.magnitude);
            _anim.SetBool("FirstStrike", false);
            Movimiento.Normalize();
            //Coges el Vector de movimiento y coges su magnitud(el largo del Vector) y lo pones a 1, para que al multiplicarlo por la velocidad, aunque vayas en diagonal siempre vayas a 1 de magnitud
            // cambiar longitud a 1 manteniendo su direccion... al cambiar su longitud a 1 podemos controlar la velocidad de movimiento con un multiplicador 4x3 el multiplicador es 4
            // Que no supere la velocidad a la que esta puesto

            //transform.position = transform.position + Movimiento * velocidad * Time.deltaTime;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                rb.linearVelocity = new Vector3(Movimiento.x * velocidadImpulsada * velocidad, rb.linearVelocity.y, Movimiento.z * velocidadImpulsada * velocidad);
            }
            else
            {
                rb.linearVelocity = new Vector3(Movimiento.x * velocidad, rb.linearVelocity.y, Movimiento.z * velocidad);
            }


            // posicion actual = posicion actual+ el vector3 * velocidad * frame

            if (Movimiento != Vector3.zero) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Movimiento), V_rotacion * Time.deltaTime);
            // Quaternion.slerp : interpolamos dos angulos entre si [camino de A o b 0 rotacion ene ste caso]
            //interpolar: meter en medio
            // 1� parametro: rotacion actual 2� la rotacion resultante 3� la velocidad a rotar * FRAME o sea el tiempo qeu tarda en hacer la rotacion
            // slerp rotacion esferica lerp rotacion lineal
            if (Movimiento != Vector3.zero)
           //     esqueleto.SetBool("correr", true);
            {
                if (permiso_audio)
                {
                    soundManager.SeleccionAudio(sonido, 3f);
                }
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                
                if (b_start == false) {
                    b_start = true;
                    //armamento.SetActive(true);
                    //primero_en_Activarse_enPause.Select();


                    Time.timeScale = 0;
                }
               else if (b_start == true)
                {
                    b_start = false;
                    Time.timeScale = 1;
                    //armamento.SetActive(false);
                }

            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                if (IsGrounded == true)
                {
                    _anim.SetBool("jumpTrigger", true);
                    _anim.SetBool("FirstStrike", false);
                    Space.Play();
                    Salto();
                }
                else if(IsGrounded == false)
                {
                    _anim.SetBool("jumpTrigger", false);
                    _anim.SetBool("FirstStrike", false);
                    
                }
            }
            
            ///CODIGO PARA ACTIVAR SONIDOS PULSANDO TECLAS ESPEC�FICAS

            if (Input.GetKeyDown(KeyCode.W))
            {
                //ARRIBA
                print("SE HA PULSADO EL BOTON W\n");
                soundManager.SeleccionAudio(sonido, 3f);
                // poner que si ya se esta reproduciendo que pare el anterior
                // tambien que antes de repropducir que compruebe el ID para cuando cambie que cambie el audio
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                //Derecha
                soundManager.SeleccionAudio(sonido, 3f);
                print("SE HA PULSADO EL BOTON D\n");
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                soundManager.SeleccionAudio(sonido, 3f);
                //Izquierda
                print("SE HA PULSADO EL BOTON A\n");
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                soundManager.SeleccionAudio(sonido, 3f);
                //Abajo
                print("SE HA PULSADO EL BOTON S\n");
            }

        }
        
            //animator.SetBool("correr", true);
    }

    /// <summary>
    /// CODIGO DE IMPULSO DEL SALTO
    /// </summary>
    void Salto()
    {
       
        //permiso_audio = false;
        rb.AddForce(0, distancia_salto, 0, ForceMode.Impulse);
        

    }
   public  void fuerzahit()
    {
       
        rb.AddForce(-transform.forward* distancia_salto, ForceMode.Impulse);


    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _lReference = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        suelo = true;
        anim = gameObject.GetComponent<Animation>();
        
    }

    //Script para controlar el sonido
    // Start is called before the first frame update
    void Awake()
    {
        soundManager = FindFirstObjectByType<SoundManager>();
       // esqueleto = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {


        ///CONDICIONES PARA DETECTAR QUE EL JUAGDOR HAYA SIDO DERROTADO
        if (Vida.vidaactual <= 0)
        {
           // esqueleto.SetBool("correr", false);
            p_mover = false;
            print("no puedes moverte");
            //perdiste.SetActive(true);
            _anim.SetBool("Death", true);
            _lReference.PlayerDied();
            if(yaestamuerto==false)
            //primero_en_Activarse_enMuerte.Select();
            yaestamuerto = true;
        }
        else
        {
            p_mover = true;
        }
        if (_anim.GetCurrentAnimatorStateInfo(0).IsTag("locomotion"))
        {
            Controles();
        }

        if(_anim.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            Controles();
            

        }
        //Si protagonista presiona derecha la posicino actual sera la misma mas velocidad * time.deltatime   
        //Efectos_Audio();


        ///CONDICIONES PARA ACTIVAR LOS ATAQUES////

        if (Input.GetButtonDown("Fire1"))
        {
            _anim.SetTrigger("attackTrigger");
            _anim.SetBool("FirstStrike", true);
            Invoke("SetBoolback", 2);
            Ataque.Play();

        }
        if (_anim.GetCurrentAnimatorStateInfo(0).IsTag("attack"))
        {
            Espada.SetActive(true);

        }
        else
        {
            Espada.SetActive(false);
        }

       

        /*if (Input.GetButtonDown("Jump") ||_anim.GetCurrentAnimatorStateInfo(0).IsTag("jump"))
        {
            _anim.SetBool("jumpTrigger", true);
        }
        else
        {
            _anim.SetBool("jumpTrigger", false);
        }*/

        


        ///CODIGO DE ACTIVAR ANIMACION AL DETECTAR SUELO
        //C�digo para activar animacion al detectar siempre el suelo
        CheckGround();
            _anim.SetBool("detectSuelo", IsGrounded);

        
    }

    private void SetBoolback()
    {
        _anim.SetBool("FirstStrike", false);
    }
    ///CONDICIONES PARA DETECTAR UN DA�O
    void CheckCollision()
    {
        RaycastHit damage;
        if (Physics.Raycast(transform.position, Vector3.down, out damage, 1.1f, Golpe_Detectar))
        {
            IsColliding = true;
        }
        else
        {
            IsColliding = false;
        }
    }

    ///CONDICIONES PARA DETECTAR EL SUELO
    void CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.1f, Suelo_Detectar))
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }

    
}
