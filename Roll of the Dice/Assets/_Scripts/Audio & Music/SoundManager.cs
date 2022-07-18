using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios;

    private AudioSource controlAudio;

    private void Awake()
    {
        controlAudio = GetComponent<AudioSource>();
    }

    public void SeleccionarAudio(int indice, float volumen)
    {
        controlAudio.pitch = Random.Range(0.7f, 1.5f);
        controlAudio.PlayOneShot(audios[indice], volumen);
    }
}