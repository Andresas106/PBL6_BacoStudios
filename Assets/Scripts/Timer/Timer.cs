using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text timertext;
    private float timeElapsed;
    private int minutes, seconds;
    [SerializeField] private float time = 90;
    [SerializeField] private GameObject gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = time;
    }

    // Update is called once per frame
    private void Update()
    {
       if(timeElapsed >= 0)
       {
            Time.timeScale = 1;
            timeElapsed -= Time.deltaTime;
            minutes = (int)(timeElapsed / 60f);
            seconds = (int)(timeElapsed - minutes * 60f);

            timertext.text = string.Format("{0:00}:{1:00}", minutes, seconds);
       }
       else {
            gameOverMenu.SetActive(true);
            Time.timeScale = 0;

       }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }

    public void Quit()
    {
        Application.Quit();
    }
}
