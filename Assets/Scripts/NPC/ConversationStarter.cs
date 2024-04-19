using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class ConversationStarter : MonoBehaviour
{
    private InputManagement input;
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private GameObject myTrigger;
    [SerializeField] private GameObject keyE;
    // Start is called before the first frame update
    
    void Start()
    {
        input = GetComponent<InputManagement>();
    }

    void OnTriggerEnter(Collider other)
    {
        keyE.SetActive(true);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(input.isInteracting)
            {
                keyE.SetActive(false);
                ConversationManager.Instance.StartConversation(myConversation);
                Destroy(myTrigger);
            }
        }
    }
}