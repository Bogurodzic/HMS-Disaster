using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHitpoints : MonoBehaviour
{
    public int maximumHitpoints;

    private int _currentHipoints;

    private void Awake()
    {
        _currentHipoints = maximumHitpoints;
    }

    void Start()
    {
    }

    void Update()
    {

    }

    public void RecieveDamage(int damage)
    {
        _currentHipoints = _currentHipoints - damage;
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
