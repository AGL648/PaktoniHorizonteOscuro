using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuDesplegable : MonoBehaviour
{
    public GameObject desplegable;
    public Camara MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(desplegable != null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                }
                else if(Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                }
                desplegable.SetActive(!desplegable.activeSelf);
            }
        }
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void desactivarMenu()
    {
        desplegable.SetActive(!desplegable.activeSelf);
        Time.timeScale = 1;
    }
}
