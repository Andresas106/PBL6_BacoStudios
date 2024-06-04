using UnityEngine;

public class Boton : MonoBehaviour
{
    public AudioSource fuente;  // Referencia al componente AudioSource
    public AudioClip clip;      // Referencia al clip de audio que se reproducirá

    // Start se llama antes de la primera actualización de frame
    void Start()
    {
        fuente.clip = clip;  // Asigna el clip de audio al AudioSource
    }

    // Este método se llama cuando se presiona el botón
    public void Reproducir()
    {
        fuente.Play();  // Reproduce el clip de audio
    }
}
