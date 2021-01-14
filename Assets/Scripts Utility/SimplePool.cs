using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePool : MonoBehaviour
{
    [Header("Pool")]
    public GameObject orb;
    public int amount = 5;

    public Transform parent;
    public Transform Parent 
    { 
        get 
        {
            if (parent == null)
                return this.transform; 
            else
                return parent; 
        }
        set { parent = value; }
    }

    public List<GameObject> list = new List<GameObject>();

    #region Pool
    void Awake()
    {
        FillAll();

        InvokeRepeating("Release", 5f, 5f);
    }

    void FillAll()
    {
        for (int j = 0; j < amount; j++)
        {
            GameObject N = (GameObject)Instantiate(orb); // Creo nueva
            N.SetActive(false); // pero inactiva

            list.Add(N);
            N.transform.SetParent(Parent);

        }
    }

    public GameObject GetObj()
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            if (!list[i].activeInHierarchy)
            {
                return list[i];
            }

        }

        GameObject N = (GameObject)Instantiate(orb);
        N.SetActive(false);
        list.Add(N);
        N.transform.SetParent(Parent);

        return N;
    }

    public void Release()
    {
        if (list.Count > amount)
        { //Si tengo más que las que necesito
          // libero las que estan de más

            for (int i = 0; i < Parent.childCount; i++)
            {
                if (i >= amount && !parent.GetChild(i).gameObject.activeInHierarchy)
                {
                    list.Remove(Parent.GetChild(i).gameObject);
                    Destroy(Parent.GetChild(i).gameObject);

                }
            }
        }
    }

    #endregion  
}
