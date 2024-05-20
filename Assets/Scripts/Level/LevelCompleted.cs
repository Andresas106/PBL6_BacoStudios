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



    private bool enter = false;
    private Timer timerScript;

    private Scene m_Scene;
    private string sceneName;

    // Añadimos una referencia al DualPlaylistController
    [SerializeField] private DualPlaylistController playlistController;

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
            // Inicia la conversación para que el jugador tenga la opción de ir al siguiente nivel
            ConversationManager.Instance.StartConversation(myConversation);
            ActivarEntrada();
            ObtenerSticker1();
            ObtenerSticker2();
        }
    }

    public void ActivarEntrada()
    {
        entrada.SetActive(true);
        texto_entrada.SetActive(true);

        // Cambia a la segunda lista cuando se activa la entrada
        if (playlistController != null)
        {
            playlistController.SwitchPlaylist(false); // Cambia a la lista 2
        }

    }

    public void ObtenerSticker1()
    {
        if(sceneName == "Level1_FigaFlawas")
        {
           
            if (timerScript.remainingTime >= 150)
            {
                stickerText.SetActive(true);
                PlayerPrefs.SetInt("sticker1", 1);
                PlayerPrefs.Save();
            }
        }
        
    }

    public void ObtenerSticker2()
    {
        if(sceneName == "Level2_TheTyets")
        {
            
            if (timerScript.remainingTime >= 150)
            {
                stickerText.SetActive(true);
                PlayerPrefs.SetInt("sticker2", 1);
                PlayerPrefs.Save();
            }
        }
        
    }
}
