using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ActiveMachines
{
    private static int _activeMachines = 0;

    public static void AddActiveMachine()
    {
        _activeMachines += 1;
    }

    public static void RemoveActiveMachine()
    {
        _activeMachines -= 1;
    }

    public static int GetActiveMachinesQuantity()
    {
        return _activeMachines;
    }
}
