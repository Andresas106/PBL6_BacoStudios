using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeCode : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imageMute;
    
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("audioVolume", 0.5f);
        AudioListener.volume = slider.value;
        CheckMute();
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("audioVolume", sliderValue);
        AudioListener.volume = slider.value;
        CheckMute();
    }
    
    public void CheckMute()
    {
        if (sliderValue == 0)
        {
//            imageMute.enable = true;
        }
        else
        {
//            imageMute.enable = false;
        }
    }
}
