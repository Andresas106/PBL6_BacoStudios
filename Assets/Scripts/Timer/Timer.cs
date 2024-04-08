using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timertext;
    private float timeElapsed;
    private int minutes, seconds;
    private float time = 90;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = time;
    }

    // Update is called once per frame
    private void Update()
    {
        timeElapsed -= Time.deltaTime;
        minutes = (int)(timeElapsed / 60f);
        seconds = (int)(timeElapsed - minutes * 60f);

        timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if(timeElapsed == 0.0f)
        {
            Debug.Log("GAME OVER");
        }
    }
}
