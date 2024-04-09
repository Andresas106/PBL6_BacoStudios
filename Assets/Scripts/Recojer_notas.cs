using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recojer_notas : MonoBehaviour
{
    /// Este método se llama cuando algo colisiona con el collider del objeto
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colisionó tiene un componente Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Destruye la moneda
            Destroy(gameObject);
        }
    }
}
