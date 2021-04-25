using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5000;
    public float ladderSpeed = 5;

    [SerializeField] private PlayerController _playerController;
    void UpdateF()
    {
    }

    private void FixedUpdate()
    {
        HandleMovingPlayerHorizontally();

    }

    private void HandleMovingPlayerHorizontally()
    {
        if (_playerController.CanPlayerMove())
        {
            MovePlayerHorizontally();
        }
    }

    private void MovePlayerHorizontally()
    {
        float direction = 0;

        if (Input.GetKey(_playerController.leftButton))
            direction = -1;
        if (Input.GetKey(_playerController.rightButton))
            direction = 1;
        
        transform.Translate(direction * movementSpeed * Time.deltaTime, 0, 0);
    }
    
}
