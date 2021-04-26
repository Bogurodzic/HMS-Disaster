using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultLevel
{
    private static int _difficultLevel = 7;


    public static int GetDifficultLevel()
    {
        return _difficultLevel;
    }

    public static void IncreaseDifficultLevel()
    {
        _difficultLevel = _difficultLevel + 1;
    }

    public static int PercentChanceForActivatingNextMachine()
    {
        int activeMachineQuantity = ActiveMachines.GetActiveMachinesQuantity();
        
        switch (GetDifficultLevel())
        {
            case 1:
                if (activeMachineQuantity == 0)
                    return 100;
                return 0; 
            case 2:
                if (activeMachineQuantity == 0)
                    return 100;
                if (activeMachineQuantity == 1)
                    return 20;
                return 0;
            case 3:
                if (activeMachineQuantity == 0)
                    return 100;
                if (activeMachineQuantity == 1)
                    return 40;
                return 0;
            case 4:
                if (activeMachineQuantity == 0)
                    return 100;
                if (activeMachineQuantity == 1)
                    return 60;
                return 0;
            case 5:
                if (activeMachineQuantity == 0)
                    return 100;
                if (activeMachineQuantity == 1)
                    return 80;
                return 0;
            case 6:
                if (activeMachineQuantity == 0)
                    return 100;
                if (activeMachineQuantity == 1)
                    return 100;
                if (activeMachineQuantity == 2)
                    return 20;
                return 0;
            case 7:
                if (activeMachineQuantity == 0)
                    return 100;
                if (activeMachineQuantity == 1)
                    return 100;
                if (activeMachineQuantity == 2)
                    return 20;
                return 0;
            case 8:
                if (activeMachineQuantity == 0)
                    return 100;
                if (activeMachineQuantity == 1)
                    return 100;
                if (activeMachineQuantity == 2)
                    return 60;
                return 0;
            case 9:
                if (activeMachineQuantity == 0)
                    return 100;
                if (activeMachineQuantity == 1)
                    return 100;
                if (activeMachineQuantity == 2)
                    return 80;
                return 0;
            default:
                if (activeMachineQuantity == 0)
                    return 100;
                if (activeMachineQuantity == 1)
                    return 100;
                if (activeMachineQuantity == 2)
                    return 100;
                return 0;
        }
    }
}
