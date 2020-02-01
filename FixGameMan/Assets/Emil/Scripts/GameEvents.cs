using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class GameEvents
{
    public static System.Action WinTriggered;
    public static System.Action LooseTriggered;

    public static void OnWinTriggered()
    {
        WinTriggered?.Invoke();
    }

    public static void OnLooseTriggered()
    {
        LooseTriggered?.Invoke();
    }
}
