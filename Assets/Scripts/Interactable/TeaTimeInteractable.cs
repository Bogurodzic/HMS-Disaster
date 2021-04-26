﻿using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class TeaTimeInteractable : BasicInteractable
{
    public float teatimeDuration;
    public Sprite tableWithCups;
    public Sprite tableWithoutCups;

    [SerializeField] private Text _text;
    [SerializeField] private Canvas _canvas;

    protected override void AddPlayerToOperateMachine(PlayerController playerController)
    {
        playerController.SetPlayerStatus(PlayerStatus.Busy);
        _playerControllers.Add(playerController);
        Debug.Log("PLAYER SIEDZI");
        playerController.Sit();
    }

    public override void ActivateMachine()
    {
        
    }

    public void TeaTime()
    {
        _alarmController.TurnOn();
        _state = InteractableState.Activated;
        //Invoke("Explode", teatimeDuration);
        _spriteRenderer.sprite = tableWithoutCups;
    }

    protected override void Explode()
    {
        
    }

    public void TeaTimeEnd()
    {
        if (_state == InteractableState.Activated)
        {
            foreach (var playerController in _playerControllers)
            {
                playerController.StopDrinking();
            } 
            _spriteRenderer.sprite = tableWithCups;
        }
    }

    protected override void RunMinigame()
    {
        foreach (var playerController in _playerControllers)
        {
            playerController.Drink();
        }

        FirstText();
        Invoke("SecondText", teatimeDuration/3);
        Invoke("ThirdText", (teatimeDuration/3) * 2);
        Invoke("EndDrinking", teatimeDuration);
    }

    private void FirstText()
    {
        _text.text = "I bet tomorrow will be raining...";
    }

    private void SecondText()
    {
        _text.text = "Why?";
    }

    private void ThirdText()
    {
        _text.text = "Because pressure has changed.";
    }

    private void EndDrinking()
    {
        foreach (var playerController in _playerControllers)
        {
            playerController.StopDrinking();
            playerController.SetPlayerStatus(PlayerStatus.Free);
        }
        _spriteRenderer.sprite = tableWithCups;
        DeactivateMachine();
        _text.text = "";
    }
}
