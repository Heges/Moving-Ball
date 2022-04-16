using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class GlobalManager : MonoBehaviour
{
    public static  UnityEvent OnFinishReached = new UnityEvent();
    public static  UnityEvent OnFallingDown = new UnityEvent();
    public static  UnityEvent<int> OnUpdateScores = new UnityEvent<int>();
    public static  UnityEvent<float> OnTimeUpdate = new UnityEvent<float>();

    public static void SendFinishReached()
    {
        OnFinishReached.Invoke();
    }

    public static void SendFallingDown()
    {
        OnFallingDown.Invoke();
    }

    public static void SendUpdateScore(int amount)
    {
        OnUpdateScores.Invoke(amount);
    }

    public static void SendUpdateTime(float amount)
    {
        OnTimeUpdate.Invoke(amount);
    }
}
