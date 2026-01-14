using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class espada : MonoBehaviour
{
    public GameObject espadita;
    public GameObject etiqueta;
    public CharacterController prota;
    public int vida;
    public int tiempo;
    public int control;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (vida == 0)
        {
            Destroy(prota);
            prota.enabled = false;
            StartCoroutine(ESPERA(0.3f));
            SceneManager.LoadScene("caverna");


        }
        if (Input.GetButtonDown("Fire2")|| Input.GetKeyDown(KeyCode.E))
        {
            print("Mostrando");
            espadita.gameObject.SetActive(true);
            etiqueta.tag = "Enemy";
            StartCoroutine(ESPERA(0.3f));

        }
        if (control == 1)
        {
            espadita.gameObject.SetActive(false);
            control = 0;
            etiqueta.tag = "Player";
        }
    }
    IEnumerator ESPERA(float num)
    {

        yield return new WaitForSeconds(num);
        control = 1;
    }
}
