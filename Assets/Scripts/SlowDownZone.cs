using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownZone : MonoBehaviour
{
    public float slowDownFactor = 0.5f; // Factor de desaceleración

    // Cuando un objeto entra en la zona de desaceleración
    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos si el objeto tiene un Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Reducimos la velocidad del objeto
            rb.velocity *= slowDownFactor;
        }
    }

    // Cuando un objeto sale de la zona de desaceleración
    private void OnTriggerExit(Collider other)
    {
        // Comprobamos si el objeto tiene un Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Restauramos la velocidad original del objeto
            rb.velocity /= slowDownFactor;
        }
    }
}
