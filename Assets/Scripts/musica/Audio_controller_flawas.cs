using UnityEngine;

public class Audio_Controller_flawas : MonoBehaviour
{
    public AudioClip[] songs; // Array de canciones
    private AudioSource audioSource; // Referencia al AudioSource
    private int currentSongIndex = 0; // Índice para seguir la canción actual
    private float savedTime = 0; // Tiempo guardado para reanudar
    private bool isPaused = false; // Estado de pausa
    private static Audio_Controller_flawas instance; // Para evitar múltiples instancias

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
        if (audioSource == null) // Verificar si el AudioSource está configurado
        {
            audioSource = GetComponent<AudioSource>();
        }
        PlaySong(currentSongIndex, savedTime); // Reproducir la canción actual
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume(); // Reanudar si está pausado
            }
            else
            {
                Pause(); // Pausar si no está pausado
            }
        }

        if (!audioSource.isPlaying && !isPaused) // Si termina y no está pausado
        {
            PlayNextSong(); // Reproducir la siguiente canción
        }
    }

    void PlaySong(int index, float startTime = 0)
    {
        if (index >= 0 && index < songs.Length) // Validar índice
        {
            audioSource.clip = songs[index]; // Configurar el clip
            audioSource.time = startTime; // Configurar el tiempo de inicio
            audioSource.Play(); // Reproducir
        }
    }

    void PlayNextSong()
    {
        currentSongIndex = (currentSongIndex + 1) % songs.Length;
        PlaySong(currentSongIndex); // Reproducir la siguiente canción
    }

    public void Pause()
    {
        savedTime = audioSource.time; // Guardar el tiempo actual
        audioSource.Pause(); // Pausar la música
        isPaused = true; // Actualizar el estado de pausa
    }

    public void Resume()
    {
        PlaySong(currentSongIndex, savedTime); // Reanudar desde el tiempo guardado
        isPaused = false; // Actualizar el estado de pausa
    }
}
