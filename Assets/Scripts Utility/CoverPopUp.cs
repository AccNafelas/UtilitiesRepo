using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoverPopUp : BasicPopUp
{
    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    public override void Arrive()
    {
        canvasGroup.alpha = 1f;
        OnTransitionEnd();
    }

    public override void OnTransitionEnd()
    {
        OnTransitionCompleted?.Invoke();
    }

    public override void GoAway()
    {
        canvasGroup.alpha = 0f;
        Release();
    }

    public override void Release()
    {
        //Destroy the object by calling the PopUp Manager
        PopUpManager.instance.Release(this.gameObject);
    }
}
