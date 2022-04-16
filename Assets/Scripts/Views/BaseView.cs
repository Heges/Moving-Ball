using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseView : MonoBehaviour
{
    public abstract void Initialize();

    public void Active() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);
}
