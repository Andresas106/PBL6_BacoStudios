using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{

    public float gravity = 9.81f; // Gravedad por defecto
    public Transform gravityCenter; // Centro de la gravedad

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Desactiva la gravedad por defecto de Unity
    }

    void FixedUpdate()
    {
        if (gravityCenter != null)
        {
            // Calcula el vector de la fuerza de gravedad
            Vector3 gravityDirection = (gravityCenter.position - transform.position).normalized;
            Vector3 localUp = transform.up;

            // Aplica la fuerza de gravedad
            rb.AddForce(gravityDirection * gravity * rb.mass);

            // Rota el personaje para que su up sea la dirección opuesta de la gravedad
            Quaternion targetRotation = Quaternion.FromToRotation(localUp, -gravityDirection) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 50 * Time.deltaTime);
        }
    }
}
