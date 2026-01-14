using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cargarpartida1 : MonoBehaviour
{
    public GameObject Character;
    public Object Check1;
    public Object Check2;
    public Object Check3;
    // Start is called before the first frame update
    public void cargarnivel()
    {
        SceneManager.LoadScene("MENU PRINCIPAL");
    }
    public void Salir()
    {
        Application.Quit();
    }

    public void Checkpoint()
    {
    
    }
}
