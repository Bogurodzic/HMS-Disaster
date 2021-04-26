using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PeriscopeInteractable : BasicInteractable
{
    public override void Update()
    {

    }

    public void TurnOn()
    {
        _alarmController.TurnOn();
        SetState(InteractableState.Activated);
    }
}
