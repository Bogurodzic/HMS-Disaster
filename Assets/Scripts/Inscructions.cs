using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inscructions : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public Sprite[] _sprites;
    private int _currentIndex = 0;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Next()
    {
        if (_currentIndex < 4)
        {
            _currentIndex += 1;
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }

        _spriteRenderer.sprite = _sprites[_currentIndex];
    }
}
