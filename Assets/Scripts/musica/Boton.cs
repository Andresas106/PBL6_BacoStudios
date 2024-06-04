using UnityEngine;

public class Boton : MonoBehaviour
{
    public AudioSource fuente;  // Referencia al componente AudioSource
    public AudioClip clip;      // Referencia al clip de audio que se reproducir�

    // Start se llama antes de la primera actualizaci�n de frame
    void Start()
    {
        fuente.clip = clip;  // Asigna el clip de audio al AudioSource
    }

    // Este m�todo se llama cuando se presiona el bot�n
    public void Reproducir()
    {
        fuente.Play();  // Reproduce el clip de audio
    }
}
