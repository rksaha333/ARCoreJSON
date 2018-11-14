using GoogleARCore.Examples.HelloAR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScaleControl : MonoBehaviour
{
	//public GameObject MyObject;


	//public GameObject SelectedObject;
	public Button button;
	public Text MyText;
	public Canvas Display;
	int counter;
	int index;
	public bool DisplayScaleon=false;
	private float zoomSpeed=0.5f;

	public void ScaleTextButton()
	{
		
		counter++;
		if (counter % 2 == 1)
		{
			
			DisplayScaleon =false; //condition will be false
			MyText.text = "Zoom Stop"; //This text will be display on button
			GrayButtonColor(index = 0);   //AS the deactivation the color will be gray
			gameObject.GetComponent<TouchControl>().TouchState=false; //touch state will set as false
			Display.gameObject.SetActive(false); // The canvas display will be disapper
			
			


		}
		else
		{
			//All the coments will be as well for here just in oposite way
			//This is the Start state
			
			DisplayScaleon = true;
			MyText.text = "Zoom Start";
			GreenButtonColor(index = 1);
			gameObject.GetComponent<TouchControl>().TouchState=false;
			Display.gameObject.SetActive(true);
		


		}

	}
		


	
	private void GreenButtonColor(int i)
	{
		//Green coolr on activation
		Color greenColor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
		button = button.GetComponent<Button>();
		ColorBlock cb = button.colors;
		cb.highlightedColor = greenColor;
		button.colors = cb;
	}	
	private void GrayButtonColor(int i)
	{
		//Gray Color on diactivation
		Color grayColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
		button = button.GetComponent<Button>();
		ColorBlock cb = button.colors;
		cb.highlightedColor = grayColor;
		button.colors = cb;

	}
}
