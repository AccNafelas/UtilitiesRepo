using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllowSceneChanger : MonoBehaviour
{
    public Button button;

    private void OnEnable()
    {
        if (!button) return;

        button.onClick.AddListener(LoadNext);
    }

    private void LoadNext()
    {
        MyScenesManager.instance.LoadSingleSceneNow("TouchToSpawn");
    }
}
