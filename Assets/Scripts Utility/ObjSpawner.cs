using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjSpawner : MonoBehaviour
{
    public SimplePool pool;

    [Header("Zone")]
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float z;

    [Header("UI")]
    public Text spawnedText;
    public Text poolSize;

    private int spawnedAmount = 0;

    private void Update()
    {
        poolSize.text ="Pool Size: " +  pool.list.Count.ToString();
        spawnedText.text ="Spawned: " + spawnedAmount.ToString();
    }

    [ContextMenu("Spawn new")]
    public void SpawnInRandomPos()
    {
        GameObject go = pool.GetObj();
        go.transform.position = GetRandomPos();
        go.transform.rotation = Random.rotation;
        go.SetActive(true);

        spawnedAmount++;
    }

    private Vector3 GetRandomPos()
    {
        return new Vector3
            (Random.Range(minX, maxX),
             z,
             Random.Range(minY, maxY)
             );
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(maxX - minX, maxY - minY, 5f));
    }
}
