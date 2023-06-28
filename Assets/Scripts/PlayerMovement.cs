using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 position;
    
    void Start()
    {
        mainCamera = Camera.main;
    }

    
    void Update()
    {

        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            position = Touchscreen.current.primaryTouch.position.ReadValue();
            Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3 (position.x, position.y, 0));
            position = new Vector2(worldPosition.x, worldPosition.y);
            Debug.Log(position);
        }
    }
}
