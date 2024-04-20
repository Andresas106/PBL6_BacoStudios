using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
    private InputManagement input;

    private Vector2 currentMovementInput;
    private bool isJumping;
    private bool isRunning;
    private CharacterMovement playerMovement;

    [SerializeField] private Animator animator;

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
        isJumping = input.isJumping;

        if ((currentMovementInput.x != 0 || currentMovementInput.y != 0) && playerMovement.enabled)
        {
            animator.SetBool("OnWalk", true);
        }
        else
        {
            animator.SetBool("OnWalk", false);
        }

        if (isRunning && playerMovement.enabled)
        {
            animator.SetBool("OnRun", true);

        }
        else
        {
            animator.SetBool("OnRun", false);
        }

        if(isJumping && playerMovement.enabled)
        {
            //animator.SetBool()
        }
    }
}
