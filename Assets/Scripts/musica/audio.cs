using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip[] playlist1; // Primer array de canciones
    public AudioClip[] playlist2; // Segundo array de canciones

    private AudioSource audioSource; // Referencia al AudioSource
    private int currentSongIndex1 = 0; // �ndice de la primera lista
    private int currentSongIndex2 = 0; // �ndice de la segunda lista

    private bool isUsingPlaylist1 = true; // Indicador para saber qu� lista se est� usando
    private static AudioController instance; // Para evitar m�ltiples instancias

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
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null) // Verificar si el AudioSource est� configurado
        {
            Debug.LogError("AudioSource no encontrado en el GameObject.");
            return;
        }

        PlayNextSong(); // Iniciar con la primera canci�n de la lista activa
    }

    void Update()
    {
        // Chequear si la canci�n actual ha terminado de reproducirse
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        if (isUsingPlaylist1)
        {
            if (playlist1.Length == 0)
            {
                Debug.LogWarning("Playlist 1 est� vac�a.");
                return;
            }
            currentSongIndex1 = (currentSongIndex1 + 1) % playlist1.Length; // Avanzar al siguiente �ndice
            audioSource.clip = playlist1[currentSongIndex1]; // Configurar el nuevo clip
            Debug.Log("Reproduciendo canci�n de Playlist 1: " + playlist1[currentSongIndex1].name);
        }
        else
        {
            if (playlist2.Length == 0)
            {
                Debug.LogWarning("Playlist 2 est� vac�a.");
                return;
            }
            currentSongIndex2 = (currentSongIndex2 + 1) % playlist2.Length; // Avanzar al siguiente �ndice
            audioSource.clip = playlist2[currentSongIndex2]; // Configurar el nuevo clip
            Debug.Log("Reproduciendo canci�n de Playlist 2: " + playlist2[currentSongIndex2].name);
        }

        audioSource.Play(); // Reproducir
    }

    public void SwitchPlaylist(bool usePlaylist1)
    {
        isUsingPlaylist1 = usePlaylist1; // Cambiar la lista de reproducci�n
        Debug.Log("Cambiando a " + (usePlaylist1 ? "Playlist 1" : "Playlist 2"));
        PlayNextSong(); // Reproducir la siguiente canci�n
    }

    public void Pause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            Debug.Log("Pausando canci�n.");
        }
    }

    public void Resume()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
            Debug.Log("Reanudando canci�n.");
        }
    }

    // M�todo para cambiar manualmente la canci�n
    public void NextSong()
    {
        PlayNextSong();
    }
}
