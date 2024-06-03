using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class entrada_planeta11 : MonoBehaviour
{
    [SerializeField] private GameObject TriggerCohete;
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private GameObject text_nave;
    [SerializeField] private GameObject text_entrada;
    [SerializeField] private GameObject canvas; // Reference to your canvas GameObject
    [SerializeField] private GameObject volverAlJuegoButton; // Reference to the "Volver al Juego" button
    [SerializeField] private GameObject floaat;

    private SoundManager soundManager;
    private bool isCanvasActive = false; // Flag to track canvas state
    private bool isConversationStarted = false; // Flag to prevent multiple conversation starts

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        canvas.SetActive(false); // Initially deactivate the canvas
        volverAlJuegoButton.SetActive(false); // Initially hide the "Volver al Juego" button

        // Add listener to the "Volver al Juego" button
        volverAlJuegoButton.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(OnVolverAlJuegoButtonClick);
    }

    private void OnTriggerEnter(Collider other)
    {
        text_nave.SetActive(true);
        text_entrada.SetActive(false);
        if (other.tag == "Player")
        {
            gameObject.SetActive(false);
            TriggerCohete.SetActive(true);
            isCanvasActive = true; // Set flag to indicate canvas activation
            canvas.SetActive(true); // Activate the canvas
            volverAlJuegoButton.SetActive(true); // Show the "Volver al Juego" button
            floaat.GetComponent<RotationObject>().enabled = false;
        }
        soundManager.SeleccionAudio(0, 0.5f);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && isCanvasActive) // Check if player exits and canvas is active
        {
            isCanvasActive = false; // Reset flag
            canvas.SetActive(false); // Deactivate the canvas
            volverAlJuegoButton.SetActive(false); // Hide the "Volver al Juego" button
        }
    }

    private void OnVolverAlJuegoButtonClick()
    {
        if (!isConversationStarted) // Check if conversation hasn't started yet
        {
            isConversationStarted = true; // Set flag to prevent further starts
            volverAlJuegoButton.SetActive(false); // Hide the "Volver al Juego" button
            canvas.SetActive(false); // Hide the canvas

            // Start the conversation
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
}
