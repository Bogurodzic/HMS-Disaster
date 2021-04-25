using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmMiniGame : MonoBehaviour
{
    public event Action<bool> OnSuccess = isSuccess => { };

    private PlayerController _playerController;
    private bool _initalised = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void Initialise(List<PlayerController> playerControllers)
    {
        _playerController = playerControllers[0];
        _initalised = true;
    }

    public void EmitSuccess(bool success)
    {
        OnSuccess(success);
    }
}
