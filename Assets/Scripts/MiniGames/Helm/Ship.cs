using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ship : MonoBehaviour
{
    [SerializeField] private HelmMiniGame _helmMiniGame;
    [SerializeField] private GameObject[] _spawningPoints;
    [SerializeField] private GameObject _rock;
    
    private int _currentPositionIndex = 1;
    void Start()
    {
        _currentPositionIndex = Random.Range(0, 2);
        RenderShip();
        _rock.transform.position = new Vector3(_spawningPoints[_currentPositionIndex].transform.position.x,
            _rock.transform.position.y, _rock.transform.position.z);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(_helmMiniGame.GetPlayerController().leftButton))
        {
            if (_currentPositionIndex > 0)
            {
                _currentPositionIndex = _currentPositionIndex - 1;
                RenderShip();
            }
            else
            {
                _currentPositionIndex = 2;
                RenderShip();
            }
        }
        
        if (Input.GetKeyDown(_helmMiniGame.GetPlayerController().rightButton))
        {
            if (_currentPositionIndex < 2)
            {
                _currentPositionIndex = _currentPositionIndex + 1;
                RenderShip();
            }
            else
            {
                _currentPositionIndex = 0;
                RenderShip();
            }
        }
    }

    private void RenderShip()
    {
        transform.position = new Vector3(_spawningPoints[_currentPositionIndex].transform.position.x, transform.position.y, transform.position.z);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            _helmMiniGame.EmitSuccess(false);
        }
        
        if (other.gameObject.CompareTag("End"))
        {
            _helmMiniGame.EmitSuccess(true);
        }
    }
}
