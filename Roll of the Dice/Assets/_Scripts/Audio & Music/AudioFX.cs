using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFX : MonoBehaviour
{
    public AudioClip[] audios;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ElegirAudio(int indice)
    {
        audioSource.clip = audios[indice];
        audioSource.Play();
    }
}