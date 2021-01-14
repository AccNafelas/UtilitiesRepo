using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public Canvas PopUpCanvas;
    public GameObject bigBlocker;

    private BasicPopUp currentPopUp;

    public BasicPopUp CurrentPopUp
    {
        get { return currentPopUp; }
        private set { currentPopUp = value; }
    }

    private bool isShowing;
    public bool ShowingPopUp
    {
        get { return isShowing; }
        private set { isShowing = value; }
    }

    //TO DO: Create a Queue of popUps requests

    private void Awake()
    {
        CreateInstance();
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(PopUpCanvas);
    }

    private void Start()
    {
        
    }

    [ContextMenu("Show Info Pop Up")]///-> this is just to trigger this method from the isnpector
    public void ShowInfoPopUp()
    {
        ShowByName("PopUp Example");
    }

    public void ShowCover()
    {
        ShowByName("Huge Cover");
    }

    public void ShowByName(string popUpName)
    {
        //Not allowing tow at tthe same time
        if (isShowing || currentPopUp != null) return;

        GameObject popUp = LoadObj(popUpName);
        if (popUp == null)
        {
            Debug.LogAssertion("The pop Up "+ popUpName +" could not be load!");
            return;
        }
        currentPopUp = popUp.GetComponent<BasicPopUp>();
        isShowing = true;
        ToggleBlocker();
        popUp.GetComponent<BasicPopUp>().Arrive();

    }

    #region Functionalities
    public GameObject LoadObj(string objName)
    {
        GameObject obj =Resources.Load<GameObject>("PopUps/" + objName) as GameObject;
        return Instantiate(obj, PopUpCanvas.transform);
    }

    private void ToggleBlocker()
    {
        if(bigBlocker.activeInHierarchy)
            bigBlocker.SetActive(false);
        else
            bigBlocker.SetActive(true);
    }

    /// <summary>
    /// Try closing the Pop Up Selected
    /// </summary>
    /// <param name="go"></param>
    public void Release(GameObject go)
    {
        currentPopUp = null;
        Destroy(go);
        isShowing = false;
        ToggleBlocker();
    }
    /// <summary>
    /// Cloase current open Pop Up
    /// </summary>
    public void Release()
    {
        Destroy(currentPopUp.gameObject);
        currentPopUp = null;
        isShowing = false;
        ToggleBlocker();
    }

    //IEnumerator LoadObjAsync(string objName)
    //{
    //    Resources.Load<GameObject>("PopUps/" + objName);
    //    yield return null;
    //}
    #endregion


    #region Singleton
    public static PopUpManager instance;
    public void CreateInstance()
    {
        if (instance != null)
            Destroy(this.gameObject);
        else
            instance = this;
    }
    #endregion
}
