using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public float rockSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        float currentSpeed = rockSpeed + (rockSpeed * (DifficultLevel.GetDifficultLevel() / 50));
        transform.Translate(0, currentSpeed * Time.deltaTime, 0);
    }
}
