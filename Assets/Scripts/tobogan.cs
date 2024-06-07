using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tobogan : MonoBehaviour
{
    public Transform Target;
    public GameObject ThePlayer;
    public AudioClip soundEffect; // Variable para el clip de audio

    private AudioSource audioSource;

    void Start()
    {
        // Obtener o agregar el componente AudioSource
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered by: " + other.name);

        // Reproducir el sonido
        if (audioSource != null && soundEffect != null)
        {
            audioSource.PlayOneShot(soundEffect);
        }

        // Mover el jugador al Target
        ThePlayer.transform.position = Target.transform.position;
    }
}
