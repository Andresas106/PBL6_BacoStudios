using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject menu1Panel;
    [SerializeField] private GameObject menu2Panel;
    [SerializeField] private GameObject colecPanel;
    [SerializeField] private GameObject colec2Panel;

    public int i;
    public int c;

    void Start()
    {
        Time.timeScale = 1;
    }

    public void LoadLevel1() //Cargar nivel1
    {
        SceneManager.LoadScene("Level1_FigaFlawas");
    }

    public void LoadLevel2() //Cargar nivel2
    {
        SceneManager.LoadScene("Level2_TheTyets");
    }


    public void LoadOptionsFromMenu()
    {
        optionsPanel.SetActive(true);
        mainPanel.SetActive(false);
    }
    public void LoadOptionsFromMenu1()
    {
        optionsPanel.SetActive(true);
        menu1Panel.SetActive(false);
        i = 1;
    }
    public void LoadOptionsFromMenu2()
    {
        optionsPanel.SetActive(true);
        menu2Panel.SetActive(false);
        i = 2;
    }
    public void BackToMenuFromOptions()
    {
        if (i == 1)
        {
            optionsPanel.SetActive(false);
            menu1Panel.SetActive(true);
        }
        else if (i == 2)
        {
            optionsPanel.SetActive(false);
            menu2Panel.SetActive(true);
        }
        else
        {
            optionsPanel.SetActive(false);
            mainPanel.SetActive(true);
        }
    }
    public void LoadColecFromMenu1()
    {
        menu1Panel.SetActive(false);
        colecPanel.SetActive(true);
        c = 1;
    }
    public void LoadColecFromMenu2()
    {
        menu2Panel.SetActive(false);
        colecPanel.SetActive(true);
        c = 2;
    }
    public void BackToMenuFromColec()
    {
        if (c == 1)
        {
            colecPanel.SetActive(false);
            menu1Panel.SetActive(true);
        }
        else
        {
            colecPanel.SetActive(false);
            menu2Panel.SetActive(true);
        }
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuMain");
        mainPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void closePanel1()
    {
        menu1Panel.SetActive(false);
    }

    public void closePanel2()
    {
        menu2Panel.SetActive(false);
    }
}
