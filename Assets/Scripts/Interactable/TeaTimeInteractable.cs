using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class TeaTimeInteractable : BasicInteractable
{
    public float teatimeDuration;

    protected override void AddPlayerToOperateMachine(PlayerController playerController)
    {
        playerController.SetPlayerStatus(PlayerStatus.Busy);
        _playerControllers.Add(playerController);
        Debug.Log("PLAYER SIEDZI");
        playerController.Sit();
    }
    
    protected override void RunMinigame()
    {
        foreach (var playerController in _playerControllers)
        {
            playerController.Drink();
        }

        Debug.Log("PLAYER PIJE");
        Invoke("EndDrinking", teatimeDuration);
    }

    private void EndDrinking()
    {
        foreach (var playerController in _playerControllers)
        {
            playerController.StopDrinking();
            playerController.SetPlayerStatus(PlayerStatus.Free);
        }
        
        DeactivateMachine();
    }
}
