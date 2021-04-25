using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PeriscopeInteractable : BasicInteractable
{
    public override void Update()
    {
        if (_state == InteractableState.Activated)
        {
            if (_spriteRenderer.color == Color.red)
            {
                _spriteRenderer.color = Color.blue;
            }
            else
            {
                _spriteRenderer.color = Color.red;
            }
        }
    }
    
    
}
