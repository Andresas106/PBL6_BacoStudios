using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tobogan : MonoBehaviour
{
    public Transform Target;
    public GameObject ThePlayer;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered by: " + other.name);
        ThePlayer.transform.position = Target.transform.position;
    }
}
