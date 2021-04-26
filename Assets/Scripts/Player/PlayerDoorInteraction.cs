using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerDoorInteraction : MonoBehaviour
{
    public float doorTravelDuration = 2;
    public AudioClip doorSound;

    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Rigidbody2D _playerRigidbody2D;
    [SerializeField] private AudioSource _audioSource;
    
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
                ? _playerController.upButton
                : _playerController.downButton;
            if (Input.GetKeyDown(requiredKeyCodeToUseDoors))
            {
                UseDoor(door);
            }
        }
    }

    private void UseDoor(Door door)
    {
        _audioSource.clip = doorSound;
        _audioSource.Play();
        _exitPosition = door.exitDoors.transform.position;
        transform.position = new Vector3(9999, 9999, 9999);
        Invoke("ExitDoor", doorTravelDuration);
    }

    private void ExitDoor()
    {
        _audioSource.clip = doorSound;
        _audioSource.Play();
        _playerRigidbody2D.velocity = Vector2.zero;
        transform.position = _exitPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            _nearbyDoors = other.gameObject;
            other.gameObject.GetComponent<Door>().ShowDoorIndicator();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            _nearbyDoors = null;
            other.gameObject.GetComponent<Door>().HideDoorIndicator();
        }
    }
}
