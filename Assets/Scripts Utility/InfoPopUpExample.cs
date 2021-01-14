using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPopUpExample : BasicPopUp
{
    [Header("Movel")]
    public string evenMoreInfo;

    [Header("View")]
    public Image infoImg;
    public Text moreInfoText;
    public Button yesBtn;
    public Button noBtn;
    public Button exitBtn;

    //Here we set up communication and events
    void Start()
    {
        //making the button call those method when pressed
        //the same that assinging those in the inspector, 
        //but we need to do this here given the object may lose those references
        yesBtn.onClick.AddListener(OnClickYes);
        noBtn.onClick.AddListener(OnClickNo);
        exitBtn.onClick.AddListener(OnClickExit);

        //Adding listener to my base class event
        base.OnTransitionCompleted += OnReachScreen;
    }

    private void OnReachScreen()
    {
        print(this.gameObject.name + " pop up is ready!");
    }

    //The View handle only Inputs Event or Changes in the esthetic
    #region View
    private void OnClickYes()
    {
        ChangeColor(Color.green);
        ShowInfo();
    }

    private void OnClickNo()
    {
        ChangeColor(Color.red);
    }

    private void OnClickExit()
    {
        ClosePopUp();
    }
    #endregion

    //The Presenter is the Bridge between the Model and the View
    #region Presenter
    private void ChangeColor(Color c)
    {
        infoImg.color = c;
        //Imagine taking this color from the Model
    }

    private void ShowInfo()
    {
        moreInfoText.text = GetMoreInfo();
    }

    private void ClosePopUp()
    {
        //Add time to wahite till animation finish
        base.GoAway();
    }
    #endregion

    //The Model is in charge of getteing all the data needed
    #region Model
    private string GetMoreInfo()
    {
        return "OMG! so much Info!!";
        //Or getting the info from a playerPref or a DB
    }
    #endregion
}
