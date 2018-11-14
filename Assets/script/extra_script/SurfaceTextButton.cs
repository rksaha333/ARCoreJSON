using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurfaceTextButton : MonoBehaviour {

	public GameObject SurfacePlane;
	public Text MyText = null;
	int counter;
	public Button button;
	int index;
	public void CahngeSurfacetext()
	{
		counter++;
		if (counter % 2 == 1)
		{
			MyText.text = "Surface Track Off";
			SurfacePlane.gameObject.SetActive(false);
			GrayButtonColor(index = 0);
		}
		else
		{
			MyText.text = "Surface Track On";
			SurfacePlane.gameObject.SetActive(true);
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
