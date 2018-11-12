using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;

public class Stream : MonoBehaviour {

	
	// Use this for initialization
	void Start ()
	{
//		StartCoroutine(makeRequest());
		StartCoroutine(getOrders());
	}
	
	IEnumerator makeRequest()
	{
		var _request = UnityWebRequest.Get("https://api.predic8.de/shop/orders/1432");
		yield return _request.SendWebRequest();

		if (_request.isNetworkError)
		{
			Debug.Log("Error: " + _request.error);
		}
		else
		{
			var result = _request.downloadHandler.text;
			Debug.Log("Received " + result);
			var order = JsonUtility.FromJson<Order>(result);
			
			
			Debug.Log("created: " + order.createdAt + " actionUrl: " + order.actions.purchase.url);
		}
	}
	
	IEnumerator getOrders()
	{
		var _request = UnityWebRequest.Get("https://api.predic8.de/shop/orders/");
		yield return _request.SendWebRequest();

		if (_request.isNetworkError)
		{
			Debug.Log("Error: " + _request.error);
		}
		else
		{
			var result = _request.downloadHandler.text;
			Debug.Log("Received " + result);
			var shop = JsonUtility.FromJson<Shop>(result);


			switch (shop.orders[0].state)
			{
					case State.created: Debug.Log("Created"); break;
					case State.ordered: Debug.Log("Ordered"); break;
					case State.delivered: Debug.Log("Delivered"); break;
			}
			
			Debug.Log("size: " + shop.orders.Length );
			Debug.Log("created: " + shop.orders[0].createdAt );
		}
	}
}
