using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIN_OUT : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;
    [SerializeField] private float TimetoFade; 



    // Update is called once per frame
    void Update()
    {
        if(fadeIn)
        {
            if(canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += TimetoFade * Time.deltaTime;
                if(canvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if(fadeOut)
        {
            if (canvasGroup.alpha >= 0)
            {
                canvasGroup.alpha -= TimetoFade * Time.deltaTime;
                if (canvasGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
        }
    }

    public void FadeIN()
    {
        fadeIn = true;
    }

    public void FadeOUT()
    {
        fadeOut = true;
    }
}
