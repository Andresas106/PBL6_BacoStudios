using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class entrada : MonoBehaviour
{
    [SerializeField] private GameObject TriggerCohete;
    [SerializeField] private NPCConversation myConversation;

    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            TriggerCohete.SetActive(true);
            ConversationManager.Instance.StartConversation(myConversation);             
        }
        soundManager.SeleccionAudio(0, 0.5f);
    }
}
