using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public Transform target;
    private Vector3 zAxis = new Vector3(0, 0, -1);
    [SerializeField] private TeaTimeInteractable _teaTimeInteractable;
    [SerializeField] private GameObject _alert;
    void Update()
    {
        transform.RotateAround(target.position, zAxis, speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Clock"))
        {
            _teaTimeInteractable.TeaTime();
            _alert.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Clock"))
        {
            _teaTimeInteractable.TeaTimeEnd();
            _alert.SetActive(false);
        }
    }
}
