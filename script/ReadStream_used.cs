using UnityEngine;
using System.Collections.Generic;
using System.Net;
using UnityEngine.UI;
using System.Collections;
using System;
using System.IO;
using GoogleARCore;


public class ReadStream : MonoBehaviour
{
	public string LocalServerURL = "http://192.168.2.177/api/plant/lucasnuelle/";
	WebStreamReader request = null;

	DataClassIMS3MachineState  parseDataIMS3MachineState = new DataClassIMS3MachineState();
	DataClassIMS3AMachineState parseDataIMS3AMachineState = new DataClassIMS3AMachineState();
	DataClassIMS3BMachineState parseDataIMS3BMachineState = new DataClassIMS3BMachineState();
	DataClassIMS4AMachineState parseDataIMS4AMachineState = new DataClassIMS4AMachineState();
	DataClassIMS4BMachineState parseDataIMS4BMachineState = new DataClassIMS4BMachineState();
	DataClassIMS5AMachineState parseDataIMS5AMachineState = new DataClassIMS5AMachineState();
	DataClassIMS5BMachineState parseDataIMS5BMachineState = new DataClassIMS5BMachineState();
	DataClassIMS7MachineState  parseDataIMS7MachineState = new DataClassIMS7MachineState();

	bool IMS3MachineStateTrue = false;
	bool IMS3AMachineStateTrue = false;
	bool IMS3BMachineStateTrue = false;
	bool IMS4AMachineStateTrue = false;
	bool IMS4BMachineStateTrue = false;
	bool IMS5AMachineStateTrue = false;
	bool IMS5BMachineStateTrue = false;
	bool IMS7MachineStateTrue = false;

	public class DataClass
	{
		public string data;
	}

	public class DataClassIMS3MachineState
	{
		public string data;
	}

	public class DataClassIMS3AMachineState
	{
		public string data;
	}

	public class DataClassIMS3BMachineState
	{
		public string data;
	}

	public class DataClassIMS4AMachineState
	{
		public string data;
	}

	public class DataClassIMS4BMachineState
	{
		public string data;
	}
	public class DataClassIMS5AMachineState
	{
		public string data;
	}
	public class DataClassIMS5BMachineState
	{
		public string data;
	}

	public class DataClassIMS7MachineState
	{
		public string data;
	}
	void Start()
	{
		//parseDataHumidity = new DataClass ();
		StartCoroutine(WRequest());
	}

	void Update()
	{

	}

	IEnumerator WRequest()
	{
		request = new WebStreamReader();
		request.Start(LocalServerURL); //https://www.ourtechart.com//wp-content/uploads/2016/04/jsonAllData.txt");
		string stream = "";
		while (true)
		{
			string block = request.GetNextBlock();
			if (!string.IsNullOrEmpty(block))
			{
				stream += block;
				//Debug.Log ("Stream1: " + stream);
				string[] data = stream.Split(new string[] { "\n\n" }, System.StringSplitOptions.None);
				//Debug.Log ("Data length: " + data.Length);
				stream = data[data.Length - 1];

				for (int i = 0; i < data.Length - 1; i++)
				{
					if (!string.IsNullOrEmpty(data[i]))
					{
						//	Debug.Log ("Data: " + data [i]); // print all block of data (event + data)
						if (data[i].Contains("IMS1"))
						{
							IMS3MachineStateTrue = true;
							string output = data[i].Substring(data[i].IndexOf("{"));
							parseDataIMS3MachineState = JsonUtility.FromJson<DataClassIMS3MachineState>(output);
							//Debug.Log ("Data of Photoresistor: " + parseData.data);
							//text.text = parseData.data.ToString ();
							//gameObject.GetComponent<IoT> ().microPhotoresistorVal = parseDataLight.data;
						}

						if (data[i].Contains("IMS3A"))
						{
							IMS3AMachineStateTrue = true;
							string output = data[i].Substring(data[i].IndexOf("{"));
							parseDataIMS3AMachineState = JsonUtility.FromJson<DataClassIMS3AMachineState>(output);
							//Debug.Log ("Data of Temperature sensor: " + parseData.data);
							//text.text = parseData.data.ToString ();
							//gameObject.GetComponent<IoT> ().microTemperatureVal = parseDataTemperature.data;
						}
						if (data[i].Contains("IMS3B"))
						{
							IMS3BMachineStateTrue = true;
							string output = data[i].Substring(data[i].IndexOf("{"));
							parseDataIMS3BMachineState = JsonUtility.FromJson<DataClassIMS3BMachineState>(output);
							//Debug.Log ("Data of PIR sensor: " + parseData.data);
							//text.text = parseData.data.ToString ();
							//gameObject.GetComponent<IoT> ().motionDetectedBool = Convert.ToBoolean(parseDataMotion.data);
						}
						if (data[i].Contains("IMS4A"))
						{
							IMS4AMachineStateTrue = true;
							string output = data[i].Substring(data[i].IndexOf("{"));
							parseDataIMS4AMachineState = JsonUtility.FromJson<DataClassIMS4AMachineState>(output);
							//Debug.Log ("Data of PIR ultraviolet: " + parseData.data);
							//text.text = parseData.data.ToString ();
							//gameObject.GetComponent<IoT> ().microUltravioletVal = parseDataUltraviolet.data;
						}
						if (data[i].Contains("IMS4B"))
						{
							IMS4BMachineStateTrue = true;
							string output = data[i].Substring(data[i].IndexOf("{"));
							parseDataIMS4BMachineState = JsonUtility.FromJson<DataClassIMS4BMachineState>(output);
							//Debug.Log ("Data of Humidity: " + parseData.data);
							//text.text = parseData.data.ToString ();
							//gameObject.GetComponent<IoT> ().microHumidityVal = parseDataHumidity.data;
						}
						if (data[i].Contains("IMS5A"))
						{
							IMS5AMachineStateTrue = true;
							string output = data[i].Substring(data[i].IndexOf("{"));
							parseDataIMS5AMachineState = JsonUtility.FromJson<DataClassIMS5AMachineState>(output);
							//Debug.Log ("Data of PIR ultraviolet: " + parseData.data);
							//text.text = parseData.data.ToString ();
							//gameObject.GetComponent<IoT> ().microUltravioletVal = parseDataUltraviolet.data;
						}
						if (data[i].Contains("IMS5B"))
						{
							IMS5BMachineStateTrue = true;
							string output = data[i].Substring(data[i].IndexOf("{"));
							parseDataIMS5BMachineState = JsonUtility.FromJson<DataClassIMS5BMachineState>(output);
							//Debug.Log ("Data of PIR ultraviolet: " + parseData.data);
							//text.text = parseData.data.ToString ();
							//gameObject.GetComponent<IoT> ().microUltravioletVal = parseDataUltraviolet.data;
						}
						if (data[i].Contains("IMS7"))
						{
							IMS7MachineStateTrue = true;
							string output = data[i].Substring(data[i].IndexOf("{"));
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
							gameObject.GetComponent<IotDrive>().IMS3valtext =  parseDataIMS3MachineState.data;
							gameObject.GetComponent<IotDrive>().IMS3Avaltext = parseDataIMS3AMachineState.data;
							gameObject.GetComponent<IotDrive>().IMS3Bvaltext = parseDataIMS3BMachineState.data;
							gameObject.GetComponent<IotDrive>().IMS4Avaltext = parseDataIMS4AMachineState.data;
							gameObject.GetComponent<IotDrive>().IMS4Bvaltext = parseDataIMS4BMachineState.data;
							gameObject.GetComponent<IotDrive>().IMS5Avaltext = parseDataIMS5AMachineState.data;
							gameObject.GetComponent<IotDrive>().IMS5Bvaltext = parseDataIMS5BMachineState.data;
							gameObject.GetComponent<IotDrive>().IMS7valtext =  parseDataIMS7MachineState.data;
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

	public class WebStreamReader : System.IDisposable
	{
		volatile bool running = false;
		string url = "http://192.168.2.177/api/plant/lucasnuelle/";
		System.Threading.Thread thread = null;
		Queue<string> buffer = new Queue<string>();
		object lockHandle = new object();

		~WebStreamReader()
		{
			Dispose();
		}

		public void Start(string aURL)
		{
			if (!running)
			{
				url = aURL;
				thread = new System.Threading.Thread(Run);
				thread.Start();
			}
		}
		private void Run()
		{
			running = true;
			ServicePointManager.ServerCertificateValidationCallback = (a, b, c, d) => { return true; };
			var request = System.Net.HttpWebRequest.Create(url);
			var response = request.GetResponse();
			var stream = response.GetResponseStream();
			byte[] data = new byte[2048];
			while (running)
			{
				int count = stream.Read(data, 0, 2048);
				if (count > 0)
				{
					lock (lockHandle)
					{
						string message = System.Text.UTF8Encoding.UTF8.GetString(data, 0, count);
						buffer.Enqueue(message);
					}
				}
			}
		}

		public string GetNextBlock()
		{
			string tmp = "";
			lock (lockHandle)
			{
				if (buffer.Count > 0)
				{
					tmp = buffer.Dequeue();
				}
			}
			return tmp;
		}

		public void Dispose()
		{
			running = false;
			thread.Abort();
		}
	}
}