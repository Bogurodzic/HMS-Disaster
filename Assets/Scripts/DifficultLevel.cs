using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultLevel
{
    private static int _difficultLevel = 1;


    public static int GetDifficultLevel()
    {
        return _difficultLevel;
    }

    public static void IncreaseDifficultLevel()
    {
        _difficultLevel = _difficultLevel + 1;
    }
}
