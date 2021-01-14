using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputVerification : MonoBehaviour
{

	public OverUI[] EnUI;

	bool IsTouchingOverUI()
	{
		bool OverUIElement =false; 

		for (int i = 0; i < EnUI.Length; i++)
		{
			if (OverUIElement)
				continue;
			OverUIElement = EnUI [i].IsOverUI ();

		}

		return OverUIElement;
	}

}
