using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucasWebsite : MonoBehaviour {

	public void OpenURL()
	{
		Application.OpenURL("https://www.lucas-nuelle.us/2764/apg/552/Products/Automation-Technology.htm");
		Debug.Log("is this working?");
	}
}
