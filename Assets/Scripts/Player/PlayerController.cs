using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public KeyCode upButton;
    public KeyCode downButton;
    public KeyCode leftButton;
    public KeyCode rightButton;
    public KeyCode activateButton;

    [SerializeField] private Animator _animator;
    private PlayerStatus _playerStatus = PlayerStatus.Free;

    public void SetPlayerStatus(PlayerStatus playerStatus)
    {
        _playerStatus = playerStatus;
    }

    public PlayerStatus GetPlayerStatus()
    {
        return _playerStatus;
    }

    public bool CanPlayerMove()
    {
        return GetPlayerStatus() == PlayerStatus.Free;
    }

    public void Sit()
    {
        _animator.SetBool("isSitting", true);
    }

    public void Drink()
    {
        _animator.SetBool("isDrinking", true);
    }

    public void StopDrinking()
    {
        _animator.SetBool("isDrinking", false);
        _animator.SetBool("isSitting", false);
    }
}
