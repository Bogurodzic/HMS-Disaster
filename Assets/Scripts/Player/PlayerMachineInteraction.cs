using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMachineInteraction : MonoBehaviour
{
    public KeyCode interactKey;
    private BasicInteractable _nearbyMachine;

    public void Update()
    {
        if (Input.GetKeyDown(interactKey) && _nearbyMachine)
        {
            _nearbyMachine.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Machine"))
        {
            _nearbyMachine = other.gameObject.GetComponent<BasicInteractable>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Machine"))
        {
            _nearbyMachine = null;
        }
    }
}
