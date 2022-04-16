using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public static ViewManager instance;

    [SerializeField] private BaseView[] views;

    private BaseView current;
    private readonly Stack<BaseView> history = new Stack<BaseView>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        GlobalManager.OnFallingDown.AddListener(ToResultScreen);
        GlobalManager.OnFinishReached.AddListener(ToResultScreen);
    }

    private void Start()
    {
        for (int i = 0; i < views.Length; i++)
        {
            views[i].Initialize();
        }
        Show<Menu>();
    }

    private void ToResultScreen()
    {
        Show<Result>();
    }

    public static T GetView<T>() where T : BaseView
    {
        for (int i = 0; i < instance.views.Length; i++)
        {
            if (instance.views[i] is T)
            {
                return instance.views[i] as T;
            }
        }
        return null;
    }

    public static void Show<T>(bool remember = true) where T : BaseView
    {
        for (int i = 0; i < instance.views.Length; i++)
        {
            if (instance.views[i] is T)
            {
                if (instance.current != null)
                {
                    if (remember)
                    {
                        instance.history.Push(instance.current);
                    }
                    instance.current.Hide();
                }

                instance.views[i].Active();
                instance.current = instance.views[i];
            }
        }
    }

    public static void Show(BaseView view, bool remember = true)
    {
        if (instance.current != null)
        {
            if (instance.current != null)
            {
                if (remember)
                {
                    instance.history.Push(instance.current);
                }
                instance.current.Hide();
            }
            view.Active();
            instance.current = view;
        }
    }

    public static void ShowLast()
    {
        if (instance.history.Count > 0)
        {
            if (instance.current != null)
            {
                Show(instance.history.Pop());
            }
        }
    }
}
