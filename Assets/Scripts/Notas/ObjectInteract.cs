using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    [SerializeField] private ObjectCount obj_count;
    

    void Start()
    {
        obj_count = GameObject.FindGameObjectWithTag("Player").GetComponent<ObjectCount>();
    }

    /// Este m�todo se llama cuando algo colisiona con el collider del objeto
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colision� tiene un componente Rigidbody
        if (other.tag == "Player")
        {
            obj_count.quantity = obj_count.quantity + 1;
            Destroy(gameObject);


        }
    }
}