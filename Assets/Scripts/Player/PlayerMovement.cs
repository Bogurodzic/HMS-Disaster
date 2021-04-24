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
    
    [SerializeField] private Rigidbody2D _playerRigidbody2D;
    
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
        
        _playerRigidbody2D.AddForce(new Vector2(direction, 0) * movementSpeed * Time.deltaTime, ForceMode2D.Force);
    }
    
}
