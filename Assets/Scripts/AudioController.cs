using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSoure;

    public AudioClip normalMusic;
    public AudioClip teaTimeMusic;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayTeatimeMusic()
    {
        _audioSoure.Stop();
        _audioSoure.clip = teaTimeMusic;
        _audioSoure.loop = true;
        _audioSoure.Play();

    }

    public void PlayNormalMusic()
    {
        _audioSoure.Stop();
        _audioSoure.clip = normalMusic;
        _audioSoure.loop = true;
        _audioSoure.Play();
    }
}
