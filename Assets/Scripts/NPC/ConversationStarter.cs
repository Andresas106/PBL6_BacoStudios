using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{
    private InputManagement input;
    [SerializeField] private NPCConversation myConversation;
    // Start is called before the first frame update
    
    void Start()
    {
        input = GetComponent<InputManagement>();
    }
    
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(input.isInteracting)
            {

                ConversationManager.Instance.StartConversation(myConversation);
            }
        }
    }
}