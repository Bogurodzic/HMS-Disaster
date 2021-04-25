using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BasicInteractable : MonoBehaviour
{
    public Machines machine;

    [SerializeField] private GameObject _minigamePanelPrefab;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private ShipHitpoints _shipHitpoints;
    
    private InteractableState _state = InteractableState.Deactivated;
    
    private bool _activationStarted;
    private List<PlayerController> _playerControllers = new List<PlayerController>();
    void Start()
    {
        
    }
    
    void Update()
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

    public void Interact(PlayerController playerController)
    {
        if (_state == InteractableState.Activated)
        {
            _state = InteractableState.Blocked;
            AddPlayerToOperateMachine(playerController);
            if (CheckIfMachineCanBeStarted())
            {
                RunMinigame();
            }
        }
    }

    private void AddPlayerToOperateMachine(PlayerController playerController)
    {
        _playerControllers.Add(playerController);
    }

    private bool CheckIfMachineCanBeStarted()
    {
        return machine.playersRequired == _playerControllers.Count;
    }

    private void RunMinigame()
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

    private void ActivateMachine()
    {
        _state = InteractableState.Activated;
        Invoke("Explode", machine.waitInterval);
    }

    private void DeactivateMachine()
    {
        _activationStarted = false;
        _state = InteractableState.Deactivated;
        _spriteRenderer.color = Color.white;
    }

    private void Explode()
    {
        if (_state == InteractableState.Activated)
        {
            Debug.Log("MACHINE EXPLODED");
            _shipHitpoints.RecieveDamage(machine.damageOnExplode);
            DeactivateMachine();
        }
        else
        {
            Debug.Log("Nothing Happend");
        }
    }
}
