using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    FadeIN_OUT fade;
    // Start is called before the first frame update
    void Start()
    {
        fade = GetComponent<FadeIN_OUT>();

        fade.FadeOUT();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
