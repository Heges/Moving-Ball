using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int scores;

    private void OnEnable()
    {
        GlobalManager.OnFinishReached.AddListener(IncreaseScoresFromWin);
        GlobalManager.OnFallingDown.AddListener(UpdateScores);
    }

    private void UpdateScores()
    {
        GlobalManager.SendUpdateScore(scores);
    }

    private void IncreaseScoresFromWin()
    {
        scores += Random.Range(25, 174);
        GlobalManager.SendUpdateScore(scores);
    }
}
