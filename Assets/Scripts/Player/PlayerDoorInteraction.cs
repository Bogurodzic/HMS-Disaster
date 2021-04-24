using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerDoorInteraction : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Rigidbody2D _playerRigidbody2D;
    private GameObject _nearbyDoors;
    private Vector3 _exitPosition;
    
    void Start()
    {
        
    }

    void Update()
    {
        TryUseDoors();
    }

    private void TryUseDoors()
    {
        if (_nearbyDoors)
        {
            Door door = _nearbyDoors.GetComponent<Door>();
            KeyCode requiredKeyCodeToUseDoors = door.doorFloor == DoorFloor.LOWER
                ? _playerMovement.upController
                : _playerMovement.downController;
            if (Input.GetKeyDown(requiredKeyCodeToUseDoors))
            {
                UseDoor(door);
            }
        }
    }

    private void UseDoor(Door door)
    {
        _exitPosition = door.exitDoors.transform.position;
        transform.position = new Vector3(9999, 9999, 9999);
        Invoke("ExitDoor", 2f);
    }

    private void ExitDoor()
    {
        _playerRigidbody2D.velocity = Vector2.zero;
        transform.position = _exitPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            _nearbyDoors = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            _nearbyDoors = null;
        }
    }
}
