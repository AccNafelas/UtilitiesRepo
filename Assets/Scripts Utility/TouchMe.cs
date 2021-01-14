using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchMe : MonoBehaviour, ITouchable
{
    public SimplePool pool;
    public UnityEvent OnSpawningNew;
    public void OnTouch(Vector3 touchPos)
    {
        SpawnObjOn(touchPos);
    }

    public void SpawnObjOn(Vector3 pos)
    {
        GameObject go = pool.GetObj();
        go.transform.position = pos;
        go.SetActive(true);

        OnSpawningNew?.Invoke();
    }
}
