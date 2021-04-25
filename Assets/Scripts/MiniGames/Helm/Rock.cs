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
        transform.Translate(0, rockSpeed * Time.deltaTime, 0);
    }
}
