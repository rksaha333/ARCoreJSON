
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GoogleARCore;
using System;
//using System.IO.Ports;

public class IotDrive : MonoBehaviour 
{

	string value;
	// first define the front canvas station information
	public Text IMS3MachineStateText;
	public string IMS3valtext;
	public Text IMS7MachineStateText;
	public string IMS7valtext;
	public Text IMS5BMachineStateText;
	public string IMS5Bvaltext;
	public Text IMS5AMachineStateText;
	public string IMS5Avaltext;

	//Here the back canvas station information

	public Text IMS4AMachineStateText;
	public string IMS4Avaltext;
	public Text IMS4BMachineStateText;
	public string IMS4Bvaltext;
	public Text IMS3BMachineStateText;
	public string IMS3Bvaltext;
	public Text IMS3AMachineStateText;
	public string IMS3Avaltext;


	


	//public Text MotionText;
	//public bool motionDetectedBool = false;

	//public Text currentMeasurement;

	//IMS3MachineState condition declearation

	string IMS3WaitingState=" ";
	string IMS3TransferState=" ";
	string IMS3ErroState=" ";
	bool IMS3State1;//this state means active
	bool IMS3State2;//this state means the waiting
	bool IMS3State3;//this state is not error/not responding

	//IMS3A Machine State
	string IMS3AWaitingState = " ";
	string IMS3ATransferState = " ";
	string IMS3AErroState = " ";
	bool IMS3AState1;//this state means active
	bool IMS3AState2;//this state means the waiting
	bool IMS3AState3;//this state is not error/not responding

	//IMS3B Machine State

	string IMS3BWaitingState = " ";
	string IMS3BTransferState = " ";
	string IMS3BErroState = " ";
	bool IMS3BState1;//this state means active
	bool IMS3BState2;//this state means the waiting
	bool IMS3BState3;//this state is not error/not responding

	//IMS4A Machine state

	string IMS4AWaitingState = " ";
	string IMS4ATransferState = " ";
	string IMS4AErroState = " ";
	bool IMS4AState1;//this state means active
	bool IMS4AState2;//this state means the waiting
	bool IMS4AState3;//this state is not error/not responding

	//IMS4B Machine state

	string IMS4BWaitingState = " ";
	string IMS4BTransferState = " ";
	string IMS4BErroState = " ";
	bool IMS4BState1;//this state means active
	bool IMS4BState2;//this state means the waiting
	bool IMS4BState3;//this state is not error/not responding

	//IMS5A Machine state
	string IMS5AWaitingState = " ";
	string IMS5ATransferState = " ";
	string IMS5AErroState = " ";
	bool IMS5AState1;//this state means active
	bool IMS5AState2;//this state means the waiting
	bool IMS5AState3;//this state is not error/not responding

	//IMS5B Machine state

	string IMS5BWaitingState = " ";
	string IMS5BTransferState = " ";
	string IMS5BErroState = " ";
	bool IMS5BState1;//this state means active
	bool IMS5BState2;//this state means the waiting
	bool IMS5BState3;//this state is not error/not responding

	//IMS7 Machine state

	string IMS7WaitingState = " ";
	string IMS7TransferState = " ";
	string IMS7ErroState = " ";
	bool IMS7State1;//this state means active
	bool IMS7State2;//this state means the waiting
	bool IMS7State3;//this state is not error/not responding







	//Here is indicate the number of button on the canvas that is linked with the infotext and val text
	int index;
	public GameObject[] Buttons = new GameObject[8];

	// initializing the machine state info as not to displayed
	// this part will prevent to display at the beginning



	bool hit;
	bool showIMS3MachineState = false;
	bool showIMS3AMachineState = false;
	bool showIMS3BMachineState = false;
	bool showIMS4AMachineState = false;
	bool showIMS4BMachineState = false;
	bool showIMS5AMachineState = false;
	bool showIMS5BMachineState = false;
	bool showIMS7MachineState = false;

	
	void Update()
	{
	
		//Here the value of the text field assign the value of the value field in a single button
		//Front canvas recognition
		//IMS3
		IMS3MachineStateText.text = IMS3valtext.ToString();	   //
		CheckIMS3Machinestatus();	 //	   This function will be check the state condition and assign the button colorfor IMS3
		//IMS7
		IMS7MachineStateText.text = IMS7valtext.ToString();
		CheckIMS7Machinestatus();   //This function will be check the state condition and assign the button color for station
									
		IMS5BMachineStateText.text = IMS5Bvaltext.ToString();
		CheckIMS5BMachinestatus();	 //
		//IMS5A
		IMS5AMachineStateText.text = IMS5Avaltext.ToString();
		CheckIMS5AMachinestatus();

		//Back canvas recognition
		//IMS3A
		IMS3AMachineStateText.text = IMS3Avaltext.ToString();
		CheckIMS3AMachinestatus();
		//IMS3B
		IMS3BMachineStateText.text = IMS3Bvaltext.ToString();
		CheckIMS3BMachinestatus();
		//IMS4A
		IMS4AMachineStateText.text = IMS4Avaltext.ToString();
		CheckIMS4AMachinestatus();
		//IMS4B
		IMS4BMachineStateText.text = IMS4Bvaltext.ToString();
		CheckIMS4BMachinestatus();


		// here get the particular machine state information
		getIMS3MachineStateInfo(); //This function will check the state condition and assign the state value accordingly
		if (showIMS3MachineState)  //if this condition will be true
		{
			showIMS3MachineStateInfo();	//this function will be displaythe value and make state as true
		}

		getIMS7MachineStateInfo();
		if (showIMS7MachineState)
		{
			showIMS7MachineStateInfo();
		}

		getIMS5BMachineStateInfo();
		if (showIMS5BMachineState)
		{
			showIMS5BMachineStateInfo();
		}

		getIMS5AMachineStateInfo();
		if (showIMS5AMachineState)
		{
			showIMS5AMachineStateInfo();
		}

		getIMS3AMachineStateInfo();
		if (showIMS3AMachineState)
		{
			showIMS3AMachineStateInfo();
		}

		getIMS3BMachineStateInfo();
		if (showIMS3BMachineState)
		{
			showIMS3BMachineStateInfo();
		}

		getIMS4AMachineStateInfo();
		if (showIMS4AMachineState)
		{
			showIMS4AMachineStateInfo();
		}

		getIMS4BMachineStateInfo();
		if (showIMS4BMachineState)
		{
			showIMS4BMachineStateInfo();
		}
	}
	//IMS3 get the machine state data according to the condition state info

	public void getIMS3MachineStateInfo()	//here collect the state information
	{
		if (IMS3State1==true)
		{

			IMS3WaitingState = IMS3valtext;

		}
		else if (IMS3State2==true)
		{
			IMS3TransferState = IMS3valtext;

		}
		else
		{
				IMS3ErroState = IMS3valtext;
		}

		

	}
			

	   /*

		if (State2)
		{
			IMS3valtext = IMS3valtext.ToString();

		}
		else
			State2 = false;

		if (IMS3State3)
		{

			IMS3valtext = IMS3valtext.ToString();
		}
		else
			return;


	}
	*/

	public void showIMS3MachineStateInfo()
	{
		IMS3valtext = IMS3valtext.ToString();
		showIMS3MachineState = true;
	}

	//IMS3A get the machine state data according to the condition state info

	public void getIMS3AMachineStateInfo()   //here collect the state information
	{
		if (IMS3AState1 == true)
		{

			IMS3AWaitingState = IMS3Avaltext;

		}
		else if (IMS3AState2 == true)
		{
			IMS3ATransferState = IMS3Avaltext;

		}
		else
		{
			IMS3AErroState = IMS3Avaltext;
		}



	}



	public void showIMS3AMachineStateInfo()
	{
		IMS3Avaltext = IMS3Avaltext.ToString();
		showIMS3AMachineState = true;
	}

	//IMS3B get the data and show function
	public void getIMS3BMachineStateInfo()   //here collect the state information
	{
		if (IMS3BState1 == true)
		{

			IMS3BWaitingState = IMS3Bvaltext;

		}
		else if (IMS3BState2 == true)
		{
			IMS3BTransferState = IMS3Bvaltext;

		}
		else
		{
			IMS3BErroState = IMS3Bvaltext;
		}



	}



	public void showIMS3BMachineStateInfo()
	{
		IMS3Bvaltext = IMS3Bvaltext.ToString();
		showIMS3BMachineState = true;
	}

	//IMS4A get the data and show function
	public void getIMS4AMachineStateInfo()   //here collect the state information
	{
		if (IMS4AState1 == true)
		{

			IMS4AWaitingState = IMS4Avaltext;

		}
		else if (IMS4AState2 == true)
		{
			IMS4ATransferState = IMS4Avaltext;

		}
		else
		{
			IMS4AErroState = IMS4Avaltext;
		}



	}



	public void showIMS4AMachineStateInfo()
	{
		IMS4Avaltext = IMS4Avaltext.ToString();
		showIMS4AMachineState = true;
	}

	//IMS4B get the data and show function
	public void getIMS4BMachineStateInfo()   //here collect the state information
	{
		if (IMS4BState1 == true)
		{

			IMS4BWaitingState = IMS4Bvaltext;

		}
		else if (IMS4BState2 == true)
		{
			IMS4BTransferState = IMS4Bvaltext;

		}
		else
		{
			IMS4BErroState = IMS4Bvaltext;
		}



	}



	public void showIMS4BMachineStateInfo()
	{
		IMS4Bvaltext = IMS4Bvaltext.ToString();
		showIMS4BMachineState = true;
	}

	//IMS5A get the data and show function
	public void getIMS5AMachineStateInfo()   //here collect the state information
	{
		if (IMS5AState1 == true)
		{

			IMS5AWaitingState = IMS5Avaltext;

		}
		else if (IMS5AState2 == true)
		{
			IMS5ATransferState = IMS5Avaltext;

		}
		else
		{
			IMS5AErroState = IMS5Avaltext;
		}



	}



	public void showIMS5AMachineStateInfo()
	{
		IMS5Avaltext = IMS5Avaltext.ToString();
		showIMS5AMachineState = true;
	}


	//IMS5B get the data and show function
	public void getIMS5BMachineStateInfo()   //here collect the state information
	{
		if (IMS5BState1 == true)
		{

			IMS5BWaitingState = IMS5Bvaltext;

		}
		else if (IMS5BState2 == true)
		{
			IMS5BTransferState = IMS5Bvaltext;

		}
		else
		{
			IMS5BErroState = IMS5Bvaltext;
		}



	}



	public void showIMS5BMachineStateInfo()
	{
		IMS5Bvaltext = IMS5Bvaltext.ToString();
		showIMS5BMachineState = true;
	}

	//IMS5B get the data and show function
	public void getIMS7MachineStateInfo()   //here collect the state information
	{
		if (IMS7State1 == true)
		{

			IMS7WaitingState = IMS7valtext;

		}
		else if (IMS7State2 == true)
		{
			IMS7TransferState = IMS7valtext;

		}
		else
		{
			IMS7ErroState = IMS7valtext;
		}



	}



	public void showIMS7MachineStateInfo()
	{
		IMS7valtext = IMS7valtext.ToString();
		showIMS7MachineState = true;
	}
	/*
	 //This is the main code but execution will be stop in this scope
	//IMS7 state condition

	public void getIMS7MachineStateInfo()
	{

		if (IMS7WaitingState)
		{
			IMS7valtext = IMS7valtext.ToString();

		}
		else
			IMS7WaitingState = false;



		if (IMS7MoveState)
		{
			IMS7valtext = IMS7valtext.ToString();

		}
		else
			IMS7MoveState = false;

		if (IMS7ErrorState)
		{

			IMS7valtext = IMS7valtext.ToString();
		}
		else
			return;

	}

	public void showIMS7MachinestateInfo()
	{

		IMS7valtext = IMS7valtext.ToString();
		showIMS7MachineState = true;
	}
	//IMS5B state condition

	public void getIMS5BMachineStateInfo()
	{

		if (IMS5BWaitingState)
		{
			IMS5Bvaltext = IMS5Bvaltext.ToString();

		}
		else
			IMS5BWaitingState = false;



		if (IMS5BMoveState)
		{
			IMS5Bvaltext = IMS5Bvaltext.ToString();

		}
		else
			IMS5BMoveState = false;

		if (IMS5BErrorState)
		{

			IMS5Bvaltext = IMS5Bvaltext.ToString();
		}
		else
			return;

	}
	public void showIMS5BMachineStateInfo()
	{
		IMS5Bvaltext = IMS5Bvaltext.ToString();
		showIMS5BMachineState = true;
	}

	//IMS5A state condition

	public void getIMS5AMachineStateInfo()
	{

		if (IMS5AWaitingState)
		{
			IMS5Avaltext = IMS5Avaltext.ToString();

		}
		else
			IMS5AWaitingState = false;



		if (IMS5AMoveState)
		{
			IMS5Avaltext = IMS5Avaltext.ToString();

		}
		else
			IMS5AMoveState = false;

		if (IMS5AErrorState)
		{

			IMS5Avaltext = IMS5Avaltext.ToString();
		}
		else
			return;

	}
	public void showIMS5AMachineStateInfo()
	{
		IMS5Avaltext = IMS5Avaltext.ToString();
		showIMS5AMachineState = true;
	}

	//IMS3A state condition

	public void getIMS3AMachineStateInfo()
	{

		if (IMS3AWaitingState)
		{
			IMS3Avaltext = IMS3Avaltext.ToString();

		}
		else
			IMS3AWaitingState = false;



		if (IMS3AMoveState)
		{
			IMS3Avaltext = IMS3Avaltext.ToString();

		}
		else
			IMS3AMoveState = false;

		if (IMS3AErrorState)
		{

			IMS3Avaltext = IMS3Avaltext.ToString();
		}
		else
			return;

	}
	public void showIMS3AMachineStateInfo()
	{
		IMS3Avaltext = IMS3Avaltext.ToString();
		showIMS3AMachineState = true;
	}

	//IMS3B state condition execution

	public void getIMS3BMachineStateInfo()
	{

		if (IMS3BWaitingState)
		{
			IMS3Bvaltext = IMS3Bvaltext.ToString();

		}
		else
			IMS3BWaitingState = false;



		if (IMS3BMoveState)
		{
			IMS3Bvaltext = IMS3Bvaltext.ToString();

		}
		else
			IMS3BMoveState = false;

		if (IMS3BErrorState)
		{

			IMS3Bvaltext = IMS3Bvaltext.ToString();
		}
		else
			return;

	}
	public void showIMS3BMachineStateInfo()
	{
		IMS3Bvaltext = IMS3Bvaltext.ToString();
		showIMS3BMachineState = true;
	}
	//IMS4A state condition

	public void getIMS4AMachineStateInfo()
	{

		if (IMS4AWaitingState)
		{
			IMS4Avaltext = IMS4Avaltext.ToString();

		}
		else
			IMS4AWaitingState = false;



		if (IMS4AMoveState)
		{
			IMS4Avaltext = IMS4Avaltext.ToString();

		}
		else
			IMS4AMoveState = false;

		if (IMS4AErrorState)
		{

			IMS4Avaltext = IMS4Avaltext.ToString();
		}
		else
			return;

	}
	public void showIMS4AMachineStateInfo()
	{
		IMS4Avaltext = IMS4Avaltext.ToString();
		showIMS4AMachineState = true;
	}
	//IMS4B state condition


	public void getIMS4BMachineStateInfo()
	{

		if (IMS4BWaitingState)
		{
			IMS4Bvaltext = IMS4Bvaltext.ToString();

		}
		else
			IMS4BWaitingState = false;



		if (IMS4BMoveState)
		{
			IMS4Bvaltext = IMS4Bvaltext.ToString();

		}
		else
			IMS4BMoveState = false;

		if (IMS4BErrorState)
		{

			IMS4Bvaltext = IMS4Bvaltext.ToString();
		}
		else
			return;

	}
	public void showIMS4BMachineStateInfo()
	{
		IMS4Bvaltext = IMS4Bvaltext.ToString();
		showIMS4BMachineState = true;
	}

		*/

	// reset the boll value

	public void resetBool()
	{
		/*LowerVariance.text = "n/a";
		UpperVariance.text = "n/a";
		LowerTime.text = "n/a";
		UpperTime.text = "n/a";
	    showI = false;
		*/
		showIMS3MachineState = false;
		showIMS3AMachineState = false;
		showIMS3BMachineState = false;
		showIMS4AMachineState = false;
		showIMS4BMachineState = false;
		showIMS5AMachineState = false;
		showIMS5BMachineState = false;
		showIMS7MachineState = false;
	}
	// manipulate the button color for IMS3 according to different state of the machine
	private void CheckIMS3Machinestatus()
	{
		index = 0;
		if (IMS3State1 == true) // Green Color - information is coming is ok
			greenButtonColor(index);// (Buttons[0]);
		if (IMS3State2 == true) // Red Color - information is waiting is too Hot
			orangeButtonColor(index);
		if (IMS3State3 == true) // Blue Color -  information is not available is too Cold
			redButtonColor(index);
	}
	// manipulate the button color for IMS3A according to different state of the machine
	private void CheckIMS3AMachinestatus()
	{
		index = 1;
		if (IMS3AState1 == true) // Green Color -
			greenButtonColor(index);// (Buttons[0]);
		if (IMS3AState2 == true) // Red Color - 
			orangeButtonColor(index);
		if (IMS3AState3 == true) // Blue Color - 
			redButtonColor(index);
	}

	// manipulate the button color for IMS3B according to different state of the machine
	private void CheckIMS3BMachinestatus()
	{
		index = 2;
		if (IMS3BState1 == true) // Green Color - information is coming is ok
			greenButtonColor(index);// (Buttons[0]);
		if (IMS3BState2 == true) // Red Color - information is waiting is too Hot
			orangeButtonColor(index);
		if (IMS3BState3 == true) // Blue Color -  information is not available is too Cold
			redButtonColor(index);
	}

	// manipulate the button color for IMS4A according to different state of the machine
	private void CheckIMS4AMachinestatus()
	{
		index = 3;
		if (IMS4AState1 == true) // Green Color - information is coming is ok
			greenButtonColor(index);// (Buttons[0]);
		if (IMS4AState2 == true) // Red Color - information is waiting is too Hot
			orangeButtonColor(index);
		if (IMS4AState3 == true) // Blue Color -  information is not available is too Cold
			redButtonColor(index);
	}

	// manipulate the button color for IMS4B according to different state of the machine
	private void CheckIMS4BMachinestatus()
	{
		index = 4;
		if (IMS4BState1 == true) // Green Color - information is coming is ok
			greenButtonColor(index);// (Buttons[0]);
		if (IMS4BState2 == true) // Red Color - information is waiting is too Hot
			orangeButtonColor(index);
		if (IMS4BState3 == true) // Blue Color -  information is not available is too Cold
			redButtonColor(index);
	}

	// manipulate the button color for IMS5A according to different state of the machine
	private void CheckIMS5AMachinestatus()
	{
		index = 5;
		if (IMS5AState1 == true) // Green Color - information is coming is ok
			greenButtonColor(index);// (Buttons[0]);
		if (IMS5AState2 == true) // Red Color - information is waiting is too Hot
			orangeButtonColor(index);
		if (IMS5AState3 == true) // Blue Color -  information is not available is too Cold
			redButtonColor(index);
	}

	// manipulate the button color for IMS5B according to different state of the machine
	private void CheckIMS5BMachinestatus()
	{
		index = 6;
		if (IMS5BState1 == true) // Green Color - information is coming is ok
			greenButtonColor(index);// (Buttons[0]);
		if (IMS5BState2 == true) // Red Color - information is waiting is too Hot
			orangeButtonColor(index);
		if (IMS5BState3 == true) // Blue Color -  information is not available is too Cold
			redButtonColor(index);
	}

	// manipulate the button color for IMS7according to different state of the machine
	private void CheckIMS7Machinestatus()
	{
		index = 7;
		if (IMS7State1 == true) // Green Color - information is coming is ok
			greenButtonColor(index);// (Buttons[0]);
		if (IMS7State2 == true) // Red Color - information is waiting is too Hot
			orangeButtonColor(index);
		if (IMS7State3 == true) // Blue Color -  information is not available is too Cold
			redButtonColor(index);
	}


	//Here clear the color function for the three state
	private void greenButtonColor(int i)
	{
		//Debug.Log ("Green");
		Color greenColor = new Color(0.00f, 0.94f, 0.12f, 1.0f);
		Button b = Buttons[i].GetComponent<Button>();
		ColorBlock cb = b.colors;
		cb.normalColor = greenColor;
		b.colors = cb;
		//EffectColor.GetComponent<LineRenderer> ().material.SetColor ("_TintColor",greenColor);
	}
	private void orangeButtonColor(int i)
	{
		//Debug.Log ("Orange"); // yellow
		Color yellowColor = new Color(1.0f, 0.48f, 0.16f, 1.0f);
		Button b = Buttons[i].GetComponent<Button>();
		ColorBlock cb = b.colors;
		cb.normalColor = yellowColor;
		b.colors = cb;
	}

	private void redButtonColor(int i)
	{
		//Debug.Log ("Red");
		Color redColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
		Button b = Buttons[i].GetComponent<Button>();
		ColorBlock cb = b.colors;
		cb.normalColor = redColor;
		b.colors = cb;
	}

}
/*
void SelectionUI()
{

}


public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
{
	if (newStatus == TrackableBehaviour.Status.DETECTED ||
		newStatus == TrackableBehaviour.Status.TRACKED ||
		newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
	{
		targetFound = true; //when target is found
	}
	else
	{
		targetFound = false; //when target is lost
	}
}

		*/




