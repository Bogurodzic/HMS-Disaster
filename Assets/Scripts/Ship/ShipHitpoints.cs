using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHitpoints : MonoBehaviour
{
    public int maximumHitpoints;
    public AudioClip _damage;
    public AudioClip _death;
    
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private CameraShake _cameraShake;
    
    private int _currentHipoints;

    private void Awake()
    {
        _currentHipoints = maximumHitpoints;
    }

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {

    }

    public void RecieveDamage(int damage)
    {
        _currentHipoints = _currentHipoints - damage;
        _audioSource.clip = _damage;
        _audioSource.Play();
        _cameraShake.Shake();
    }

    public int GetMaximumHitpoints()
    {
        return maximumHitpoints;
    }

    public int GetCurrentHitpoints()
    {
        return _currentHipoints;
    }
}
