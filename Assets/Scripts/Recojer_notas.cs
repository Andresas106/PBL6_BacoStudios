using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recojer_notas : MonoBehaviour
{
    /// Este m�todo se llama cuando algo colisiona con el collider del objeto
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colision� tiene un componente Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Destruye la moneda
            Destroy(gameObject);
        }
    }
}
