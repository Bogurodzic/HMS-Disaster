using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDeepController : MonoBehaviour
{
    private float _timer = 0;
    private int _deepMeter;
    void Update()
    {
        GoDeeper();
    }
    
    private void GoDeeper()
    {
        _timer += Time.deltaTime;
        if(_timer >= 1)
        {
            _deepMeter += 1;
            _timer = 0;
        }
    }

    public int GetCurrentDeep()
    {
        return _deepMeter;
    }
}
