using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] sonidos_varios;

    private AudioSource controlAudio;
    // Start is called before the first frame update
    public void Awake()
    {
        controlAudio = GetComponent<AudioSource>();

    }
    public void SeleccionAudio(int indice, float volumen)
    {
        if (!controlAudio/*(sonidos_varios[indice])*/.isPlaying)
        {
            controlAudio.PlayOneShot(sonidos_varios[indice], volumen);
        }
    }
}
