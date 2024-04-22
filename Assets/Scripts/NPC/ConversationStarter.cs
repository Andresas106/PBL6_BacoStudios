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

    private CharacterMovement playerMovement;
    // Start is called before the first frame update

    void Start()
    {
        input = GetComponent<InputManagement>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entra");
        keyE.SetActive(true);
    }

     private void OnTriggerExit(Collider other)
    {
        keyE.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
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