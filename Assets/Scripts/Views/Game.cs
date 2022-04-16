using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : BaseView
{
    public static bool IsGameOn => isGameOn;

    [SerializeField] private GameObject road;
    [SerializeField] private GameObject player;

    private static bool isGameOn;

    public override void Initialize()
    {
        road.SetActive(false);
        player.SetActive(false);
        GlobalManager.OnFinishReached.AddListener(UpdateTimeFinished);
        GlobalManager.OnFallingDown.AddListener(ResetTime);
    }

    private void OnEnable()
    {
        isGameOn = true;
        road.SetActive(true);
        player.SetActive(true);
        timeInGame = 0;
    }

    private void OnDisable()
    {
        isGameOn = false;
    }

    private float timeInGame = 0;
    private void Update()
    {
        if (isGameOn)
        {
            timeInGame += Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ViewManager.Show<Menu>();
            }
        }
    }

    private void UpdateTimeFinished()
    {
        GlobalManager.SendUpdateTime(timeInGame);
    }

    private void ResetTime()
    {
        timeInGame = 0;
    }
}
