using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TurnOn()
    {
        _animator.SetBool("On", true);
       // _audioSource.loop = true;
        _audioSource.Play();
    }

    public void TurnOff()
    {
        _animator.SetBool("On", false);
        _audioSource.Stop();
    }
}
