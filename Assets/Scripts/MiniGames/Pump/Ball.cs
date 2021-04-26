using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    
    public float speed;
    public Transform target;
    public event Action<bool> ballInZone = isBallInZone => { };
    
    private Vector3 zAxis = new Vector3(0, 0, 1);

    void FixedUpdate()
    {
        transform.RotateAround(target.position, zAxis, speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Zone"))
        {
            ballInZone(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Zone"))
        {
            ballInZone(false);
        }
    }
}
