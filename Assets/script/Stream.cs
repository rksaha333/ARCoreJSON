using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using DefaultNamespace;

public class Stream : MonoBehaviour {


	SegmentCollection parseData = new SegmentCollection();

	/*
	bool IMS3MachineState = false;
	 bool IMS3AMachineState = false;
	 bool IMS3BMachineState = false;
	 bool IMS4AMachineState = false;
	 bool IMS4BMachineState = false;
	 bool IMS5AMachineState = false;
	 bool IMS5BMachineState = false;
	 bool IMS7MachineState = false;		
	 */




	bool continueRequest = false;
	void Start()
	{
		//		StartCoroutine(makeRequest());
		StartCoroutine(getOrders());
	}
	string getUTCTime()
	{
		System.Int32 unixTimestamp = (System.Int32)(System.DateTime.UtcNow.Subtract(new System.DateTime(1970, 1, 1))).TotalSeconds;
		return unixTimestamp.ToString();
	}
	IEnumerator getOrders()
	{
		if (continueRequest)
			yield break;
		continueRequest = true;
		float RequestFrequencyInSecond = 5f;  //update after every 5 second
		WaitForSeconds WaitTime = new WaitForSeconds(RequestFrequencyInSecond);
		while(continueRequest)
		{
			var _request = UnityWebRequest.Get("http://192.168.2.177/api/plant/lucasnuelle/" + "?t=" + getUTCTime());
			//	Disable cache on the client side
			_request.SetRequestHeader("Cache-Control", "max-age=0, no-cache, no-store");
			_request.SetRequestHeader("Pragma", "no-cache");
			yield return _request.SendWebRequest();

			if (_request.isNetworkError)
			{
				Debug.Log("Error: " + _request.error);
			}
			else
			{
				var result = _request.downloadHandler.text;
				Debug.Log("Received " + result);
				parseData = JsonUtility.FromJson<SegmentCollection>(result);
				Debug.Log("size: " + parseData.segments.Length);  //get the length of the all segments	:8
				for (int i = 0; i < parseData.segments.Length; i++)
				{
					if (parseData.segments[i].identifier.Contains("IMS1"))
					{

						string IMS3StateOutput = parseData.segments[i].state_name;
						string IMS3IdentifierOutput = parseData.segments[i].identifier;
						Debug.Log("State Name: " + IMS3IdentifierOutput);  //display the identifier
						Debug.Log("Machine state: " + IMS3StateOutput);//display the state name
						gameObject.GetComponent<demoIoT>().IMS3Valtext = IMS3StateOutput;
						gameObject.GetComponent<demoIoT>().IMS3StationValtext = IMS3IdentifierOutput;


					}
					if (parseData.segments[i].identifier.Contains("IMS3A"))
					{


						string IMS3AStateOutput = parseData.segments[i].state_name;
						string IMS3AIdentifierOutput = parseData.segments[i].identifier;

						Debug.Log("State Name: " + IMS3AIdentifierOutput);  //display the identifier
						Debug.Log("Machine state: " + IMS3AStateOutput);
						gameObject.GetComponent<demoIoT>().IMS3AValtext = IMS3AStateOutput;
						gameObject.GetComponent<demoIoT>().IMS3AStationValtext = IMS3AIdentifierOutput;


					}
					if (parseData.segments[i].identifier.Contains("IMS3B"))
					{

						string IMS3BStateOutput = parseData.segments[i].state_name;
						string IMS3BIdentifierOutput = parseData.segments[i].identifier;

						Debug.Log("State Name: " + IMS3BIdentifierOutput);  //display the identifier
						Debug.Log("Machine state: " + IMS3BStateOutput);
						gameObject.GetComponent<demoIoT>().IMS3BValtext = IMS3BStateOutput;
						gameObject.GetComponent<demoIoT>().IMS3BStationValtext = IMS3BIdentifierOutput;


					}
					if (parseData.segments[i].identifier.Contains("IMS4A"))
					{

						string IMS4AStateOutput = parseData.segments[i].state_name;
						string IMS4AIdentifierOutput = parseData.segments[i].identifier;

						Debug.Log("State Name: " + IMS4AIdentifierOutput);  //display the identifier
						Debug.Log("Machine state: " + IMS4AStateOutput);
						gameObject.GetComponent<demoIoT>().IMS4AValtext = IMS4AStateOutput;
						gameObject.GetComponent<demoIoT>().IMS4AStationValtext = IMS4AIdentifierOutput;



					}
					if (parseData.segments[i].identifier.Contains("IMS4B"))
					{

						string IMS4BStateOutput = parseData.segments[i].state_name;
						string IMS4BIdentifierOutput = parseData.segments[i].identifier;

						Debug.Log("State Name: " + IMS4BIdentifierOutput);  //display the identifier
						Debug.Log("Machine state: " + IMS4BStateOutput);
						gameObject.GetComponent<demoIoT>().IMS4BValtext = IMS4BStateOutput;
						gameObject.GetComponent<demoIoT>().IMS4BStationValtext = IMS4BIdentifierOutput;


					}
					if (parseData.segments[i].identifier.Contains("IMS5A"))
					{
						string IMS5AStateOutput = parseData.segments[i].state_name;
						string IMS5AIdentifierOutput = parseData.segments[i].identifier;

						Debug.Log("State Name: " + IMS5AIdentifierOutput);  //display the identifier
						Debug.Log("Machine state: " + IMS5AStateOutput);
						gameObject.GetComponent<demoIoT>().IMS5AValtext = IMS5AStateOutput;
						gameObject.GetComponent<demoIoT>().IMS5AStationValtext = IMS5AIdentifierOutput;



					}
					if (parseData.segments[i].identifier.Contains("IMS5B"))
					{

						string IMS5BStateOutput = parseData.segments[i].state_name;
						string IMS5BIdentifierOutput = parseData.segments[i].identifier;

						Debug.Log("State Name: " + IMS5BIdentifierOutput);  //display the identifier
						Debug.Log("Machine state: " + IMS5BStateOutput);
						gameObject.GetComponent<demoIoT>().IMS5BValtext = IMS5BStateOutput;
						gameObject.GetComponent<demoIoT>().IMS5BStationValtext = IMS5BIdentifierOutput;


					}
					if (parseData.segments[i].identifier.Contains("IMS7"))
					{

						string IMS7StateOutput = parseData.segments[i].state_name;
						string IMS7IdentifierOutput = parseData.segments[i].identifier;

						Debug.Log("State Name: " + IMS7IdentifierOutput);  //display the identifier
						Debug.Log("Machine state: " + IMS7StateOutput);
						gameObject.GetComponent<demoIoT>().IMS7Valtext = IMS7StateOutput;
						gameObject.GetComponent<demoIoT>().IMS7StationValtext = IMS7IdentifierOutput;


					}

				}




			}

		}
		yield return WaitTime;//Wait for request FrequencyInsec time
		
	}
}
