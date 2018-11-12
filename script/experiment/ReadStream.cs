using UnityEngine;
using System.Collections.Generic;
using System.Net;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;
using GoogleARCore;
using UnityEngine.Networking;


public class ReadStream : MonoBehaviour
{
	public string LocalServer = "http://192.168.2.177/api/plant/lucasnuelle/";
	WebStreamReader request = null;

	DataClassIMS3MachineState  parseDataIMS3MachineState = new DataClassIMS3MachineState();
	DataClassIMS3AMachineState parseDataIMS3AMachineState = new DataClassIMS3AMachineState();
	DataClassIMS3BMachineState parseDataIMS3BMachineState = new DataClassIMS3BMachineState();
	DataClassIMS4AMachineState parseDataIMS4AMachineState = new DataClassIMS4AMachineState();
	DataClassIMS4BMachineState parseDataIMS4BMachineState = new DataClassIMS4BMachineState();
	DataClassIMS5AMachineState parseDataIMS5AMachineState = new DataClassIMS5AMachineState();
	DataClassIMS5BMachineState parseDataIMS5BMachineState = new DataClassIMS5BMachineState();
	DataClassIMS7MachineState  parseDataIMS7MachineState = new DataClassIMS7MachineState();

	bool IMS3MachineStateTrue  = false;
	bool IMS3AMachineStateTrue = false;
	bool IMS3BMachineStateTrue = false;
	bool IMS4AMachineStateTrue = false;
	bool IMS4BMachineStateTrue = false;
	bool IMS5AMachineStateTrue = false;
	bool IMS5BMachineStateTrue = false;
	bool IMS7MachineStateTrue  = false;

	

	public class DataClassIMS3MachineState
	{
		public string state_name { get; set; }
		//public string id { get; set; }
	}

	public class DataClassIMS3AMachineState
	{
		public string state_name { get; set; }
		//public string id { get; set; }
	}

	public class DataClassIMS3BMachineState
	{
		public string state_name { get; set; }
		//public string id { get; set; }
	}

	public class DataClassIMS4AMachineState
	{
		public string state_name { get; set; }
		//public string id { get; set; }
	}

	public class DataClassIMS4BMachineState
	{
		public string state_name { get; set; }
		//public string id { get; set; }
	}
	public class DataClassIMS5AMachineState
	{
		public string state_name { get; set; }
		//public string id { get; set; }
	}
	public class DataClassIMS5BMachineState
	{
		public string state_name { get; set; }
		//public string id { get; set; }
	}

	public class DataClassIMS7MachineState
	{
		public string state_name { get; set; }
		//public string id { get; set; }
	}
	void Start()
	{
		//parseDataHumidity = new DataClass ();
		StartCoroutine( WRequest() );
	}

	void Update()
	{

	}

	IEnumerator WRequest()
	{
		request = new WebStreamReader();
		request.Start(LocalServer); //https://www.ourtechart.com//wp-content/uploads/2016/04/jsonAllData.txt");
		string stream = "";
		while (true)
		{
			string block = request.GetNextBlock();
			if (!string.IsNullOrEmpty(block))
			{
				stream += block;
				//Debug.Log ("Stream1: " + stream);
				string[] data = stream.Split(new string[]{"\n\n"}, System.StringSplitOptions.None);
				//Debug.Log ("Data length: " + data.Length);
				stream = data[data.Length - 1];

				for (int i = 0; i < data.Length - 1; i++)
				{
					if (!string.IsNullOrEmpty(data[i]))
					{
							//Debug.Log ("Data: " + data [i]); // print all block of data (event + data of the segments)
						if (data[i].Contains("segments"))
						{
							IMS3MachineStateTrue = true;
							string output = data[i].Substring(data[i].IndexOf("{"));
							parseDataIMS3MachineState = JsonUtility.FromJson<DataClassIMS3MachineState>(output);
							//Debug.Log ("Data of IMS3 Machine State: " + parseDataIMS3MachineState.data);
							//gameObject.GetComponent<IotDrive>().IMS3MachineState.text = parseDataIMS3MachineState.data.ToString ();
							//gameObject.GetComponent<IotDrive> ().IMS3valtext = parseDataIMS3MachineState.data;
						}

						if (data[i].Contains("{\'identifier\':'IMS3A'}"))
						{
							IMS3AMachineStateTrue = true;
							string output =data[i].Substring(data[i].IndexOf("state_name"));
							parseDataIMS3AMachineState = JsonUtility.FromJson<DataClassIMS3AMachineState>(output);

							//Debug.Log ("Data of Temperature sensor: " + parseData.data);
							//gameObject.GetComponent<IotDrive>().IMS3valtext.text = parseDataIMS3AMachineState.data.ToString ();
							//gameObject.GetComponent<IoTDrive> ().microTemperatureVal = parseDataTemperature.data;
						}
						if (data[i].Contains("{\'identifier\':'IMS3B'}"))
						{
							IMS3BMachineStateTrue = true;
							string output = data[i].Substring(data[i].IndexOf("state_name"));
							parseDataIMS3BMachineState = JsonUtility.FromJson<DataClassIMS3BMachineState>(output);
							//Debug.Log ("Data of PIR sensor: " + parseData.data);
							//text.text = parseData.data.ToString ();
							//gameObject.GetComponent<IoT> ().motionDetectedBool = Convert.ToBoolean(parseDataMotion.data);
						}
						if (data[i].Contains("{\'identifier\':'IMS4A'}"))
						{
							IMS4AMachineStateTrue = true;
							string output = data[i].Substring(data[i].IndexOf("state_name"));
							parseDataIMS4AMachineState = JsonUtility.FromJson<DataClassIMS4AMachineState>(output);
							//Debug.Log ("Data of PIR ultraviolet: " + parseData.data);
							//text.text = parseData.data.ToString ();
							//gameObject.GetComponent<IoT> ().microUltravioletVal = parseDataUltraviolet.data;
						}
						if (data[i].Contains("{\'identifier\':'IMS4B'}"))
						{
							IMS4BMachineStateTrue = true;
							string output = data[i].Substring(data[i].IndexOf("{"));
							parseDataIMS4BMachineState = JsonUtility.FromJson<DataClassIMS4BMachineState>(output);
							//Debug.Log ("Data of Humidity: " + parseData.data);
							//text.text = parseData.data.ToString ();
							//gameObject.GetComponent<IoT> ().microHumidityVal = parseDataHumidity.data;
						}
						if (data[i].Contains("{\'identifier\':'IMS5A'}"))
						{
							IMS5AMachineStateTrue = true;
							string output = data[i].Substring(data[i].IndexOf("{"));
							parseDataIMS5AMachineState = JsonUtility.FromJson<DataClassIMS5AMachineState>(output);
							//Debug.Log ("Data of PIR ultraviolet: " + parseData.data);
							//text.text = parseData.data.ToString ();
							//gameObject.GetComponent<IoT> ().microUltravioletVal = parseDataUltraviolet.data;
						}
						if (data[i].Contains("{\'identifier\':'IMS5B'}"))
						{
							IMS5BMachineStateTrue = true;
							string output = data[i].Substring(data[i].IndexOf("state_name"));
							parseDataIMS5BMachineState = JsonUtility.FromJson<DataClassIMS5BMachineState>(output);
							//Debug.Log ("Data of PIR ultraviolet: " + parseData.data);
							//text.text = parseData.data.ToString ();
							//gameObject.GetComponent<IoT> ().microUltravioletVal = parseDataUltraviolet.data;
						}
						if (data[i].Contains("{\'identifier\':'IMS7'}"))
						{
							IMS7MachineStateTrue = true;
							string output = data[i].Substring(data[i].IndexOf("state_name"));
							parseDataIMS7MachineState = JsonUtility.FromJson<DataClassIMS7MachineState>(output);
							//Debug.Log ("Data of PIR ultraviolet: " + parseData.data);
							//text.text = parseData.data.ToString ();
							//gameObject.GetComponent<IoT> ().microUltravioletVal = parseDataUltraviolet.data;
						}
						//Debug.Log ("TEst: " + humidityTrue + temperatureTrue + lightTrue + ultravioletTrue);
						if (IMS3MachineStateTrue && IMS3AMachineStateTrue && IMS3BMachineStateTrue && IMS4AMachineStateTrue
							 && IMS4BMachineStateTrue && IMS5AMachineStateTrue && IMS5BMachineStateTrue && IMS7MachineStateTrue)
						{
							//Debug.Log ("PRINT ALLLLLLLLLLLLLL");
							gameObject.GetComponent<IotDrive>().IMS3valtext =  parseDataIMS3MachineState.state_name.ToString();
							gameObject.GetComponent<IotDrive>().IMS3Avaltext = parseDataIMS3AMachineState.state_name.ToString();
							gameObject.GetComponent<IotDrive>().IMS3Bvaltext = parseDataIMS3BMachineState.state_name.ToString();
							gameObject.GetComponent<IotDrive>().IMS4Avaltext = parseDataIMS4AMachineState.state_name.ToString();
							gameObject.GetComponent<IotDrive>().IMS4Bvaltext = parseDataIMS4BMachineState.state_name.ToString();
							gameObject.GetComponent<IotDrive>().IMS5Avaltext = parseDataIMS5AMachineState.state_name.ToString();
							gameObject.GetComponent<IotDrive>().IMS5Bvaltext = parseDataIMS5BMachineState.state_name.ToString();
							gameObject.GetComponent<IotDrive>().IMS7valtext =  parseDataIMS7MachineState.state_name.ToString();
							IMS3MachineStateTrue = false;
							IMS3AMachineStateTrue = false;
							IMS3BMachineStateTrue = false;
							IMS4AMachineStateTrue = false;
							IMS4BMachineStateTrue = false;
							IMS5AMachineStateTrue = false;
							IMS5BMachineStateTrue = false;
							IMS7MachineStateTrue = false;

						}
					}
				}

			}
			yield return new WaitForSeconds(1);
		}
	}

	

	void OnApplicationQuit()
	{
		if (request != null)
			request.Dispose();
	}

	void OnDataUpdate(decimal aAmount)
	{
		Debug.Log("Received new amount: " + aAmount);
		// Do whatever you want with the value
	}

	
}