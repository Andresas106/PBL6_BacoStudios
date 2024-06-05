using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntradaManager : MonoBehaviour
{

    [SerializeField] private GameObject entrada1;
    [SerializeField] private GameObject entrada2;

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.HasKey("entrada1"))
        {
            int code = PlayerPrefs.GetInt("entrada1");
            if(code == 1)
            {
                entrada1.SetActive(true);
            }
            else
            {
                entrada1.SetActive(false);
            }
        }

        if (PlayerPrefs.HasKey("entrada2"))
        {
            int code = PlayerPrefs.GetInt("entrada2");
            if (code == 1)
            {
                entrada2.SetActive(true);
            }
            else
            {
                entrada2.SetActive(false);
            }
        }
    }
}

