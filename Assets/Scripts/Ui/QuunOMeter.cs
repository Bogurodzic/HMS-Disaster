using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuunOMeter : MonoBehaviour
{
    public Sprite satisfiedQueen;
    public Sprite neutralQueen;
    public Sprite pissedQueen;
    public int pissLevel = 20;
    
    [SerializeField] private Image _spriteRenderer;

    private int _satisfactionLevel = 3;
    private bool _wasPissedOnce = false;
    void Start()
    {
        
    }

    void Update()
    {
    }

    public void SatisfyQueen()
    {
        if (_satisfactionLevel < 3)
        {
            if (_satisfactionLevel == 1)
                DifficultLevel.SubstractDifficultLevel(pissLevel);
            
            if (!_wasPissedOnce)
            {
                _satisfactionLevel += 1;
            } else if (_wasPissedOnce && _satisfactionLevel < 2)
            {
                _satisfactionLevel += 1;
            }
        }

        RenderSatisfaction();
    }

    public void PissQueen()
    {
        if (_satisfactionLevel > 1)
        {
            if (_satisfactionLevel == 2)
            {
                DifficultLevel.AddDifficultLevel(pissLevel);
            }
            _satisfactionLevel -= 1;
            _wasPissedOnce = true;
            Score.SetMultiplier(1);
        }

        RenderSatisfaction();
    }

    private void RenderSatisfaction()
    {
        if (_satisfactionLevel == 1)
            _spriteRenderer.sprite = pissedQueen;

        if (_satisfactionLevel == 2)
            _spriteRenderer.sprite = neutralQueen;

        if (_satisfactionLevel == 3)
            _spriteRenderer.sprite = satisfiedQueen;
    }
}
