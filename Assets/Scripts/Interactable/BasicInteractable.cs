using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BasicInteractable : MonoBehaviour
{
    public Machines machine;

    [SerializeField] protected GameObject _minigamePanelPrefab;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
    [SerializeField] protected ShipHitpoints _shipHitpoints;
    [SerializeField] protected AlarmController _alarmController;
    
    protected InteractableState _state = InteractableState.Deactivated;
    
    protected bool _activationStarted;
    protected List<PlayerController> _playerControllers = new List<PlayerController>();
    public void Start()
    {
        
    }
    
    public virtual void Update()
    {
        if (!_activationStarted)
        {
            if (Random.Range(1, 100) <= DifficultLevel.PercentChanceForActivatingNextMachine())
            {
                ActiveMachines.AddActiveMachine();
                _activationStarted = true;
                float activationTime = Random.Range(machine.activationInterval/3, machine.activationInterval);
                Invoke("ActivateMachine", activationTime);
            }
        }
    }

    public virtual void Interact(PlayerController playerController)
    {
        if (_state == InteractableState.Activated)
        {
            AddPlayerToOperateMachine(playerController);
            if (CheckIfMachineCanBeStarted())
            {
                _state = InteractableState.Blocked;
                RunMinigame();
            }
        }
    }

    protected virtual void AddPlayerToOperateMachine(PlayerController playerController)
    {
        if (_playerControllers.Count == 0)
        {
            playerController.SetPlayerStatus(PlayerStatus.Busy);
            _playerControllers.Add(playerController); 
        }

        if (_playerControllers.Count > 0)
        {
            if (_playerControllers[0].downButton != playerController.downButton)
            {
                playerController.SetPlayerStatus(PlayerStatus.Busy);
                _playerControllers.Add(playerController); 
            }
        }

    }

    protected bool CheckIfMachineCanBeStarted()
    {
        return machine.playersRequired == _playerControllers.Count;
    }

    protected virtual void RunMinigame()
    {
        MiniGamePanel miniGamePanel = Instantiate(_minigamePanelPrefab, transform.position, transform.rotation).GetComponent<MiniGamePanel>();
        miniGamePanel.InitialiseGame(_playerControllers, machine.gameType);
        miniGamePanel.OnSuccess += success =>
        {
            if (success)
            {
                DeactivateMachine();
                Score.AddScore(DifficultLevel.GetDifficultLevel());
            }
            else
            {
                _shipHitpoints.RecieveDamage(machine.damageOnExplode);
                DeactivateMachine();
            }
        };
    }

    public virtual void ActivateMachine()
    {
        _alarmController.TurnOn();
        _state = InteractableState.Activated;
        Invoke("Explode", machine.waitInterval);
    }

    public virtual void DeactivateMachine()
    {
        if (machine.gameType != GameType.TEA && machine.gameType != GameType.PERISCOPE)
        {
            ActiveMachines.RemoveActiveMachine();
        }
        
        _alarmController.TurnOff();
        _activationStarted = false;
        _state = InteractableState.Deactivated;
        
        foreach (var playerController in _playerControllers)
        {
            playerController.SetPlayerStatus(PlayerStatus.Free);
        }
        
        _playerControllers.Clear();
    }

    protected virtual void Explode()
    {
        if (_state == InteractableState.Activated)
        {
            _shipHitpoints.RecieveDamage(machine.damageOnExplode);
            DeactivateMachine();
        }
    }

    public void SetState(InteractableState state)
    {
        _state = state;
    }

    public InteractableState GetState()
    {
        return _state;
    }
}
