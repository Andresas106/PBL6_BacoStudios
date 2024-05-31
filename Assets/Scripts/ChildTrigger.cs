using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTrigger : MonoBehaviour
{
    // Reference to the parent component
    private OrbitAround parentComponent;

    void Start()
    {
        // Find the parent component
        parentComponent = GetComponentInParent<OrbitAround>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Notify the parent about the trigger event
        if (other.CompareTag("Player"))
        {
            parentComponent.OnPlayerEnterTrigger();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Notify the parent about the trigger event
        if (other.CompareTag("Player"))
        {
            parentComponent.OnPlayerExitTrigger();
        }
    }
}
