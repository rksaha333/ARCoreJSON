using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTextButton : MonoBehaviour {

	public GameObject Display;
	public Button button;
	public Text MyText = null;
	int counter;
	int index;
	public void CahngeDispalytext()
	{
		counter++;
		if (counter % 2 == 1)
		{
			MyText.text = "Display Off";
			Display.gameObject.SetActive(false);
			//gameObject.GetComponent<ScaleControl>().DisplayScaleon = false;
			GrayButtonColor(index = 0);



		}
		else
		{
			MyText.text = "Display On";
			Display.gameObject.SetActive(true);
			//gameObject.GetComponent<ScaleControl>().DisplayScaleon = true;
			GreenButtonColor(index = 0);
			

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
