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
    
    private bool _ladderMovementEnabled;
    private bool _duringLadderMovement;
    void Start()
    {
        
    }

    void Update()
    {
        //HandleClimbingLadder();
        HandleMovingPlayerHorizontally();
    }

    private void HandleMovingPlayerHorizontally()
    {
        //if (!_duringLadderMovement)
        //{
            MovePlayerHorizontally();
        //}
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

    private void HandleClimbingLadder()
    {
        if ((Input.GetKey(upController) || Input.GetKey(downController)) && _ladderMovementEnabled)
        {
            ClimbLadder();
        }
    }
    
    private void ClimbLadder()
    {
        float ladderDirection = 0;
        
        if (Input.GetKey(downController))
            ladderDirection = -1;
        if (Input.GetKey(upController))
            ladderDirection = 1;
        
        _duringLadderMovement = true;
        gameObject.layer = 9;
        _playerRigidbody2D.velocity = Vector2.zero;
        transform.Translate(0,ladderDirection * ladderSpeed * Time.deltaTime,0);
    }

    private void EndClimbing()
    {
        gameObject.layer = 8;
        _duringLadderMovement = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            Debug.Log("LAdder in");
            EnableLadderMovement();
        }

        if (other.gameObject.CompareTag("LadderEnd") && _duringLadderMovement)
        {
            Debug.Log("LAdder End");
            DisableLadderMovement();
            EndClimbing();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ladder"))
        {
            Debug.Log("LAdder out");
            DisableLadderMovement();
        }    
    }

    private void EnableLadderMovement()
    {
        _ladderMovementEnabled = true;
    }

    private void DisableLadderMovement()
    {
        _ladderMovementEnabled = false;
    }
}
