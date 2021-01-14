using UnityEngine;
using System;
using System.Collections;

public class BasicPopUp : MonoBehaviour
{
    public Animator moveAnimator;
    public CanvasGroup canvasGroup;

    public Action OnTransitionCompleted;

    public const float OUT_ANIM_TIME = 0.5f;

    public virtual void Arrive()
    {
        //In Animation -> entry state, start by default
        canvasGroup.interactable = false;
    }

    public virtual void OnTransitionEnd()
    {
        canvasGroup.interactable = true;
        OnTransitionCompleted?.Invoke();
    }

    public virtual void GoAway()
    {
        //Out Animation
        moveAnimator.SetTrigger("GoOut");
        StartCoroutine(WaitToRelease(OUT_ANIM_TIME));

        canvasGroup.interactable = false;
    }

    private IEnumerator WaitToRelease(float t)
    {
        yield return new WaitForSeconds(t);
        Release();
    }

    public virtual void Release()
    {
        //Destroy the object by calling the PopUp Manager
        PopUpManager.instance.Release(this.gameObject);
    }

}