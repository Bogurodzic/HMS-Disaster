using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class TeaTimeInteractable : BasicInteractable
{
    public float teatimeDuration;

    [SerializeField] private Text _text;
    [SerializeField] private Canvas _canvas;

    protected override void AddPlayerToOperateMachine(PlayerController playerController)
    {
        playerController.SetPlayerStatus(PlayerStatus.Busy);
        _playerControllers.Add(playerController);
        Debug.Log("PLAYER SIEDZI");
        playerController.Sit();
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
        
        DeactivateMachine();
        _text.text = "";
    }
}
