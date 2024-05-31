using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownZone : MonoBehaviour
{
    public bool IsOnPiano = false;
    public bool IsOnWater = false;
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
        if(gameObject.tag == "piano") IsOnPiano = true;
        if(gameObject.tag == "water") IsOnWater = true;
        
    }

    private void OnTriggerStay(Collider other)
    {
        // Comprobamos si el objeto tiene un Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            controlRun(rb);
        }
    }

    // Cuando un objeto sale de la zona de desaceleración
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == "piano") IsOnPiano = false;
        if (gameObject.tag == "water") IsOnWater = false;
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
        else if(isRunning && IsOnWater)
        {
            rb.MovePosition(rb.position + direction * (movementSpeed * Time.deltaTime));
        }
        else if (!isRunning && IsOnWater)
        {
            rb.MovePosition(rb.position + direction * (movementSpeed * 1.25f * Time.deltaTime));
        }
    }

}
