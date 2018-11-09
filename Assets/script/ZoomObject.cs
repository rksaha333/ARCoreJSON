using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomObject : MonoBehaviour {

	public GameObject MyObject;
	
	void Zooming()
	{
		//widen by 0.1
		MyObject.transform.localScale += new Vector3(0.1F, 0, 0);
	}


}
