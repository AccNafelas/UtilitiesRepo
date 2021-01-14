using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class MyScenesManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        CreateInstance();
    }

    //Just an example that should be in another class
    public void LoadScene()
    {
        //LoadSingleSceneNow("SceneTransition2", true);
        LoadSingleSceneNow("SceneTransition2", false);
    }

    #region Load an Scene in Single Mode instantly
    public void LoadSingleSceneNow(string sceneName, bool closeInstantly = true)
    {
        PopUpManager PPM = PopUpManager.instance;
        if (PPM == null)
        { SceneManager.LoadScene(sceneName, LoadSceneMode.Single); }
        else 
        {
            PPM.ShowCover();
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            if (closeInstantly)
            { PPM.Release(); }
            else
            {
                StartCoroutine(WaitForLoadStuff());
            }
        }
    }

    //Search for every Obj with a Particular Tag, which will have a componnent attached that trigger an event when ther process is finished
    List<NeededToLoad> waiters;
    string myTag = "NeedToBeLoad";
    IEnumerator WaitForLoadStuff()
    {
        waiters = new List<NeededToLoad>();
        int roundsWithoutNews = 0;
        while (roundsWithoutNews < 2)
        {
            GameObject[] gos = GameObject.FindGameObjectsWithTag(myTag);
            if (CheckForNew(gos))
                roundsWithoutNews = 0;
            else
                roundsWithoutNews++;

            yield return new WaitForSeconds(0.5f);
        }
        // Check every wait and trigger
        while (!CheckForCompleted())
        {
            yield return new WaitForSeconds(0.5f);
        }

        PopUpManager.instance.Release();
        Debug.Log("All actions completed!");

    }

    bool CheckForNew(GameObject[] newInfo)
    {
        bool foundnew = false;
        foreach (var go in newInfo)
        {
            if (waiters.Contains(go.GetComponent<NeededToLoad>()))
            {
                continue;
            }
            waiters.Add(go.GetComponent<NeededToLoad>());
            foundnew = true;
        }
        return foundnew;
    }

    bool CheckForCompleted()
    {
        foreach (var w in waiters)
        {
            if (w.isCompleted)
                continue; 
            else
                return false;
        }
        return true;
    }

    #endregion

    public void LoadSceneNowAdditive(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    //To Do: 
    //try to do something with the additive LoadSceneMode, maybe adding parts to one big level

    #region Singleton
    public static MyScenesManager instance;
    public void CreateInstance()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }
    #endregion
}
