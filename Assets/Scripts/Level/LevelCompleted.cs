using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class LevelCompleted : MonoBehaviour
{
    private ObjectCount notes;
    [SerializeField] private GameObject notesObj;
    [SerializeField] private GameObject timer;
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private GameObject entrada;



    private bool enter = false;

    // Añadimos una referencia al DualPlaylistController
    [SerializeField] private DualPlaylistController playlistController;

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
            // Inicia la conversación para que el jugador tenga la opción de ir al siguiente nivel
            ConversationManager.Instance.StartConversation(myConversation);
            ActivarEntrada();
        }
    }

    public void ActivarEntrada()
    {
        entrada.SetActive(true);

        // Cambia a la segunda lista cuando se activa la entrada
        if (playlistController != null)
        {
            playlistController.SwitchPlaylist(false); // Cambia a la lista 2
        }

    }
}
