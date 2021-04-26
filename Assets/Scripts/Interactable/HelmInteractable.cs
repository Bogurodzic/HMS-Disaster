using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class HelmInteractable : BasicInteractable
{
    [SerializeField] private PeriscopeInteractable _periscopeInteractable;

    private bool _helmMinigameReadyToStart;
    private bool _helmMinigameStarted;

    public override void Update()
    {
        if (!_activationStarted)
        {
            _activationStarted = true;
            float activationTime = Random.Range(machine.activationInterval/2, machine.activationInterval);
            Invoke("ActivateMachine", activationTime);
        }
        

        if (!_helmMinigameReadyToStart && !_helmMinigameStarted && _periscopeInteractable.GetState() == InteractableState.Blocked && GetState() == InteractableState.Blocked)
        {
            _helmMinigameReadyToStart = true;
        }

        if (_helmMinigameReadyToStart && !_helmMinigameStarted)
        {
            _helmMinigameStarted = true;
            RunMinigame();
        }
    }
    
    public override void ActivateMachine()
    {
        _state = InteractableState.Activated;
        _periscopeInteractable.TurnOn();
        _alarmController.TurnOn();
        Invoke("Explode", machine.waitInterval);
    }

    public override void DeactivateMachine()
    {
        _alarmController.TurnOff();
        _activationStarted = false;
        _state = InteractableState.Deactivated;
        _spriteRenderer.color = Color.white;
        _periscopeInteractable.DeactivateMachine();
        
        foreach (var playerController in _playerControllers)
        {
            playerController.SetPlayerStatus(PlayerStatus.Free);
        }
        
        _playerControllers.Clear();
    }
    
    public override void Interact(PlayerController playerController)
    {
        if (_state == InteractableState.Activated)
        {
            AddPlayerToOperateMachine(playerController);
            if (CheckIfMachineCanBeStarted())
            {
                _state = InteractableState.Blocked;
            }
        }
    }
    
    protected override void RunMinigame()
    {
        MiniGamePanel miniGamePanel = Instantiate(_minigamePanelPrefab, transform.position, transform.rotation).GetComponent<MiniGamePanel>();
        miniGamePanel.InitialiseGame(_playerControllers, machine.gameType);
        miniGamePanel.OnSuccess += success =>
        {
            if (success)
            {
                DeactivateMachine();
            }
            else
            {
                _shipHitpoints.RecieveDamage(machine.damageOnExplode);
                DeactivateMachine();
            }
        };
    }
}
