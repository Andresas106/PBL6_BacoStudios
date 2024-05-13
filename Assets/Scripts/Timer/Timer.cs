using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DialogueEditor;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject timerobj;
    [SerializeField] private Slider timerSlider;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private GameObject myConversationTrigger;
    [SerializeField] private GameObject textobj;


    private float timeElapsed;
    private int minutes, seconds;
    [SerializeField] private float time = 300;

    private ObjectCount notes;
    private CharacterMovement playerMovement;
    private bool once = true;
    public float remainingTime;
    // Start is called before the first frame update
    void Start()
    {
        timerSlider.maxValue = time;
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
                remainingTime = timeElapsed;
                timeElapsed -= Time.deltaTime;
                //minutes = (int)(timeElapsed / 60f);
                //seconds = (int)(timeElapsed - minutes * 60f);

                timerSlider.value = timeElapsed;
                
            }
            else if (timeElapsed <= 0)
            {    
                if(once)
                {
                    ConversationManager.Instance.StartConversation(myConversation);
                    myConversationTrigger.SetActive(true);
                    once = false;
                }
                

            }
        }
           
    }

    public void TimerAppear()
    {
        timerobj.SetActive(true);
        textobj.SetActive(true);

    }

    public void TimerDisAppear()
    {
        timerobj.SetActive(false);
        timeElapsed = time;
        once = true;
        textobj.SetActive(false);

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
