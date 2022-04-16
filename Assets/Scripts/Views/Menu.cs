using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : BaseView
{
    public override void Initialize()
    {
        
    }

    public void OnStart() 
    {
        ViewManager.Show<Game>();
    }

    public void OnResults()
    {
        ViewManager.Show<Result>();
    }

    public void OnExit()
    {
        Application.Quit();
    }
}
