using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMachineInteraction : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    private BasicInteractable _nearbyMachine;

    public void Update()
    {
        if (Input.GetKeyDown(_playerController.activateButton) && _nearbyMachine)
        {
            _nearbyMachine.Interact(_playerController);
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
