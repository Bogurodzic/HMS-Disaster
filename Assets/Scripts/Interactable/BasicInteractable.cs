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
            _activationStarted = true;
            float activationTime = Random.Range(machine.activationInterval/2, machine.activationInterval);
            Invoke("ActivateMachine", activationTime);
        }

        if (_state == InteractableState.Activated)
        {
            if (_spriteRenderer.color == Color.red)
            {
                _spriteRenderer.color = Color.blue;
            }
            else
            {
                _spriteRenderer.color = Color.red;
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

    protected void AddPlayerToOperateMachine(PlayerController playerController)
    {
        playerController.SetPlayerStatus(PlayerStatus.Busy);
        _playerControllers.Add(playerController);
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
            }
            else
            {
                _shipHitpoints.RecieveDamage(machine.damageOnExplode);
                DeactivateMachine();
            }
        };
    }

    protected virtual void ActivateMachine()
    {
        _state = InteractableState.Activated;
        Invoke("Explode", machine.waitInterval);
    }

    public virtual void DeactivateMachine()
    {
        _activationStarted = false;
        _state = InteractableState.Deactivated;
        _spriteRenderer.color = Color.white;
        
        foreach (var playerController in _playerControllers)
        {
            playerController.SetPlayerStatus(PlayerStatus.Free);
        }
    }

    protected void Explode()
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
