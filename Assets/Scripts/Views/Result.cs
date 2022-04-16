using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Result : BaseView
{
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI scores;

    public override void Initialize()
    {
        GlobalManager.OnFallingDown.AddListener(ChangeTitleTextLost);
        GlobalManager.OnUpdateScores.AddListener(ChangeScoreText);
        GlobalManager.OnTimeUpdate.AddListener(ChangeTitleTextWin);
    }

    private void OnDisable()
    {
        title.text = "YOUR RESULT";
    }

    public void OnToMenu()
    {
        ViewManager.Show<Menu>();
    }

    private void ChangeTitleTextLost()
    {
        title.text = "Вы проиграли";
    }

    private void ChangeTitleTextWin(float time)
    {
        title.text = "Вы выйграли " + time.ToString("00") + ": секунд заняло путешествие";
    }

    private void ChangeScoreText(int text)
    {
        scores.text = text.ToString();
    }
}
