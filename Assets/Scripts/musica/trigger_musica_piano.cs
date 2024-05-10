using UnityEngine;

public class trigger_musica_piano : MonoBehaviour
{
    // Componente AudioSource y su volumen
    private AudioSource audioSource;
    public AudioClip audioClip;

    // Valor para ajustar el volumen (predeterminado a 1.0)
    public float volume = 1.0f; 

    private void Start()
    {
        // Inicializa el AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = audioClip; // Asigna el clip de audio
        audioSource.volume = volume;  // Establece el volumen
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Reproducir solo si el objeto tiene la etiqueta adecuada
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}

