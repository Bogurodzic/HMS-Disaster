using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoorInteraction : MonoBehaviour
{
    private GameObject _nearbyDoors;
    
    void Start()
    {
        
    }

    void Update()
    {
        TryUseDoors();
    }

    private void TryUseDoors()
    {
        if (_nearbyDoors && Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = _nearbyDoors.GetComponent<Door>().exitDoors.transform.position;
        }
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
