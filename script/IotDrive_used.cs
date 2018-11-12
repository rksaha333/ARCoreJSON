
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
	public Text IMS3MachineState;
	public string IMS3valtext;
	public Text IMS7MachineState;
	public string IMS7valtext;
	public Text IMS5BMachineState;
	public string IMS5Bvaltext;
	public Text IMS5AMachineState;
	public string IMS5Avaltext;

	//Here the back canvas station information

	public Text IMS4AMachineState;
	public string IMS4Avaltext;
	public Text IMS4BMachineState;
	public string IMS4Bvaltext;
	public Text IMS3BMachineState;
	public string IMS3Bvaltext;
	public Text IMS3AMachineState;
	public string IMS3Avaltext;
	

	//public Text MotionText;
	//public bool motionDetectedBool = false;

	//public Text currentMeasurement;

	//IMS3MachineState

	bool IMS3FirstState = true;//this state means active
	bool IMS3SecondState = true;//this state means the waiting
	bool IMS3ThirdState = true;//this state is not error/not responding

	bool IMS3AFirstState = true;//this state means active
	bool IMS3ASecondState = true;//this state means the waiting
	bool IMS3AThirdState = true;//this state is not error/not responding

	bool IMS3BFirstState = true;//this state means active
	bool IMS3BSecondState = true;//this state means the waiting
	bool IMS3BThirdState = true;//this state is not error/not responding

	bool IMS4AFirstState = true;//this state means active
	bool IMS4ASecondState = true;//this state means the waiting
	bool IMS4AThirdState = true;//this state is not error/not responding

	bool IMS4BFirstState = true;//this state means active
	bool IMS4BSecondState = true;//this state means the waiting
	bool IMS4BThirdState = true;//this state is not error/not responding

	bool IMS5AFirstState = true;//this state means active
	bool IMS5ASecondState = true;//this state means the waiting
	bool IMS5AThirdState = true;//this state is not error/not responding

	bool IMS5BFirstState = true;//this state means active
	bool IMS5BSecondState = true;//this state means the waiting
	bool IMS5BThirdState = true;//this state is not error/not responding

	bool IMS7FirstState = true;//this state means active
	bool IMS7SecondState = true;//this state means the waiting
	bool IMS7ThirdState = true;//this state is not error/not responding


	//Here is indicate the number of button on the canvas that is linked with the infotext and val text
	int index;
	public GameObject[] Buttons = new GameObject[8];

	// initializing the machine state info as not to displayed
	// this part will prevent to display at the beginning



	bool hit;
	bool showIMS3Machinestate = false;
	bool showIMS3AMachinestate = false;
	bool showIMS3BMachinestate = false;
	bool showIMS4AMachinestate = false;
	bool showIMS4BMachinestate = false;
	bool showIMS5AMachinestate = false;
	bool showIMS5BMachinestate = false;
	bool showIMS7Machinestate = false;

	void Start()
	{


	}

	void Update()
	{

		//Here the value of the text field assign the value of the value field in a single button
		//Front canvas recognition
		//IMS3
		IMS3MachineState.text = IMS3valtext.ToString();
		CheckIMS3Machinestatus();
		//IMS7
		IMS7MachineState.text = IMS7valtext.ToString();
		CheckIMS7Machinestatus();
		//IMS5B
		IMS5BMachineState.text = IMS5Bvaltext.ToString();
		CheckIMS5BMachinestatus();
		//IMS5A
		IMS5AMachineState.text = IMS5Avaltext.ToString();
		CheckIMS5AMachinestatus();

		//Back canvas recognition
		//IMS3A
		IMS3AMachineState.text = IMS3Avaltext.ToString();
		CheckIMS3AMachinestatus();
		//IMS3B
		IMS3BMachineState.text = IMS3Bvaltext.ToString();
		CheckIMS3BMachinestatus();
		//IMS4A
		IMS4AMachineState.text = IMS4Avaltext.ToString();
		CheckIMS4AMachinestatus();
		//IMS4B
		IMS4BMachineState.text = IMS4Bvaltext.ToString();
		CheckIMS4BMachinestatus();


		// here get the particular machine state information
		getIMS3MachinestateInfo();
		if (showIMS3Machinestate)
		{
			showIMS3MachinestateInfo();
		}

		getIMS7MachinestateInfo();
		if (showIMS7Machinestate)
		{
			showIMS7MachinestateInfo();
		}

		getIMS5BMachinestateInfo();
		if (showIMS5BMachinestate)
		{
			showIMS5BMachinestateInfo();
		}

		getIMS5AMachinestateInfo();
		if (showIMS5AMachinestate)
		{
			showIMS5AMachinestateInfo();
		}

		getIMS3AMachinestateInfo();
		if (showIMS3AMachinestate)
		{
			showIMS3AMachinestateInfo();
		}

		getIMS3BMachinestateInfo();
		if (showIMS3BMachinestate)
		{
			showIMS3BMachinestateInfo();
		}

		getIMS4AMachinestateInfo();
		if (showIMS4AMachinestate)
		{
			showIMS4AMachinestateInfo();
		}

		getIMS4BMachinestateInfo();
		if (showIMS4BMachinestate)
		{
			showIMS4BMachinestateInfo();
		}
	}
	//IMS3 get tempurature state info

	public void getIMS3MachinestateInfo()
	{
		if (IMS3FirstState)
		{
			IMS3valtext = IMS3valtext.ToString();

		}
		else
			IMS3FirstState = false;



		if (IMS3SecondState)
		{
			IMS3valtext = IMS3valtext.ToString();

		}
		else
			IMS3SecondState = false;

		if (IMS3ThirdState)
		{

			IMS3valtext = IMS3valtext.ToString();
		}
		else
			return;


	}

	public void showIMS3MachinestateInfo()
	{
		IMS3valtext = IMS3valtext.ToString();
		showIMS3Machinestate = true;
	}

	//IMS7 state condition

	public void getIMS7MachinestateInfo()
	{

		if (IMS7FirstState)
		{
			IMS7valtext = IMS7valtext.ToString();

		}
		else
			IMS7FirstState = false;



		if (IMS7SecondState)
		{
			IMS7valtext = IMS7valtext.ToString();

		}
		else
			IMS7SecondState = false;

		if (IMS7ThirdState)
		{

			IMS7valtext = IMS7valtext.ToString();
		}
		else
			return;

	}

	public void showIMS7MachinestateInfo()
	{

		IMS7valtext = IMS7valtext.ToString();
		showIMS7Machinestate = true;
	}
	//IMS5B state condition

	public void getIMS5BMachinestateInfo()
	{

		if (IMS5BFirstState)
		{
			IMS5Bvaltext = IMS5Bvaltext.ToString();

		}
		else
			IMS5BFirstState = false;



		if (IMS5BSecondState)
		{
			IMS5Bvaltext = IMS5Bvaltext.ToString();

		}
		else
			IMS5BSecondState = false;

		if (IMS5BThirdState)
		{

			IMS5Bvaltext = IMS5Bvaltext.ToString();
		}
		else
			return;

	}
	public void showIMS5BMachinestateInfo()
	{
		IMS5Bvaltext = IMS5Bvaltext.ToString();
		showIMS5BMachinestate = true;
	}

	//IMS5A state condition

	public void getIMS5AMachinestateInfo()
	{

		if (IMS5AFirstState)
		{
			IMS5Avaltext = IMS5Avaltext.ToString();

		}
		else
			IMS5AFirstState = false;



		if (IMS5ASecondState)
		{
			IMS5Avaltext = IMS5Avaltext.ToString();

		}
		else
			IMS5ASecondState = false;

		if (IMS5AThirdState)
		{

			IMS5Avaltext = IMS5Avaltext.ToString();
		}
		else
			return;

	}
	public void showIMS5AMachinestateInfo()
	{
		IMS5Avaltext = IMS5Avaltext.ToString();
		showIMS5AMachinestate = true;
	}

	//IMS3A state condition

	public void getIMS3AMachinestateInfo()
	{

		if (IMS3AFirstState)
		{
			IMS3Avaltext = IMS3Avaltext.ToString();

		}
		else
			IMS3AFirstState = false;



		if (IMS3ASecondState)
		{
			IMS3Avaltext = IMS3Avaltext.ToString();

		}
		else
			IMS3ASecondState = false;

		if (IMS3AThirdState)
		{

			IMS3Avaltext = IMS3Avaltext.ToString();
		}
		else
			return;

	}
	public void showIMS3AMachinestateInfo()
	{
		IMS3Avaltext = IMS3Avaltext.ToString();
		showIMS3AMachinestate = true;
	}

	//IMS3B state condition execution

	public void getIMS3BMachinestateInfo()
	{

		if (IMS3BFirstState)
		{
			IMS3Bvaltext = IMS3Bvaltext.ToString();

		}
		else
			IMS3BFirstState = false;



		if (IMS3BSecondState)
		{
			IMS3Bvaltext = IMS3Bvaltext.ToString();

		}
		else
			IMS3BSecondState = false;

		if (IMS3BThirdState)
		{

			IMS3Bvaltext = IMS3Bvaltext.ToString();
		}
		else
			return;

	}
	public void showIMS3BMachinestateInfo()
	{
		IMS3Bvaltext = IMS3Bvaltext.ToString();
		showIMS3BMachinestate = true;
	}
	//IMS4A state condition

	public void getIMS4AMachinestateInfo()
	{

		if (IMS4AFirstState)
		{
			IMS4Avaltext = IMS4Avaltext.ToString();

		}
		else
			IMS4AFirstState = false;



		if (IMS4ASecondState)
		{
			IMS4Avaltext = IMS4Avaltext.ToString();

		}
		else
			IMS4ASecondState = false;

		if (IMS4AThirdState)
		{

			IMS4Avaltext = IMS4Avaltext.ToString();
		}
		else
			return;

	}
	public void showIMS4AMachinestateInfo()
	{
		IMS4Avaltext = IMS4Avaltext.ToString();
		showIMS4AMachinestate = true;
	}
	//IMS4B state condition


	public void getIMS4BMachinestateInfo()
	{

		if (IMS4BFirstState)
		{
			IMS4Bvaltext = IMS4Bvaltext.ToString();

		}
		else
			IMS4BFirstState = false;



		if (IMS4BSecondState)
		{
			IMS4Bvaltext = IMS4Bvaltext.ToString();

		}
		else
			IMS4BSecondState = false;

		if (IMS4BThirdState)
		{

			IMS4Bvaltext = IMS4Bvaltext.ToString();
		}
		else
			return;

	}
	public void showIMS4BMachinestateInfo()
	{
		IMS4Bvaltext = IMS4Bvaltext.ToString();
		showIMS4BMachinestate = true;
	}

	// reset the boll value

	public void resetBool()
	{
		/*LowerVariance.text = "n/a";
		UpperVariance.text = "n/a";
		LowerTime.text = "n/a";
		UpperTime.text = "n/a";
	    showI = false;
		*/
		showIMS3Machinestate = false;
		showIMS3AMachinestate = false;
		showIMS3BMachinestate = false;
		showIMS4AMachinestate = false;
		showIMS4BMachinestate = false;
		showIMS5AMachinestate = false;
		showIMS5BMachinestate = false;
		showIMS7Machinestate = false;
	}
	// manipulate the button color for IMS3 according to different state of the machine
	private void CheckIMS3Machinestatus()
	{
		index = 0;
		if (IMS3FirstState == true) // Green Color - information is coming is ok
			greenButtonColor(index);// (Buttons[0]);
		if (IMS3SecondState == true) // Red Color - information is waiting is too Hot
			orangeButtonColor(index);
		if (IMS3ThirdState == true) // Blue Color -  information is not available is too Cold
			redButtonColor(index);
	}
	// manipulate the button color for IMS3A according to different state of the machine
	private void CheckIMS3AMachinestatus()
	{
		index = 1;
		if (IMS3AFirstState == true) // Green Color -
			greenButtonColor(index);// (Buttons[0]);
		if (IMS3ASecondState == true) // Red Color - 
			orangeButtonColor(index);
		if (IMS3AThirdState == true) // Blue Color - 
			redButtonColor(index);
	}

	// manipulate the button color for IMS3B according to different state of the machine
	private void CheckIMS3BMachinestatus()
	{
		index = 2;
		if (IMS3BFirstState == true) // Green Color - information is coming is ok
			greenButtonColor(index);// (Buttons[0]);
		if (IMS3BSecondState == true) // Red Color - information is waiting is too Hot
			orangeButtonColor(index);
		if (IMS3BThirdState == true) // Blue Color -  information is not available is too Cold
			redButtonColor(index);
	}

	// manipulate the button color for IMS4A according to different state of the machine
	private void CheckIMS4AMachinestatus()
	{
		index = 3;
		if (IMS4AFirstState == true) // Green Color - information is coming is ok
			greenButtonColor(index);// (Buttons[0]);
		if (IMS4ASecondState == true) // Red Color - information is waiting is too Hot
			orangeButtonColor(index);
		if (IMS4AThirdState == true) // Blue Color -  information is not available is too Cold
			redButtonColor(index);
	}

	// manipulate the button color for IMS4B according to different state of the machine
	private void CheckIMS4BMachinestatus()
	{
		index = 4;
		if (IMS4BFirstState == true) // Green Color - information is coming is ok
			greenButtonColor(index);// (Buttons[0]);
		if (IMS4BSecondState == true) // Red Color - information is waiting is too Hot
			orangeButtonColor(index);
		if (IMS4BThirdState == true) // Blue Color -  information is not available is too Cold
			redButtonColor(index);
	}

	// manipulate the button color for IMS5A according to different state of the machine
	private void CheckIMS5AMachinestatus()
	{
		index = 5;
		if (IMS5AFirstState == true) // Green Color - information is coming is ok
			greenButtonColor(index);// (Buttons[0]);
		if (IMS5ASecondState == true) // Red Color - information is waiting is too Hot
			orangeButtonColor(index);
		if (IMS5AThirdState == true) // Blue Color -  information is not available is too Cold
			redButtonColor(index);
	}

	// manipulate the button color for IMS5B according to different state of the machine
	private void CheckIMS5BMachinestatus()
	{
		index = 6;
		if (IMS5BFirstState == true) // Green Color - information is coming is ok
			greenButtonColor(index);// (Buttons[0]);
		if (IMS5BSecondState == true) // Red Color - information is waiting is too Hot
			orangeButtonColor(index);
		if (IMS5BThirdState == true) // Blue Color -  information is not available is too Cold
			redButtonColor(index);
	}

	// manipulate the button color for IMS7according to different state of the machine
	private void CheckIMS7Machinestatus()
	{
		index = 7;
		if (IMS7FirstState == true) // Green Color - information is coming is ok
			greenButtonColor(index);// (Buttons[0]);
		if (IMS7SecondState == true) // Red Color - information is waiting is too Hot
			orangeButtonColor(index);
		if (IMS7ThirdState == true) // Blue Color -  information is not available is too Cold
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




			