using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioClip[] playlist1; // Primer array de canciones
    public AudioClip[] playlist2; // Segundo array de canciones

    private AudioSource audioSource; // Referencia al AudioSource
    private int currentSongIndex1_1 = 0; // Índice de la primera lista
    private int currentSongIndex2_2 = 0; // Índice de la segunda lista

    private bool isUsingPlaylist1 = true; // Indicador para saber qué lista se está usando
    private static audio instance; // Para evitar múltiples instancias

    void Awake()
    {
        if (instance == null) // Asegurar solo una instancia
        {
            instance = this;
            //DontDestroyOnLoad(this.gameObject); // Mantener el objeto
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

        PlayNextSong(); // Iniciar con la primera canción de la lista activa
    }

    void PlayNextSong()
    {
        if (isUsingPlaylist1)
        {
            currentSongIndex1_1 = (currentSongIndex1_1 + 1) % playlist1.Length; // Avanzar al siguiente índice
            audioSource.clip = playlist1[currentSongIndex1_1]; // Configurar el nuevo clip
        }
        else
        {
            currentSongIndex2_2 = (currentSongIndex2_2 + 1) % playlist2.Length; // Avanzar al siguiente índice
            audioSource.clip = playlist2[currentSongIndex2_2]; // Configurar el nuevo clip
        }

        audioSource.Play(); // Reproducir
    }

    public void SwitchPlaylist(bool usePlaylist1)
    {
        isUsingPlaylist1 = usePlaylist1; // Cambiar la lista de reproducción
        PlayNextSong(); // Reproducir la siguiente canción
    }

    public void Pause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    public void Resume()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}