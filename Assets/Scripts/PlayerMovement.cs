using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float forceMagnitud;
    [SerializeField] private float maxVelocity;
    private Vector3 movementDirection;
    private Camera mainCamera;
    private Vector2 position;
    private Rigidbody RB;
    
    void Start()
    {
        mainCamera = Camera.main;
        RB = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        KeepPlayerOnScreen();
        ProcessInput();
    }

    private void FixedUpdate() 
    {
        if (movementDirection == Vector3.zero){return;}

        RB.AddForce(movementDirection * forceMagnitud, ForceMode.Force);

        RB.velocity = Vector3.ClampMagnitude(RB.velocity, maxVelocity);
    }

    private void ProcessInput()
    {
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            position = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3 (position.x, position.y, 0));
            
            movementDirection = worldPosition - transform.position;
            movementDirection.z = 0;
            movementDirection.Normalize();
        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }

    private void KeepPlayerOnScreen()
    {
        Vector3 newPosition = transform.position;

        Vector3 viewPortPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (viewPortPosition.x < 0 || viewPortPosition.x > 1)
        {
            newPosition.x = - newPosition.x + 0.1f * Mathf.Sign(viewPortPosition.x);
        }
        if (viewPortPosition.y < 0 || viewPortPosition.y > 1)
        {
            newPosition.y = - newPosition.y + 0.4f * Mathf.Sign(viewPortPosition.y);;
        }

        transform.position = newPosition; 
    }
}
