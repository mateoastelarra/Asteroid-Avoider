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

    private void FixedUpdate() 
    {
        if (movementDirection == Vector3.zero){return;}

        RB.AddForce(movementDirection * forceMagnitud, ForceMode.Force);

        RB.velocity = Vector3.ClampMagnitude(RB.velocity, maxVelocity);
    }
}
