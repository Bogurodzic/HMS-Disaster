using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{

    [SerializeField] private Slider _slider;
    [SerializeField] private ShipHitpoints _shipHitpoints;
    void Start()
    {
        
    }

    void Update()
    {
        float newSliderValue = (float)_shipHitpoints.GetCurrentHitpoints() / 100;
        _slider.value = newSliderValue;
    }
}
