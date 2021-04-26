using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using DefaultNamespace;
using UnityEngine;

public class PeriscopeInteractable : BasicInteractable
{
    public override void Update()
    {

    }

    public void TurnOn()
    {
        _alarmController.TurnOn();
        SetState(InteractableState.Activated);
    }
    
    public override void DeactivateMachine()
    {
        _alarmController.TurnOff();
        _state = InteractableState.Deactivated;
        
        foreach (var playerController in _playerControllers)
        {
            playerController.SetPlayerStatus(PlayerStatus.Free);
        }
        
        _playerControllers.Clear();
        
        Debug.Log("Deactivated periscope");
        Invoke("ClearActivationStarted", Random.Range(0f, 2f));
    }

    protected override void RunMinigame()
    {
        
    }
}
