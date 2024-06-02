using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerManage : MonoBehaviour
{

    [SerializeField] private GameObject sticker1;
    [SerializeField] private GameObject sticker2;

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.HasKey("sticker1"))
        {
            int code = PlayerPrefs.GetInt("sticker1");
            if(code == 1)
            {
                sticker1.SetActive(true);
                sticker2.SetActive(false);
            }
            else
            {
                sticker1.SetActive(false);
                sticker2.SetActive(true);
            }
        }

        if (PlayerPrefs.HasKey("sticker2"))
        {
            int code = PlayerPrefs.GetInt("sticker2");
            if (code == 1)
            {
                sticker2.SetActive(true);
                sticker1.SetActive(false);
            }
            else
            {
                sticker2.SetActive(false);
                sticker1.SetActive(true);
            }
        }
    }
}
