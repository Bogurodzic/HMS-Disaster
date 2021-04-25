using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValveMiniGame : MonoBehaviour
{
    public float valveDecayOverTime;
    public int secondsForNextDecay;
    public float valveProgressOnButtonPress;
    
    public event Action<bool> OnSuccess = isSuccess => { };

    [SerializeField] private Slider[] _valveSliders;
    private List<PlayerController> _playerControllers;
    private bool _initalised = true;
    void Start()
    {
        
    }

    void Update()
    {
        if (_initalised)
        {
            HandlePressingButtons();
            CheckGameCondition();
        }
    }
    
    public void Initialise(List<PlayerController> playerControllers)
    {
        _playerControllers = playerControllers;
        _initalised = true;
    }

    public bool IsInitialised()
    {
        return _initalised;
    }

    private void HandlePressingButtons()
    {
        if (Input.GetKeyDown(_playerControllers[0].activateButton))
        {
            _valveSliders[0].value += valveProgressOnButtonPress / 100;
        }
            
        if (Input.GetKeyDown(_playerControllers[1].activateButton))
        {
            _valveSliders[1].value += valveProgressOnButtonPress / 100;
        }
    }

    private void CheckGameCondition()
    {
        if (_valveSliders[0].value == 1 && _valveSliders[1].value == 1)
        {
            OnSuccess(true);
            Destroy(gameObject);
        } else if (_valveSliders[0].value == 0 || _valveSliders[1].value == 0)
        {
            OnSuccess(false);
            Destroy(gameObject);
        }
    }
}
