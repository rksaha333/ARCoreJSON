//default display not played
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnableDisplay : 
{

	public GameObject DisableB4;


	void Start()
	{
		DisableB4.gameObject.SetActive(false);

	}
}



//button control
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelscript : MonoBehaviour {

	public GameObject DisplayCanvas;
	int counter;

	public void showhidepanel()
	{
		counter++;
		if (counter % 2 == 1)
		{
			DisplayCanvas.gameObject.SetActive(false);

		}
		else
		{
			DisplayCanvas.gameObject.SetActive(true);
		}
			

	}


}



//panel button to enter the sceen
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadByIndex(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
	}
}

//Make canvas as bilbord#
//Billbord
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Billboard : MonoBehaviour {



	public Transform MyCameraTransform;
	private Transform MyTransform;
	public bool alignNotLook = true;

	// Use this for initialization
	void Start()
	{
		MyTransform = this.transform;
		MyCameraTransform = Camera.main.transform;
	}

	// Update is called once per frame
	void LateUpdate()
	{
		if (alignNotLook)
			MyTransform.forward = MyCameraTransform.forward;
		else
			MyTransform.LookAt(MyCameraTransform, Vector3.up);
     }
}


//
// Smooth towards the target

using UnityEngine;
using System.Collections;

public class CameraSmooth : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, 5, -10));

        // Smoothly move the camera towards that target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}

//Toggle buton to change the color of part of object


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorchange : MonoBehaviour {

	//declear the variable
	public GameObject part;

	public int counter=0;


	  public void ChangeColorObject(Material Mat) {
		 counter++;
		if (counter % 2 == 1)
		{
			
				  part.GetComponent<Renderer>().material.color =Color.gray;
		}
		else
		{
				part.GetComponent<Renderer>().material = Mat;

		}
	}
}





// change the color of the component by trigger the button
// This code will not change with click button again 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorchange : MonoBehaviour {

	//declear the variable
	public GameObject part;
	public void ChangeColorObject(Material Mat)
	{
		part.GetComponent<Renderer>().material = Mat;

	}
}



