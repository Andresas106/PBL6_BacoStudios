using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class entrada : MonoBehaviour
{
    [SerializeField] private GameObject TriggerCohete;
    [SerializeField] private NPCConversation myConversation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            TriggerCohete.SetActive(true);
            ConversationManager.Instance.StartConversation(myConversation);             
        }
    }
}
