using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitpointsText : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private ShipHitpoints _shipHitpoints;

    public String preText;
    void Start()
    {
        _text.text = preText + " " + _shipHitpoints.GetCurrentHitpoints() + "/" + _shipHitpoints.GetMaximumHitpoints();
    }

    void Update()
    {
        _text.text = preText + " " + _shipHitpoints.GetCurrentHitpoints() + "/" + _shipHitpoints.GetMaximumHitpoints();
    }
}
