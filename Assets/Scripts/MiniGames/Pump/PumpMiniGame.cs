using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpMiniGame : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    private PlayerController _playerController;
    private bool _ballInZone = false;
    private bool _initalised = false;
    void Start()
    {
        _ball.ballInZone += ballInZone =>
        {
            _ballInZone = ballInZone;
        };
    }

    void Update()
    {
        if (_initalised && Input.GetKeyDown(_playerController.activateButton))
        {
            if (_ballInZone)
            {
                Debug.Log("NICE");
            }
            else
            {
                Debug.Log("GUNWOOO");
            }
        }
    }

    public void Initialise(PlayerController playerController)
    {
        _playerController = playerController;
        _initalised = true;
    }
}
