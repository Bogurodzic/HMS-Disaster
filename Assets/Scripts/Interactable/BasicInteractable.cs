using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BasicInteractable : MonoBehaviour
{
    public int activationInterval;
    public int waitInterval;
    
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private InteractableState _state = InteractableState.Deactivated;
    private bool _activationStarted;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (!_activationStarted)
        {
            _activationStarted = true;
            float activationTime = Random.Range(activationInterval/2, activationInterval);
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

    private void ActivateMachine()
    {
        _state = InteractableState.Activated;
        Invoke("Explode", waitInterval);
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
            DeactivateMachine();
        }
        else
        {
            Debug.Log("Nothing Happend");
        }
    }
}
