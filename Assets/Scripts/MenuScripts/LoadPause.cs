using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPause : MonoBehaviour
{

    private InputManagement input;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject colecMenu;
    private bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        isPaused = input.isPaused;

        if(isPaused && !pauseMenu.activeInHierarchy && !optionsMenu.activeInHierarchy && !colecMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if(isPaused && pauseMenu.activeInHierarchy && !optionsMenu.activeInHierarchy && !colecMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else if(isPaused && optionsMenu.activeInHierarchy)
        {
            Time.timeScale = 1;
            optionsMenu.SetActive(false);
        }
        else if(isPaused && colecMenu.activeInHierarchy)
        {
            Time.timeScale = 1;
            colecMenu.SetActive(false);
        }
    }
}
