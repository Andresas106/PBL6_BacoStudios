using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    private InputManagement input;
    private Rigidbody _rb;
    private GravityPlayer _gp;

    private Vector2 currentMovementInput;
    private Vector3 direction;
    private bool isMovementPressed;
    private bool isJumping;
    private bool isRunning;
    private float _groundCheckRadius = 1.0f;

    [SerializeField] private float movementSpeed = 3.0f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float JumpForce;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        input = GetComponent<InputManagement>();
        _gp = GetComponent<GravityPlayer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        handleMovement();
        handleRotation();
        handleJump();
    }


    void handleMovement()
    {
        currentMovementInput = input.CurrentMovementInput;
        isRunning = input.isRunning;

        if (currentMovementInput.x != 0 || currentMovementInput.y != 0)
        {
            isMovementPressed = true;
        }
        else
        {
            isMovementPressed = false;
        }

        // Calcular la direcci�n del movimiento
        Vector3 _moveDirection = new Vector3(currentMovementInput.x, 0.0f, currentMovementInput.y);

        


        Vector3 direction = transform.forward * _moveDirection.z;

        //Vector3 velocity = direction * movementSpeed;
       
        if (isRunning)
        {
             _rb.MovePosition(_rb.position + direction * (movementSpeed * 2 * Time.fixedDeltaTime));
        }
        else
        {
            _rb.MovePosition(_rb.position + direction * (movementSpeed * Time.fixedDeltaTime));
        }




    }

    void handleRotation()
    {


        // Solo rotamos al personaje si hay entrada de movimiento
        if (isMovementPressed)
        {
            // Obtener la direcci�n de movimiento desde la entrada del jugador
            Vector3 _moveDirection = new Vector3(currentMovementInput.x, 0.0f, currentMovementInput.y);

            Quaternion rightDirection = Quaternion.Euler(0f, _moveDirection.x * (3000 * Time.fixedDeltaTime), 0f);
            Quaternion newRotation = Quaternion.Slerp(_rb.rotation, _rb.rotation * rightDirection, Time.fixedDeltaTime * 3f);
            _rb.MoveRotation(newRotation);
        }
    }

    void handleJump()
    {
       
        isJumping = input.isJumping;

        bool isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundMask);
        if (isJumping && isGrounded)
        {
            _rb.AddForce(-_gp.Direction * JumpForce, ForceMode.Impulse);
        }
    }
}
