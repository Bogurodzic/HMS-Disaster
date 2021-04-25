using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu]
public class Machines : ScriptableObject
{
    public int activationInterval;
    public int waitInterval;
    public int damageOnExplode;
    public int playersRequired;
    public GameType gameType;
}



