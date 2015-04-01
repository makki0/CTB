using UnityEngine;
using System.Collections;

public static class Master {
    public static _GameStat gameState = _GameStat.Nothing;

    public enum _GameStat
    {
        Nothing,
        Start,
        OnGame,
        GameOver
    }

    public static int RetryCount = 0;
}
