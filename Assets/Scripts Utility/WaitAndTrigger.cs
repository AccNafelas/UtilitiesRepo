using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitAndTrigger : MonoBehaviour
{
    public float time = 2f;
    [HideInInspector] public bool finished = false;

    public UnityEvent OnTrigger;

    private void OnEnable()
    {
        StartCoroutine(WaitAndTriggerEvent(time));
    }

    IEnumerator WaitAndTriggerEvent(float t)
    {
        finished = false;
        yield return new WaitForSeconds(t);
        finished = true;
        OnTrigger?.Invoke();
    }
}
