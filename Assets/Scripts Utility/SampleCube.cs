using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCube : MonoBehaviour
{

    private void OnEnable()
    {
        this.GetComponent<MeshRenderer>().material.color = GetRandomColor();
        Invoke("ByeBye", Random.Range(2f,5f));
    }

    private Color GetRandomColor()
    {
        return new Color(
            Random.Range(0f, 1f),
            Random.Range(0f, 1f),
            Random.Range(0f, 1f)
             );
    }

    void ByeBye()
    {
        this.gameObject.SetActive(false);
    }
}
