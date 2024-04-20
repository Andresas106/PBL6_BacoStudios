using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPause : MonoBehaviour
{

    private InputManagement input;
    [SerializeField] private GameObject pauseMenu;
    private bool isPaused;
    private bool pauseExecuted = false; // Variable para controlar si la pausa ya se ejecutó una vez
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        isPaused = input.isPaused;

        if(isPaused && !pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            pauseExecuted = true;
            Time.timeScale = 0;
        }
        else if(isPaused && pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
