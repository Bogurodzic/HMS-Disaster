using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{
    private static float _score;
    private static float _currentScoreMultiplier = 1;

    public static void AddScore(int score)
    {
        _score += score * GetCurrentMultiplier();
    }

    public static float GetScore()
    {
        return _score;
    }

    public static float GetCurrentMultiplier()
    {
        return _currentScoreMultiplier;
    }

    public static void ResetMultiplier()
    {
        _currentScoreMultiplier = 1;
    }

    public static void SetMultiplier(int multiplier)
    {
        _currentScoreMultiplier = multiplier;
    }
}
