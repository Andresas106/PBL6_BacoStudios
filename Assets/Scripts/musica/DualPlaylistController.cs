using UnityEngine;

public class DualPlaylistController : MonoBehaviour
{
    public AudioClip[] playlist1; // Primer array de canciones
    public AudioClip[] playlist2; // Segundo array de canciones

    private AudioSource audioSource; // Referencia al AudioSource
    private int currentSongIndex1 = 0; // �ndice de la primera lista
    private int currentSongIndex2 = 0; // �ndice de la segunda lista

    private bool isUsingPlaylist1 = true; // Indicador para saber qu� lista se est� usando
    private static DualPlaylistController instance; // Para evitar m�ltiples instancias

    private bool enter = true;

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
        if (audioSource == null) // Verificar si el AudioSource est� configurado
        {
            audioSource = GetComponent<AudioSource>();
        }

        PlayCurrentSong(); // Iniciar con la primera canci�n de la lista activa
    }

    void Update()
    {
        if (!audioSource.isPlaying && audioSource.clip != null && enter)
        {
            PlayNextSong();
        }
    }

    void PlayCurrentSong()
    {
        if (isUsingPlaylist1 && playlist1.Length > 0)
        {
            audioSource.clip = playlist1[currentSongIndex1]; // Configurar el nuevo clip
        }
        else if (!isUsingPlaylist1 && playlist2.Length > 0)
        {
            audioSource.clip = playlist2[currentSongIndex2]; // Configurar el nuevo clip
        }
        audioSource.Play(); // Reproducir
    }

    void PlayNextSong()
    {
        if (isUsingPlaylist1)
        {
            currentSongIndex1 = (currentSongIndex1 + 1) % playlist1.Length; // Avanzar al siguiente �ndice
        }
        else
        {
            currentSongIndex2 = (currentSongIndex2 + 1) % playlist2.Length; // Avanzar al siguiente �ndice
        }

        PlayCurrentSong(); // Reproducir la canci�n actual del �ndice actualizado
    }

    public void SwitchPlaylist(bool usePlaylist1)
    {
        isUsingPlaylist1 = usePlaylist1; // Cambiar la lista de reproducci�n
        PlayCurrentSong(); // Reproducir la primera canci�n de la nueva lista
    }

    public void Pause()
    {
        enter = false;
        audioSource.Pause();
    }

    public void Resume()
    {
        enter = true;
        audioSource.Play();

    }
}
