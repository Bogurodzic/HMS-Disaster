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
    [SerializeField] private AudioSource _audioSource;
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

        _valveSliders[0].transform.position =
            Camera.main.WorldToScreenPoint(transform.parent.position + new Vector3(-1, 0, 0));
        _valveSliders[1].transform.position =
            Camera.main.WorldToScreenPoint(transform.parent.position + new Vector3(1, 0, 0));
        //Slider.transform.position = Camera.main.
    }

    public bool IsInitialised()
    {
        return _initalised;
    }

    private void HandlePressingButtons()
    {
        if (Input.GetKeyDown(_playerControllers[0].activateButton))
        {
            _valveSliders[0].value += (valveProgressOnButtonPress / 100) - (valveProgressOnButtonPress / 10000 * DifficultLevel.GetDifficultLevel());
            _audioSource.Play();
        }
            
        if (Input.GetKeyDown(_playerControllers[1].activateButton))
        {
            _valveSliders[1].value += (valveProgressOnButtonPress / 100) - (valveProgressOnButtonPress / 10000 * DifficultLevel.GetDifficultLevel());
            _audioSource.Play();
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
