using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleActivator : MonoBehaviour
{
    public ParticleSystem particleSystem;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra en la zona es el que te interesa
        if (other.CompareTag("satelit")) 
        {
            particleSystem.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Verifica si el objeto que sale de la zona es el que te interesa
        if (other.CompareTag("satelit")) 
        {
            particleSystem.Stop();
        }
    }
}