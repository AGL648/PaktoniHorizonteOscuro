using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using TMPro;

public class Personajenocontroable : MonoBehaviour
{
    //[SerializeField] private GameObject dialogueMark;

    [SerializeField] private GameObject dialogo;
    [SerializeField] private TMP_Text texto;

    private float tiempo = 0.05f;

    [SerializeField, TextArea(4,6)]private string[] lineasdedialogo;
    private bool Rango;
    private bool yahabla;
    private int linea;
    public Transform protagonista;
    private GameObject esqueleto;


    void Update()
    {
        if (Rango && Input.GetButtonDown("Fire1")){
            if (!yahabla) {
                EmpezarDialogo();
            }
        }
        
    }
    private void EmpezarDialogo()
    {
        yahabla = true;
        dialogo.SetActive(true);
        //dialogueMark.SetActive(true);
        linea = 0;
        esqueleto.transform.LookAt(new Vector3(protagonista.position.x, protagonista.position.y, protagonista.position.z)); 
        StartCoroutine(Mostrar());
        

    }
    private IEnumerator Mostrar()
    {
        texto.text = string.Empty;
        foreach(char ch in lineasdedialogo[linea])
        {
            texto.text += ch;
            yield return new WaitForSeconds(tiempo);
        }
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rango = true;
            Debug.Log("Iniciar dialogo");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rango = false;

            Debug.Log("Salir dialogo");
        }
    }
}
