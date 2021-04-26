using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TurnOn()
    {
        _animator.SetBool("On", true);
    }

    public void TurnOff()
    {
        _animator.SetBool("On", false);
    }
}
