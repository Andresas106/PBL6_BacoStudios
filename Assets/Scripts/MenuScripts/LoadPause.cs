using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPause : MonoBehaviour
{

    private InputManagement input;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject colecMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private AudioSource[] audioSourcesToIgnore;
    [SerializeField] private DualPlaylistController audioPlaylist;
    [SerializeField] private GameObject audioPause;
    private bool isPaused;
    
    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputManagement>();
        foreach (AudioSource snd in audioSourcesToIgnore)
        {
            snd.ignoreListenerPause = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        isPaused = input.isPaused;

        if(isPaused && !pauseMenu.activeInHierarchy && !optionsMenu.activeInHierarchy && !colecMenu.activeInHierarchy && !controlsMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            AudioListener.pause = true;
            audioPlaylist.Pause();
            audioPause.SetActive(true);

        }
        else if(isPaused && pauseMenu.activeInHierarchy && !optionsMenu.activeInHierarchy && !colecMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            AudioListener.pause = false;
            audioPlaylist.Resume();
            audioPause.SetActive(false);
        }
        else if(isPaused && optionsMenu.activeInHierarchy)
        {
            Time.timeScale = 1;
            optionsMenu.SetActive(false);
            AudioListener.pause = false;
            audioPlaylist.Resume();
            audioPause.SetActive(false);
        }
        else if(isPaused && colecMenu.activeInHierarchy)
        {
            Time.timeScale = 1;
            colecMenu.SetActive(false);
            AudioListener.pause = false;
            audioPlaylist.Resume();
            audioPause.SetActive(false);
        }
        else if(isPaused && controlsMenu.activeInHierarchy)
        {
            Time.timeScale = 1;
            controlsMenu.SetActive(false);
            AudioListener.pause = false;
            audioPlaylist.Resume();
            audioPause.SetActive(false);
        }
    }


    public void Resume()
    {
        audioPause.SetActive(false);
    }
}
