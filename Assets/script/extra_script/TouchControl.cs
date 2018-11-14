using GoogleARCore.Examples.HelloAR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchControl : MonoBehaviour
{
	//public GameObject MyObject;


	public GameObject SelectedObject;
	public Button button;
	public Text MyText;
	int counter;
	int index;
	public bool TouchState = false;

	public void TouchTextButton()
	{
		
		counter++;
		if (counter % 2 == 1)
		{
			TouchState = false;
			MyText.text = "Touch Stop";
			SelectedObject.gameObject.SetActive(false);
			GrayButtonColor(index=0);
			


		}
		else
		{
			TouchState = true;
			MyText.text = "Touch On";
			SelectedObject.gameObject.SetActive(true);
			GreenButtonColor(index = 1);


		}

	}
	private void GreenButtonColor(int i)
	{
		Color greenColor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
		button = button.GetComponent<Button>();
		ColorBlock cb = button.colors;
		cb.highlightedColor = greenColor;
		button.colors = cb;
	}	
	private void GrayButtonColor(int i)
	{
		//Blue color
		Color grayColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
		button = button.GetComponent<Button>();
		ColorBlock cb = button.colors;
		cb.highlightedColor = grayColor;
		button.colors = cb;

	}
}
