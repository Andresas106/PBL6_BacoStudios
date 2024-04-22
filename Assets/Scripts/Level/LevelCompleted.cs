using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class LevelCompleted : MonoBehaviour
{

    private ObjectCount notes;
    [SerializeField] private GameObject notesobj;
    [SerializeField] private GameObject timer;
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private GameObject entrada;

    private bool enter = false;

    void Start()
    {
        notes = GameObject.FindGameObjectWithTag("Player").GetComponent<ObjectCount>();
    }

    // Update is called once per frame
    void Update()
    {       
        if (notes.quantity == ObjectCount.MAX_QUANTITY && !enter)
        {
            enter = true;
            //Hacer algo para que el jugador tenga la opcion de ir al siguiente nivel
            ConversationManager.Instance.StartConversation(myConversation);

        }
    }

    public void Entrada()
    {
        entrada.SetActive(true);
    }
}
