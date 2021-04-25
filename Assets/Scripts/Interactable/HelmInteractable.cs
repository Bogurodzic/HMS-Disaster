using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class HelmInteractable : BasicInteractable
{
    [SerializeField] private PeriscopeInteractable _periscopeInteractable;

    
    protected override void ActivateMachine()
    {
        _state = InteractableState.Activated;
        _periscopeInteractable.SetState(InteractableState.Activated);
        Invoke("Explode", machine.waitInterval);
    }

    protected override void DeactivateMachine()
    {
        _activationStarted = false;
        _state = InteractableState.Deactivated;
        _periscopeInteractable.SetState(InteractableState.Deactivated);
        _spriteRenderer.color = Color.white;
        foreach (var playerController in _playerControllers)
        {
            playerController.SetPlayerStatus(PlayerStatus.Free);
        }
    }
}
