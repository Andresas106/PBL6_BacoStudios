using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using UnityEngine.SceneManagement;

public class entrada : MonoBehaviour
{
    [SerializeField] private GameObject TriggerCohete;
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private GameObject text_nave;
    [SerializeField] private GameObject text_entrada;

    private SoundManager soundManager;

    private Scene m_Scene;
    private string sceneName;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Start()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        text_nave.SetActive(true);
        text_entrada.SetActive(false);
        
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            TriggerCohete.SetActive(true);
            ConversationManager.Instance.StartConversation(myConversation);
            PlayerPrefs.SetInt("entrada1",1);
        }
        soundManager.SeleccionAudio(0, 0.5f);
    }
}