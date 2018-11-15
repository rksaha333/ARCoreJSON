using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class demoIoT : MonoBehaviour {

	public Text IMS3StateTest;
	public string IMS3Valtext;
	public Text IMS3AStateTest;
	public string IMS3AValtext;
	public Text IMS3BStateTest;
	public string IMS3BValtext;
	public Text IMS4AStateTest;
	public string IMS4AValtext;
	public Text IMS4BStateTest;
	public string IMS4BValtext;
	public Text IMS5AStateTest;
	public string IMS5AValtext;
	public Text IMS5BStateTest;
	public string IMS5BValtext;
	public Text IMS7StateTest;
	public string IMS7Valtext;

	//here for the stattion identifier
	public Text IMS3StationTest;
	public string IMS3StationValtext;
	public Text IMS3AStationTest;
	public string IMS3AStationValtext;
	public Text IMS3BStationTest;
	public string IMS3BStationValtext;
	public Text IMS4AStationTest;
	public string IMS4AStationValtext;
	public Text IMS4BStationTest;
	public string IMS4BStationValtext;
	public Text IMS5AStationTest;
	public string IMS5AStationValtext;
	public Text IMS5BStationTest;
	public string IMS5BStationValtext;
	public Text IMS7StationTest;
	public string IMS7StationValtext;
	int index;
   //This button for the state_name of all station
	public GameObject[] Buttons = new GameObject[8];
	//this is the station identifier button for all station
	public GameObject[] But = new GameObject[8];
	
	
	// Use this for initialization

	void Update()
	{
		
		//check the station status 
		IMS3StateTest.text =  IMS3Valtext;
		CheckIMS3MachineState();  
		IMS3AStateTest.text = IMS3AValtext;
		CheckIMS3AMachineState();
		IMS3BStateTest.text = IMS3BValtext;
		CheckIMS3BMachineState();
		IMS4AStateTest.text = IMS4AValtext;
		CheckIMS4AMachineState();
		IMS4BStateTest.text = IMS4BValtext;
		CheckIMS4BMachineState();
		IMS5AStateTest.text = IMS5AValtext;
		CheckIMS5AMachineState();
		IMS5BStateTest.text = IMS5BValtext;
		CheckIMS5BMachineState();
		IMS7StateTest.text = IMS7Valtext;
		CheckIMS7MachineState();

		//Station name repitation 
		IMS3StationTest.text = IMS3StationValtext;
		CheckIMS3MachineStation();  //check the state name
		IMS3AStationTest.text = IMS3AStationValtext;
		CheckIMS3AMachineStation();
		IMS3BStationTest.text = IMS3BStationValtext;
		CheckIMS3BMachineStation();
		IMS4AStationTest.text = IMS4AStationValtext;
		CheckIMS4AMachineStation();
		IMS4BStationTest.text = IMS4BStationValtext;
		CheckIMS4BMachineStation();
		IMS5AStationTest.text = IMS5AStationValtext;
		CheckIMS5AMachineStation();
		IMS5BStationTest.text = IMS5BStationValtext;
		CheckIMS5BMachineStation();
		IMS7StationTest.text = IMS7StationValtext;
		CheckIMS7MachineStation();


	}


	//chenge the color according to the contant "state_name"
	private void CheckIMS3MachineState()
	{
		index = 0;
		if (IMS3Valtext.Contains("Idle"))
		{
			GreenButtonColor(index);
		}
		if (IMS3Valtext.Contains("Transfer Acknowledge"))
		{
			GreenButtonColor(index);
		}
		if (IMS3Valtext.Contains("Reading Wait"))
		{
			YellowButtonColor(index);
		}
		
		if (IMS3Valtext.Contains("Transfer Sleep"))
		{
			GreenButtonColor(index);
		}
		if (IMS3Valtext.Contains("Unmount"))
		{
			RedButtonColor(index);
		}
		if (IMS3Valtext.Contains("Error Transfer"))
		{
			RedButtonColor(index);
		}
		if (IMS3Valtext.Contains("No Carrier Waiting"))
		{
			GreenButtonColor(index);
		}
		if (IMS3Valtext.Contains("Error B1"))
		{
			RedButtonColor(index);
		}
		if (IMS3Valtext.Contains("Reading Carrier"))
		{
			YellowButtonColor(index);
		}



	}
	private void CheckIMS3AMachineState()
	{
		index = 1;
		if (IMS3AValtext.Contains("Idle"))
		{
			GreenButtonColor(index);
		}
		if (IMS3AValtext.Contains("Transfer Acknowledge"))
		{
			GreenButtonColor(index);
		}
		if (IMS3AValtext.Contains("Reading Wait"))
		{
			YellowButtonColor(index);
		}
		if (IMS3AValtext.Contains("Transfer Sleep"))
		{
			GreenButtonColor(index);
		}
		if (IMS3AValtext.Contains("Unmount"))
		{
			RedButtonColor(index);
		}
		if (IMS3AValtext.Contains("Error Transfer"))
		{
			RedButtonColor(index);
		}
		if (IMS3AValtext.Contains("No Carrier Waiting"))
		{
			GreenButtonColor(index);
		}
		if (IMS3AValtext.Contains("Error B1"))
		{
			RedButtonColor(index);
		}
		if (IMS3AValtext.Contains("Reading Carrier"))
		{
			YellowButtonColor(index);
		}




	}
	private void CheckIMS3BMachineState()
	{
		index = 2;
		if (IMS3BValtext.Contains("Idle"))
		{
			GreenButtonColor(index);
		}
		if (IMS3BValtext.Contains("Transfer Acknowledge"))
		{
			GreenButtonColor(index);
		}
		if (IMS3BValtext.Contains("Reading Wait"))
		{
			YellowButtonColor(index);
		}
		if (IMS3BValtext.Contains("Transfer Sleep"))
		{
			GreenButtonColor(index);
		}
		if (IMS3BValtext.Contains("Unmount"))
		{
			RedButtonColor(index);
		}
		if (IMS3BValtext.Contains("Error Transfer"))
		{
			RedButtonColor(index);
		}
		if (IMS3BValtext.Contains("No Carrier Waiting"))
		{
			GreenButtonColor(index);
		}
		if (IMS3BValtext.Contains("Error B1"))
		{
			RedButtonColor(index);
		}
		if (IMS3BValtext.Contains("Reading Carrier"))
		{
			YellowButtonColor(index);
		}


	}
	private void CheckIMS4AMachineState()
	{
		index = 3;
		if (IMS4AValtext.Contains("Idle"))
		{
			GreenButtonColor(index);
		}
		if (IMS4AValtext.Contains("Transfer Acknowledge"))
		{
			GreenButtonColor(index);
		}
		if (IMS4AValtext.Contains("Reading Wait"))
		{
			YellowButtonColor(index);
		}
		if (IMS4AValtext.Contains("Transfer Sleep"))
		{
			GreenButtonColor(index);
		}
		if (IMS4AValtext.Contains("Unmount"))
		{
			RedButtonColor(index);
		}
		if (IMS4AValtext.Contains("Error Transfer"))
		{
			RedButtonColor(index);
		}
		if (IMS4AValtext.Contains("No Carrier Waiting"))
		{
			GreenButtonColor(index);
		}
		if (IMS4AValtext.Contains("Error B1"))
		{
			RedButtonColor(index);
		}
		if (IMS4AValtext.Contains("Reading Carrier"))
		{
			YellowButtonColor(index);
		}


	}
	private void CheckIMS4BMachineState()
	{
		index = 4;
		if (IMS4BValtext.Contains("Idle"))
		{
			GreenButtonColor(index);
		}
		if (IMS4BValtext.Contains("Transfer Acknowledge"))
		{
			GreenButtonColor(index);
		}
		if (IMS4BValtext.Contains("Reading Wait"))
		{
			YellowButtonColor(index);
		}
		if (IMS4BValtext.Contains("Transfer Sleep"))
		{
			GreenButtonColor(index);
		}
		if (IMS4BValtext.Contains("Unmount"))
		{
			RedButtonColor(index);
		}
		if (IMS4BValtext.Contains("Error Transfer"))
		{
			RedButtonColor(index);
		}
		if (IMS4BValtext.Contains("No Carrier Waiting"))
		{
			GreenButtonColor(index);
		}
		if (IMS4BValtext.Contains("Error B1"))
		{
			RedButtonColor(index);
		}
		if (IMS4BValtext.Contains("Reading Carrier"))
		{
			YellowButtonColor(index);
		}


	}
	private void CheckIMS5AMachineState()
	{
		index = 5;
		if (IMS5AValtext.Contains("Idle"))
		{
			GreenButtonColor(index);
		}
		if (IMS5AValtext.Contains("Transfer Acknowledge"))
		{
			GreenButtonColor(index);
		}

		if (IMS5AValtext.Contains("Reading Wait"))
		{
			YellowButtonColor(index);
		}
		if (IMS5AValtext.Contains("Transfer Sleep"))
		{
			GreenButtonColor(index);
		}
		if (IMS5AValtext.Contains("Unmount"))
		{
			RedButtonColor(index);
		}
		if (IMS5AValtext.Contains("Error Transfer"))
		{
			RedButtonColor(index);
		}
		if (IMS5AValtext.Contains("No Carrier Waiting"))
		{
			GreenButtonColor(index);
		}
		if (IMS5AValtext.Contains("Error B1"))
		{
			RedButtonColor(index);
		}
		if (IMS5AValtext.Contains("Reading Carrier"))
		{
			YellowButtonColor(index);
		}


	}
	private void CheckIMS5BMachineState()
	{
		index = 6;
		if (IMS5BValtext.Contains("Idle"))
		{
			GreenButtonColor(index);
		}
		if (IMS5BValtext.Contains("Transfer Acknowledge"))
		{
			GreenButtonColor(index);
		}
		if (IMS5BValtext.Contains("Reading Wait"))
		{
			YellowButtonColor(index);
		}
		if (IMS5BValtext.Contains("Transfer Sleep"))
		{
			GreenButtonColor(index);
		}
		if (IMS5BValtext.Contains("Unmount"))
		{
			RedButtonColor(index);
		}
		if (IMS5BValtext.Contains("Error Transfer"))
		{
			RedButtonColor(index);
		}
		if (IMS5BValtext.Contains("No Carrier Waiting"))
		{
			GreenButtonColor(index);
		}
		if (IMS5BValtext.Contains("Error B1"))
		{
			RedButtonColor(index);
		}
		if (IMS5BValtext.Contains("Reading Carrier"))
		{
			YellowButtonColor(index);
		}


	}
	private void CheckIMS7MachineState()
	{
		index = 7;
		if (IMS7Valtext.Contains("Idle"))
		{
			GreenButtonColor(index);
		}
		if (IMS7Valtext.Contains("Transfer Acknowledge"))
		{
			GreenButtonColor(index);
		}

		if (IMS7Valtext.Contains("Reading Wait"))
		{
			YellowButtonColor(index);
		}
		if (IMS7Valtext.Contains("Transfer Sleep"))
		{
			GreenButtonColor(index);
		}
		if (IMS7Valtext.Contains("Unmount"))
		{
			RedButtonColor(index);
		}
		if (IMS7Valtext.Contains("Error Transfer"))
		{
			RedButtonColor(index);
		}
		if (IMS7Valtext.Contains("No Carrier Waiting"))
		{
			GreenButtonColor(index);
		}
		if (IMS7Valtext.Contains("Error B1"))
		{
			RedButtonColor(index);
		}
		if (IMS7Valtext.Contains("Reading Carrier"))
		{
			YellowButtonColor(index);
		}


	}

	//change the station name color
	//Front station will be gree(IMS5A,IMS5B,IMS7;IMS3)
	//back station will be yellow(IMS3a,IMS3B,IMS4A,IMS4B)

	private void CheckIMS3MachineStation()
	{
		index = 0;
			CyanButtonColor(index);
	}
	private void CheckIMS3AMachineStation()
	{
		index = 1;
		MagentaButtonColor(index);
		
	}
	private void CheckIMS3BMachineStation()
	{
		index = 2;
		MagentaButtonColor(index);
		
	}
	private void CheckIMS4AMachineStation()
	{
		index = 3;		
			MagentaButtonColor(index);
		
	}
	private void CheckIMS4BMachineStation()
	{
		index = 4;	 		
			MagentaButtonColor(index);
		
	}
	private void CheckIMS5AMachineStation()
	{
		index = 5;
			CyanButtonColor(index);
		
	}
	private void CheckIMS5BMachineStation()
	{
		index = 6;
			CyanButtonColor(index);
		
	}
	private void CheckIMS7MachineStation()
	{
		index = 7;
		CyanButtonColor(index);
	}




	

	private void GreenButtonColor(int i)
	{
		Color greenColor=new Color(0.0f, 1.0f, 0.0f, 1.0f);
		Button b = Buttons[i].GetComponent<Button>();
		ColorBlock cb = b.colors;
		cb.normalColor = greenColor;
		b.colors = cb;
	}
	private void RedButtonColor(int i)
	{
		//Debug.Log ("Red"); 
		Color redColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
		Button b = Buttons[i].GetComponent<Button>();
		ColorBlock cb = b.colors;
		cb.normalColor = redColor;
		b.colors = cb;
	}
	private void YellowButtonColor(int i)
	{
		//Debug.Log ("Yellow");
		Color yellowColor = new Color(1.0f, 0.92f, 0.016f, 1.0f);
		Button b = Buttons[i].GetComponent<Button>();
		ColorBlock cb = b.colors;
		cb.normalColor = yellowColor;
		b.colors = cb;
	}
	private void CyanButtonColor(int i)
	{
		//Blue color
		Color cyanColor = new Color(0.0f, 1.0f, 1.0f, 1.0f);
		Button b = But[i].GetComponent<Button>();
		ColorBlock cb = b.colors;
		cb.normalColor = cyanColor;
		b.colors = cb;

	}
	private void MagentaButtonColor(int i)
	{
		//Blue color
		Color magentaColor = new Color(0.5f, 0.5f, 1.0f, 1.0f);
		Button b = But[i].GetComponent<Button>();
		ColorBlock cb = b.colors;
		cb.normalColor = magentaColor;
		b.colors = cb;

	}


	void SelectionUI()
	{

	}
}
