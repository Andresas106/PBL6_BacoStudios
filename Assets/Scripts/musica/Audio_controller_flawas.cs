using UnityEngine;

public class Audio_Controller_flawas : MonoBehaviour
{
    public AudioClip[] songs; // Array de canciones
    private AudioSource audioSource; // Referencia al AudioSource
    private int currentSongIndex = 0; // �ndice para seguir la canci�n actual
    private float savedTime = 0; // Tiempo guardado para reanudar
    private bool isPaused = false; // Estado de pausa
    private static Audio_Controller_flawas instance; // Para evitar m�ltiples instancias

    void Awake()
    {
        if (instance == null) // Asegurar solo una instancia
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); // Mantener el objeto
        }
        else
        {
            Destroy(this.gameObject); // Destruir si ya existe una instancia
        }
    }

    void Start()
    {
        if (audioSource == null) // Verificar si el AudioSource est� configurado
        {
            audioSource = GetComponent<AudioSource>();
        }
        PlaySong(currentSongIndex, savedTime); // Reproducir la canci�n actual
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume(); // Reanudar si est� pausado
            }
            else
            {
                Pause(); // Pausar si no est� pausado
            }
        }

        if (!audioSource.isPlaying && !isPaused) // Si termina y no est� pausado
        {
            PlayNextSong(); // Reproducir la siguiente canci�n
        }
    }

    void PlaySong(int index, float startTime = 0)
    {
        if (index >= 0 && index < songs.Length) // Validar �ndice
        {
            audioSource.clip = songs[index]; // Configurar el clip
            audioSource.time = startTime; // Configurar el tiempo de inicio
            audioSource.Play(); // Reproducir
        }
    }

    void PlayNextSong()
    {
        currentSongIndex = (currentSongIndex + 1) % songs.Length;
        PlaySong(currentSongIndex); // Reproducir la siguiente canci�n
    }

    public void Pause()
    {
        savedTime = audioSource.time; // Guardar el tiempo actual
        audioSource.Pause(); // Pausar la m�sica
        isPaused = true; // Actualizar el estado de pausa
    }

    public void Resume()
    {
        PlaySong(currentSongIndex, savedTime); // Reanudar desde el tiempo guardado
        isPaused = false; // Actualizar el estado de pausa
    }
}
