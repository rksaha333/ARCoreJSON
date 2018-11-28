using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectSelection : MonoBehaviour {

	public GameObject[] objectButton = new GameObject[4];
	public GameObject[] numobject = new GameObject[4];
	public Text[] MyText = new Text[4];

	/*
	public GameObject IMS3;
	public GameObject IMS4;
	public GameObject IMS5;
	public GameObject IMS7;
	*/
	int counter;
	int index;
	public bool IMS3VisualState = false;
	public bool IMS4VisualState = false;
	public bool IMS5VisualState = false;
	public bool IMS7VisualState = false;


	public void ObjectButtonIMS3()
	{
		index = 0;
		counter++;
		if (counter % 2 == 1)
		{
		
			IMS3VisualState = false;
			MyText[index].text = "Show";
			//SelectedObject.gameObject.SetActive(false);
			numobject[index].gameObject.SetActive(false);
			GrayButtonColor(index);



		}
		else
		{
			
			IMS3VisualState = true;
			MyText[index].text = "Hide";
			numobject[index].gameObject.SetActive(true); //object canvas will be visiabl										 //SelectedObject.gameObject.SetActive(true);
			GreenButtonColor(index);

		}

	}
	public void ObjectButtonIMS4()
	{
		index = 1;
		counter++;
		if (counter % 2 == 1)
		{
			
			IMS4VisualState = false;
			MyText[index].text = "Show";
			numobject[index].gameObject.SetActive(false);
			GrayButtonColor(index);



		}
		else
		{
			IMS4VisualState = true;
			MyText[index].text = "Hide";
			numobject[index].gameObject.SetActive(true); //object canvas will be visiabl										 //SelectedObject.gameObject.SetActive(true);
			GreenButtonColor(index);

		}

	}
	public void ObjectButtonIMS5()
	{
		index = 2;
		counter++;
		if (counter % 2 == 1)
		{
		
			IMS5VisualState = false;
			MyText[index].text = "Show";
			//SelectedObject.gameObject.SetActive(false);
			numobject[index].gameObject.SetActive(false);
			GrayButtonColor(index);



		}
		else
		{
			IMS5VisualState = true;
			MyText[index].text = "Hide";
			numobject[index].gameObject.SetActive(true); //object canvas will be visiabl										 //SelectedObject.gameObject.SetActive(true);
			GreenButtonColor(index);

		}

	}
	public void ObjectButtonIMS7()
	{
		index = 3;
		counter++;
		if (counter % 2 == 1)
		{
			
			IMS7VisualState = false;
			MyText[index].text = "Show";
			//SelectedObject.gameObject.SetActive(false);
			numobject[index].gameObject.SetActive(false);
			GrayButtonColor(index);



		}
		else
		{
			IMS7VisualState = true;
			MyText[index].text = "Hide";
			numobject[index].gameObject.SetActive(true); //object canvas will be visiabl										 //SelectedObject.gameObject.SetActive(true);
			GreenButtonColor(index);

		}

	}

	private void GreenButtonColor(int i)
	{
		Color greenColor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
		Button btn = objectButton[i].GetComponent<Button>();
		ColorBlock cb = btn.colors;
		cb.highlightedColor = greenColor;
		btn.colors = cb;
	}
	private void GrayButtonColor(int i)
	{
		//Blue color
		Color grayColor = new Color(0.5f, 0.5f, 0.5f, 1.0f);
		Button btn = objectButton[i].GetComponent<Button>();
		ColorBlock cb = btn.colors;
		cb.highlightedColor = grayColor;
		btn.colors = cb;

	}
	
}
