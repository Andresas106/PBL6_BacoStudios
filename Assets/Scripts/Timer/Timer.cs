using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DialogueEditor;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject timerobj;
    [SerializeField] private GameObject notesobj;
    [SerializeField] private TMP_Text timertext;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private NPCConversation myConversation;
    [SerializeField] private GameObject myConversationTrigger;
    private float timeElapsed;
    private int minutes, seconds;
    [SerializeField] private float time = 90;

    private ObjectCount notes;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = time;
        notes = GameObject.FindGameObjectWithTag("Player").GetComponent<ObjectCount>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(timerobj.active)
        {
            if (timeElapsed > 0 && notes.quantity != ObjectCount.MAX_QUANTITY && !pauseMenu.active)
            {
                timeElapsed -= Time.deltaTime;
                minutes = (int)(timeElapsed / 60f);
                seconds = (int)(timeElapsed - minutes * 60f);

                timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
            else if (timeElapsed <= 0)
            {
                timerobj.SetActive(false);
                notesobj.SetActive(false);
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
}
