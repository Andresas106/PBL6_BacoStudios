using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DialogueEditor;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject timerobj;
    [SerializeField] private TMP_Text timertext;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private GameObject myConversationTrigger;
    
    private float timeElapsed;
    private int minutes, seconds;
    [SerializeField] private float time = 90;

    private ObjectCount notes;
    private CharacterMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = time;
        notes = GameObject.FindGameObjectWithTag("Player").GetComponent<ObjectCount>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(timerobj.activeInHierarchy)
        {          
            if (timeElapsed > 0 && notes.quantity != ObjectCount.MAX_QUANTITY && !pauseMenu.activeInHierarchy)
            {
                timeElapsed -= Time.deltaTime;
                minutes = (int)(timeElapsed / 60f);
                seconds = (int)(timeElapsed - minutes * 60f);

                timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else if (timeElapsed <= 0)
            {   
                timeElapsed = time;
                ConversationManager.Instance.StartConversation(myConversation);
                myConversationTrigger.SetActive(true);
            }
        }
           
    }

    public void TimerAppear()
    {
        timerobj.SetActive(true);
    }

    public void TimerDisAppear()
    {
        timerobj.SetActive(false);
    }

    public void NoPause()
    {
        playerMovement.enabled = true;
    }

    public void Pause()
    {
        playerMovement.enabled = false;
    }
}
