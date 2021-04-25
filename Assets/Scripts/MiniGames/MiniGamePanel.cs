using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class MiniGamePanel : MonoBehaviour
{
    public GameObject pumpMiniGame;
    public GameObject valveMiniGame;
    public GameObject helmMiniGame;
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
                pumpMiniGameInstance.transform.parent = gameObject.transform;
                pumpMiniGameInstance.OnSuccess += succes =>
                {
                    OnSuccess(succes);
                    Destroy(gameObject);
                };
                break;
            case GameType.VALVE:
                ValveMiniGame valveMiniGameInstace = Instantiate(valveMiniGame, transform.position, transform.rotation).GetComponent<ValveMiniGame>();
                valveMiniGameInstace.transform.parent = gameObject.transform;
                valveMiniGameInstace.Initialise(_playerControllers);
                
                valveMiniGameInstace.OnSuccess += succes =>
                {
                    OnSuccess(succes);
                    Destroy(gameObject);
                };
                break;
            case GameType.HELM:
                HelmMiniGame helmMiniGameInstace = Instantiate(helmMiniGame, transform.position, transform.rotation).GetComponent<HelmMiniGame>();
                helmMiniGameInstace.transform.parent = gameObject.transform;
                helmMiniGameInstace.Initialise(_playerControllers);
                
                helmMiniGameInstace.OnSuccess += succes =>
                {
                    OnSuccess(succes);
                    Debug.Log(succes);
                    Destroy(gameObject);
                };
                break;
            default:
                break;
        }
    }
    
    
}
