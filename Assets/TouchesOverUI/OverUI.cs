using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine .EventSystems ;

[RequireComponent (typeof (GraphicRaycaster )) ]
public class OverUI : MonoBehaviour 
{
	//This component needs to be attached in every UI Element which could cause incidents
	public bool IsOverUI()
	{
		if (!this.enabled)
			return false;

		bool OverUI= false;

#if UNITY_EDITOR
        //Mouse
        GraphicRaycaster GR = this.GetComponent<GraphicRaycaster>();
        PointerEventData ped = new PointerEventData(null);
        ped.position = Input.mousePosition;
        List<RaycastResult> result = new List<RaycastResult>();

        GR.Raycast(ped, result);
        if (result.Count == 0 || result == null)
        {
            OverUI = false;
        }
        else
        {
            OverUI = true;
        }
#elif UNITY_ANDROID
         //Touches
        //for (int i = 0; i < Input.touchCount; i++) 
        //{
        //	if (OverUI)
        //		continue;

        //	Touch t = Input.GetTouch (i);

        //	GraphicRaycaster GR = this.GetComponent <GraphicRaycaster > ();
        //	PointerEventData ped = new PointerEventData (null);
        //	ped.position = t.position;
        //	List<RaycastResult > result = new List <RaycastResult > ();

        //	GR.Raycast (ped, result);
        //	if (result.Count == 0 || result == null) 
        //	{
        //		OverUI = false;
        //	}
        //	else 
        //	{
        //		OverUI = true;
        //	}
        //}

#endif
        return OverUI;

	}
}
