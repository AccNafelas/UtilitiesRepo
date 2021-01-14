using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeededToLoad : MonoBehaviour
{
    public bool isCompleted = false;

    public void Complete()
    {
        isCompleted = true;
    }
}
