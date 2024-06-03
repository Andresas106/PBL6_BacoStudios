using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCManage : MonoBehaviour
{
    private InputManagement input;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ConversationManager.Instance != null)
        {
            UpdateConversationInput();
        }
    }

    private void UpdateConversationInput()
    {
        if (ConversationManager.Instance.IsConversationActive)
        {

            if (input.isInteracting)
                ConversationManager.Instance.PressSelectedOption();
        }
    }
}
