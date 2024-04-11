using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesLogic : MonoBehaviour
{
    private void awake()
    {
        var noDestroy = FindObjectsOfType<ScenesLogic>();
        if (noDestroy.Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
    }
}
