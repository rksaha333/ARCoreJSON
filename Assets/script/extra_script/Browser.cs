using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Browser : MonoBehaviour
{


	public GameObject BrowserCanvas;
	// Use this for initialization
	void Start () {
		StartCoroutine(GetBrowser());
		
	}
	
	IEnumerator GetBrowser()
	{

		var _request = UnityWebRequest.Get("http://192.168.2.161/");
		yield return _request.SendWebRequest();
		if(_request.isNetworkError)
		{
			Debug.Log("Error: " + _request.error); 
		}

		else
		{
			AssetBundle bundel =DownloadHandlerAssetBundle.GetContent(_request);
			Debug.Log("Received " + bundel);
	
		}

	}


	
}
