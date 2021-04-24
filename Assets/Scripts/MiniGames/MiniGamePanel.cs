using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MiniGamePanel : MonoBehaviour
{
    public GameObject pumpMiniGame;
    public event Action<bool> OnSuccess = success => { };

    
    private PlayerController _playerController;
    private GameType _gameType;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void InitialiseGame(PlayerController playerController, GameType gameType)
    {
        _playerController = playerController;
        _gameType = gameType;
        StartMiniGame();
    }

    private void StartMiniGame()
    {
        switch (_gameType)
        {
            case GameType.PUMP:
                PumpMiniGame pumpMiniGameInstance = Instantiate(pumpMiniGame, transform.position, transform.rotation).GetComponent<PumpMiniGame>();
                pumpMiniGameInstance.Initialise(_playerController);
                
                pumpMiniGameInstance.OnSuccess += succes =>
                {
                    OnSuccess(succes);
                    Destroy(gameObject);
                };
                break;
            default:
                break;
        }
    }
    
    
}
