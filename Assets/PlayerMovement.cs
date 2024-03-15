using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje
    public float jumpForce = 0.5f; // Fuerza del salto
    public float jumpTime = 0.5f; // Duración máxima del salto en segundos
    public float airControlMultiplier = 0.5f;
    private float jumpTimeCounter; // Contador del tiempo de salto
    private bool isJumping; // Indica si el jugador está saltando
    private Rigidbody rb;
    private Transform planetCenter; // Centro del planeta

    public float groundDistance = 0.5f; // Distancia para detectar el suelo
    public LayerMask groundMask; // Máscara para detectar el suelo
    // Start is called before the first frame update
    void Start()
    {
        jumpTimeCounter = jumpTime;
        rb = GetComponent<Rigidbody>();
        planetCenter = GameObject.FindGameObjectWithTag("PlanetCenter").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Obtener la entrada del jugador para el movimiento
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        bool isGrounded = Physics.Raycast(transform.position, -transform.up, groundDistance, groundMask);

        if(isGrounded)
        {
            if (!isJumping) // Permitir control en el aire si no se excede la velocidad
            {

                transform.Translate(movement * moveSpeed * Time.deltaTime);
            }

            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                Vector3 jumpDirection = (transform.position - planetCenter.position).normalized;
                rb.velocity = Vector3.zero; // Resetear la velocidad vertical
                rb.AddForce(jumpDirection * jumpForce, ForceMode.VelocityChange);
                isJumping = true;
                jumpTimeCounter = jumpTime;
            }
        }
        else
        {
            // Aplicar control reducido en el aire
            transform.Translate(movement * moveSpeed * airControlMultiplier * Time.deltaTime);
        }
        

        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
}
