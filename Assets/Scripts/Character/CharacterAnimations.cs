using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private InputManagement input;

    private Vector2 currentMovementInput;
    private bool isRunning;
    private CharacterMovement playerMovement;
    private float _groundCheckRadius = 1.0f;

    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<InputManagement>();
        playerMovement = GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentMovementInput = input.CurrentMovementInput;
        isRunning = input.isRunning;

        if ((currentMovementInput.x != 0 || currentMovementInput.y != 0) && playerMovement.enabled)
        {
            animator.SetBool("OnWalk", true);
        }
        else
        {
            animator.SetBool("OnWalk", false);
        }

        if (isRunning && playerMovement.enabled && (currentMovementInput.x != 0 || currentMovementInput.y != 0))
        {
            animator.SetBool("OnRun", true);

        }
        else
        {
            animator.SetBool("OnRun", false);
        }

        bool isGrounded = Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundMask);

        if (!isGrounded && playerMovement.enabled)
        {
            animator.SetBool("OnJump", true);
        }
        else
        {
            animator.SetBool("OnJump", false);
        }
    }
}
