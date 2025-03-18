// Written by Jay Gunderson
// 03/16/2025
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    // Variables
    [SerializeField] private float movementSpeed = 5f;
    private Vector2 movementInput;
    private Rigidbody2D rb;
    private PlayerIPActions playerInputActions;


    // Methods
    private void Awake()
    {
        rb =  GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerIPActions();

    }
    private void OnEnable()
    {
        playerInputActions.Enable();
        playerInputActions.Player.Move.performed += OnMovementInput;
        playerInputActions.Player.Move.canceled += OnMovementInput;
    }
    private void OnDisable()
    {
        playerInputActions.Player.Move.performed -= OnMovementInput;
        playerInputActions.Player.Move.canceled -= OnMovementInput;
        playerInputActions.Disable();
    }


    private void FixedUpdate()
    {
        rb.velocity = movementInput * movementSpeed; 
    }
    private void OnMovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }


}