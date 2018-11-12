
using GoogleARCore.Examples.Common;
using GoogleARCore.HelloAR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stop : MonoBehaviour {

	private Button btn;
	
	// Use this for initialization
	void Statr()
	{
		btn = GetComponent<Button>();
		btn.onClick.AddListener(StopTrack);

	}
	public void StopTrack()
	{
		gameObject.GetComponent<DumyControler>();
		// Make isSurfaceDetected to false to disable plane detection code
		//isSurfaceDetected = false;
		// Tag DetectedPlaneVisualizer prefab to Plane(or anything else)
		GameObject[] name = GameObject.FindGameObjectsWithTag("Plane");
		// In DetectedPlaneVisualizer we have multiple polygons so we need to loop and diable DetectedPlaneVisualizer script attatched to that prefab.
		for (int i = 0; i < name.Length; i++)
		{
			name[i].GetComponent<DetectedPlaneVisualizer>().enabled = false;
		}

	}


}
