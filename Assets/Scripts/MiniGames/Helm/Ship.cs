using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private HelmMiniGame _helmMiniGame;
    [SerializeField] private GameObject[] _spawningPoints;
    private int _currentPositionIndex = 1;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(_helmMiniGame.GetPlayerController().leftButton))
        {
            if (_currentPositionIndex > 0)
            {
                _currentPositionIndex = _currentPositionIndex - 1;
                transform.position = new Vector3(_spawningPoints[_currentPositionIndex].transform.position.x, transform.position.y, transform.position.z);
            }
            else
            {
                _currentPositionIndex = 2;
                transform.position = new Vector3(_spawningPoints[_currentPositionIndex].transform.position.x, transform.position.y, transform.position.z);
            }
        }
        
        if (Input.GetKeyDown(_helmMiniGame.GetPlayerController().rightButton))
        {
            if (_currentPositionIndex < 2)
            {
                _currentPositionIndex = _currentPositionIndex + 1;
                transform.position = new Vector3(_spawningPoints[_currentPositionIndex].transform.position.x, transform.position.y, transform.position.z);
            }
            else
            {
                _currentPositionIndex = 0;
                transform.position = new Vector3(_spawningPoints[_currentPositionIndex].transform.position.x, transform.position.y, transform.position.z);
            }
        }
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
