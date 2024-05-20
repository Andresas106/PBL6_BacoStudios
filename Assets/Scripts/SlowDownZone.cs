using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownZone : MonoBehaviour
{
    public bool IsOnPiano = false;
    [SerializeField] private float movementSpeed = 10f;
    [SerializeField] private Transform player;

    private Vector2 currentMovementInput;
    private bool isRunning;
    private InputManagement input;



    void Start()
    {
        input = GetComponent<InputManagement>();
    }

    // Cuando un objeto entra en la zona de desaceleración
    private void OnTriggerEnter(Collider other)
    {
        IsOnPiano = true;
        
    }

    private void OnTriggerStay(Collider other)
    {
        // Comprobamos si el objeto tiene un Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Reducimos la velocidad del objeto
            controlRun(rb);
        }
    }

    // Cuando un objeto sale de la zona de desaceleración
    private void OnTriggerExit(Collider other)
    {
        IsOnPiano = false;
    }

    private void controlRun(Rigidbody rb)
    {
        currentMovementInput = input.CurrentMovementInput;
        isRunning = input.isRunning;

        Vector3 _moveDirection = new Vector3(currentMovementInput.x, 0.0f, currentMovementInput.y);

        Vector3 direction = player.forward * _moveDirection.z;

        if (isRunning && IsOnPiano)
        {
            rb.MovePosition(rb.position + direction * (movementSpeed * 3 * Time.deltaTime));
        }
        else if(!isRunning && IsOnPiano)
        {
            rb.MovePosition(rb.position + direction * (movementSpeed * 2 * Time.deltaTime));
        }
    }

}
