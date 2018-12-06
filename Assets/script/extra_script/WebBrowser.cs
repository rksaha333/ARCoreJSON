using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebBrowser : MonoBehaviour {

	public GameObject Mycan;

	//function declear
	public void OpenIp()

	{

		Application.OpenURL("http://192.168.2.161/");
		Debug.Log("Its working");
	}

	

	}
