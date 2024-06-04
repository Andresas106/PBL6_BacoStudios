using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    private ObjectCount notes;
    [SerializeField] private GameObject timer;
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private GameObject entrada;
    [SerializeField] private GameObject stickerText;
    [SerializeField] private GameObject texto_entrada;

    [SerializeField] private GameObject objectToActivate; // Nuevo GameObject a activar
    [SerializeField] private GameObject objectToDeactivate; // Nuevo GameObject a desactivar

    private bool enter = false;
    private Timer timerScript;

    private Scene m_Scene;
    private string sceneName;

    // A�adimos referencias tanto para DualPlaylistController como para AudioController
    [SerializeField] private DualPlaylistController dualPlaylistController;

    // A�adimos una referencia al SkyboxExposureChanger
    [SerializeField] private SkyboxExposureChanger skyboxExposureChanger;

    // A�adimos una referencia al componente AudioSource
    [SerializeField] private AudioSource audioSource;
    // A�adimos una referencia al AudioClip
    [SerializeField] private AudioClip stickerAudioClip;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("sticker1"))
        {
            PlayerPrefs.SetInt("sticker1", 0);
            PlayerPrefs.Save();
        }

        if (!PlayerPrefs.HasKey("sticker2"))
        {
            PlayerPrefs.SetInt("sticker2", 0);
            PlayerPrefs.Save();
        }
    }

    void Start()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
        notes = GameObject.FindGameObjectWithTag("Player").GetComponent<ObjectCount>();
        timerScript = timer.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (notes.quantity == ObjectCount.MAX_QUANTITY && !enter)
        {
            enter = true;
            // Inicia la conversaci�n para que el jugador tenga la opci�n de ir al siguiente nivel
            ConversationManager.Instance.StartConversation(myConversation);
            ActivarEntrada();
            ObtenerSticker1();
            ObtenerSticker2();
            SwitchActiveObjects(); // Llama al nuevo m�todo

            // Inicia el cambio de exposici�n del skybox
            if (skyboxExposureChanger != null)
            {
                skyboxExposureChanger.StartChangingExposure();
            }
        }
    }

    public void ActivarEntrada()
    {
        entrada.SetActive(true);
        texto_entrada.SetActive(true);

        // Cambia a la segunda lista cuando se activa la entrada
        if (dualPlaylistController != null)
        {
            dualPlaylistController.SwitchPlaylist(false); // Cambia a la lista 2
        }
    }

    public void ObtenerSticker1()
    {
        if (sceneName == "Level1_FigaFlawas")
        {
            if (timerScript.remainingTime >= 150)
            {
                stickerText.SetActive(true);
                ReproducirAudio(); // Reproduce el audio
                PlayerPrefs.SetInt("sticker1", 1);
                PlayerPrefs.Save();
            }
        }
    }

    public void ObtenerSticker2()
    {
        if (sceneName == "Level2_TheTyets")
        {
            if (timerScript.remainingTime >= 150)
            {
                stickerText.SetActive(true);
                ReproducirAudio(); // Reproduce el audio
                PlayerPrefs.SetInt("sticker2", 1);
                PlayerPrefs.Save();
            }
        }
    }

    private void SwitchActiveObjects()
    {
        if (objectToDeactivate != null)
        {
            objectToDeactivate.SetActive(false);
        }
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
    private void ReproducirAudio()
    {
        if (audioSource != null && stickerAudioClip != null)
        {
            audioSource.clip = stickerAudioClip;
            audioSource.Play();
        }
    }
}
