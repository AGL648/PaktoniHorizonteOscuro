using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLookAtPlayer : MonoBehaviour
{

    public Transform jugador; // El objeto al que queremos mirar
    public float velocidadDeVision = 1; // Factor de amortiguación para la suavidad del giro
    public Animator mianim;


    // Update is called once per frame
    void Update()
    {
        if (!mianim.GetCurrentAnimatorStateInfo(0).IsName("Ataque"))
        {
            if (jugador != null)
            {
                // Calculamos la dirección hacia el objetivo
                Vector3 targetDirection = jugador.position - transform.position;
                targetDirection.y = 0;
                // Calculamos la rotación necesaria para mirar hacia el objetivo
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

                // Rotamos gradualmente hacia la rotación deseada
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * velocidadDeVision);

            }
        }
    }

    }

