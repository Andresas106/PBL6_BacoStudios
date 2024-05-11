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
            }
            else
            {
                sticker1.SetActive(false);
            }
        }

        if (PlayerPrefs.HasKey("sticker2"))
        {
            int code = PlayerPrefs.GetInt("sticker2");
            if (code == 1)
            {
                sticker2.SetActive(true);
            }
            else
            {
                sticker2.SetActive(false);
            }
        }
    }
}
