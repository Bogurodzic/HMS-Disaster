using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5000;
    public float ladderSpeed = 5;
    
    public KeyCode leftController;
    public KeyCode rightController;
    public KeyCode upController;
    public KeyCode downController;
    void Update()
    {
        HandleMovingPlayerHorizontally();
    }

    private void HandleMovingPlayerHorizontally()
    {
        MovePlayerHorizontally();
    }

    private void MovePlayerHorizontally()
    {
        float direction = 0;

        if (Input.GetKey(leftController))
            direction = -1;
        if (Input.GetKey(rightController))
            direction = 1;
        
        transform.Translate(direction * movementSpeed * Time.deltaTime, 0, 0);
    }
    
}
