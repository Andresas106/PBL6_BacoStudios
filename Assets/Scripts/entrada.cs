using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Entrada : MonoBehaviour
{
    [SerializeField] private GameObject TriggerCohete;
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private GameObject text_nave;
    [SerializeField] private GameObject text_entrada;
    [SerializeField] private GameObject playlist;

    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Start()
    {
        // Verifica si debería comenzar la conversación
        if (GameState.ShouldStartConversation)
        {
            GameState.ShouldStartConversation = false;
            StartCoroutine(StartConversationAfterDelay());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            text_nave.SetActive(true);
            text_entrada.SetActive(false);
            playlist.SetActive(true); // Activa el Canvas

            // Marca que la conversación debe comenzar cuando volvamos al juego
            GameState.ShouldStartConversation = true;

            gameObject.SetActive(false);
            TriggerCohete.SetActive(true);

            soundManager.SeleccionAudio(0, 0.5f);
        }
    }

    private IEnumerator StartConversationAfterDelay()
    {
        // Espera un segundo antes de iniciar la conversación
        yield return new WaitForSeconds(1f);
        ConversationManager.Instance.StartConversation(myConversation);
    }

    public static class GameState
    {
        public static bool ShouldStartConversation = false;
    }
}
