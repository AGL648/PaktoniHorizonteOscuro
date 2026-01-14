using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public BarraDeVida BV;
    public Protagonista P1;
    public Informacion info;
    public UI Interfaz;
    public GameObject perdiste;
    public string NivelActual;


 


    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(NivelActual);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        //Método para detectar la Barra de Vida
        BV = GameObject.FindFirstObjectByType<BarraDeVida>();
        //Método para detectar al Jugador
        P1 = GameObject.FindFirstObjectByType<Protagonista>();
        //Método para detectar la Interfaz del juego
        Interfaz = GameObject.FindFirstObjectByType<UI>();

        info = GameObject.FindFirstObjectByType<Informacion>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReiniciarNivel();
            perdiste.gameObject.SetActive(false);
        }


    }

    //Método jugador muere
    public void PlayerDied()
    {
        StartCoroutine(PlayerDiedCo());
        
    }

    private IEnumerator PlayerDiedCo()
    {
        yield return new WaitForSeconds(2f);
        perdiste.gameObject.SetActive(true);
    }


    //Hacer scripts de LevelManager (Todos los controles de la partida, Vida del jugador, UI, Estructurar carpetas del proyecto y scripts)
}
