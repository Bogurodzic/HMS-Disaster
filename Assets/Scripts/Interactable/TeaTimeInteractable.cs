using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class TeaTimeInteractable : BasicInteractable
{

    protected override void AddPlayerToOperateMachine(PlayerController playerController)
    {
        playerController.SetPlayerStatus(PlayerStatus.Busy);
        _playerControllers.Add(playerController);
        Debug.Log("PLAYER SIEDZI");
    }
    
    protected override void RunMinigame()
    {
        Debug.Log("PLAYER PIJE");
    }
}
