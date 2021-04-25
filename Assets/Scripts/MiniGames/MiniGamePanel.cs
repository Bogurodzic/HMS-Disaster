using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MiniGamePanel : MonoBehaviour
{
    public GameObject pumpMiniGame;
    public event Action<bool> OnSuccess = success => { };

    
    private List<PlayerController> _playerControllers = new List<PlayerController>();
    private GameType _gameType;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void InitialiseGame(List<PlayerController> playerControllers, GameType gameType)
    {
        _playerControllers = playerControllers;
        _gameType = gameType;
        StartMiniGame();
    }

    private void StartMiniGame()
    {
        switch (_gameType)
        {
            case GameType.PUMP:
                PumpMiniGame pumpMiniGameInstance = Instantiate(pumpMiniGame, transform.position, transform.rotation).GetComponent<PumpMiniGame>();
                pumpMiniGameInstance.Initialise(_playerControllers);
                
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
