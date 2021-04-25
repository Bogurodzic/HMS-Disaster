using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5000;
    public float ladderSpeed = 5;

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Animator _animator;
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
        {
            direction = -1;
            _sprite.flipX = true;
        }

        if (Input.GetKey(_playerController.rightButton))
        {
            direction = 1;
            _sprite.flipX = false;
        }

        if (direction == 0)
        {
            _animator.SetBool("isRunning", false);
        }
        else
        {
            _animator.SetBool("isRunning", true);
        }
        
        transform.Translate(direction * movementSpeed * Time.deltaTime, 0, 0);
    }
    
}
