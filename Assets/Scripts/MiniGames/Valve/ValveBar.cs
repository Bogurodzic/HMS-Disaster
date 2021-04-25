using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValveBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private ValveMiniGame _valveMiniGame;
    
    private bool _initialised = false;
    private float _sliderTimer = 0;
 
    void Start()
    {
        
    }

    void Update()
    {
        if (_valveMiniGame.IsInitialised() && !_initialised)
        {
            _initialised = true;
        }

        if (_initialised)
        {
            ReduceSliderValueOverTime();
        }
    }

    private void ReduceSliderValueOverTime()
    {

        _sliderTimer += Time.deltaTime;
        if(_sliderTimer >= _valveMiniGame.secondsForNextDecay)
        { 
            _slider.value -= _valveMiniGame.valveDecayOverTime / 100;
            _sliderTimer = 0;
        }
      
    }
    
}
