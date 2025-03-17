using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    private Vector2 aimInput;
    private float rotationAngle;

    private PlayerIPActions playerInputActions;

    private void Awake()
    {
        playerInputActions = new PlayerIPActions();  // Use your generated input class here
        // Cursor.visible = false;

    }

    private void OnEnable()
    {
        playerInputActions.Enable();
        playerInputActions.Player.Look.performed += OnAimInput;
        playerInputActions.Player.Look.canceled += OnAimInput;
    }

    private void OnDisable()
    {
        playerInputActions.Player.Look.performed -= OnAimInput;
        playerInputActions.Player.Look.canceled -= OnAimInput;
        playerInputActions.Disable();
    }

    private void Update()
    {
        // Rotate the player to face the mouse direction
        RotatePlayer();
    }

    // Called when aim input (mouse position) is detected
    private void OnAimInput(InputAction.CallbackContext context)
    {
        aimInput = context.ReadValue<Vector2>();
    }

    // Function to rotate the player based on the mouse position
    private void RotatePlayer()
    {
        // Get the direction from the player to the mouse position (world space)
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(aimInput);  // Convert mouse position to world space
        mousePosition.z = 0f;  // Keep the z-axis unchanged to stay in 2D space

        // Calculate the angle between the player and the mouse position
        Vector3 direction = (mousePosition - transform.position).normalized;  // Direction from player to mouse
        rotationAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;  // Get the angle in degrees

        // Rotate the player to face the mouse direction
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotationAngle));
    }
}
