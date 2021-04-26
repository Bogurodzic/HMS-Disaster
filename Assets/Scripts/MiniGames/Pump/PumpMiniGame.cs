using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpMiniGame : MonoBehaviour
{
    public int requiredSuccess = 3;
    public event Action<bool> OnSuccess = isSuccess => { };


    [SerializeField] private Ball _ball;
    [SerializeField] private AudioSource _audioSource;
    private PlayerController _playerController;
    private bool _ballInZone = false;
    private bool _initalised = false;
    private int _currentSuccess = 0;
    private bool _pressReady = true;
    void Start()
    {
        _ball.ballInZone += ballInZone =>
        {
            _ballInZone = ballInZone;

            if (!ballInZone)
                _pressReady = true;
        };

        requiredSuccess = 3 + DifficultLevel.GetDifficultLevel() / 5;
        Debug.Log("Required success: " + requiredSuccess);
    }

    void Update()
    {
        if (_initalised && Input.GetKeyDown(_playerController.activateButton) && _pressReady)
        {
            if (_ballInZone)
            {
                _audioSource.Play();
                _pressReady = false;
                _currentSuccess = _currentSuccess + 1;

                if (_currentSuccess >= requiredSuccess)
                {
                    OnSuccess(true);
                    Destroy(gameObject);
                }
                
                Debug.Log("NICE");
            }
            else
            {
                Debug.Log("FAILED");
                OnSuccess(false);
                Destroy(gameObject);
            }
        }
    }

    public void Initialise(List<PlayerController> playerControllers)
    {
        _playerController = playerControllers[0];
        _initalised = true;
    }
}
