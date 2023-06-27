using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            position = touch.position;
            Vector3 auxPosition = mainCamera.ScreenToWorldPoint(new Vector3 (position.x, position.y, 0));
            position = new Vector2(auxPosition.x, auxPosition.y);
            Debug.Log(position);
        }
    }
}
