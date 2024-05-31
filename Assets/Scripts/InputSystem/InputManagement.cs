using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagement : MonoBehaviour
{
    private PlayerControllerInput input;

    public Vector2 CurrentMovementInput { get; private set; }
    public bool isJumping { get; private set; }
    public bool isRunning { get; private set; }
    public bool isPaused { get; private set; }
    public bool isInteracting { get; private set; }
    // Start is called before the first frame update
    void Awake()
    {
        input = new PlayerControllerInput();

        //Esto se ejecuta cuando el personaje pulsa AWSD o el left stick del gamepad
        input.Player.Move.started += onMovementInput;
        input.Player.Move.canceled += onMovementInput;
        input.Player.Move.performed += onMovementInput;


        input.Player.Jump.started += onJumpInput;
        input.Player.Jump.canceled += onJumpInput;

        input.Player.Run.started += onRunInput;
        input.Player.Run.canceled += onRunInput;

        input.Player.Pause.performed += onPauseInput;  

        input.Player.Interact.started += onInteractInput;
        input.Player.Interact.canceled += onInteractInput;
    }

    void Update()
    {
        isPaused = false;
    }

    void FixedUpdate()
    {
        isJumping = false;
    }

    private void onInteractInput(InputAction.CallbackContext context)
    {

        isInteracting = context.ReadValueAsButton();
    }

    private void onPauseInput(InputAction.CallbackContext context)
    {

        isPaused = context.ReadValueAsButton();
    }

    private void onRunInput(InputAction.CallbackContext context)
    {
        
        isRunning = context.ReadValueAsButton();
    }

    private void onJumpInput(InputAction.CallbackContext context)
    {
        
        isJumping = context.ReadValueAsButton();
    }


    private void onMovementInput(InputAction.CallbackContext context)
    {
        //Al detectar los inputs del teclado o gamepad se tendran dos valores de x e y
        CurrentMovementInput = context.ReadValue<Vector2>();
    }

    private void OnEnable()
    {
        input.Player.Enable();
    }

    private void OnDisable()
    {
        input.Player.Disable();
    }
}
