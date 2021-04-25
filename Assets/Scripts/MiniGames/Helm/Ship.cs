using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private HelmMiniGame _helmMiniGame;
    void Start()
    {
        
    }
    
    void Update()
    {
        
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
