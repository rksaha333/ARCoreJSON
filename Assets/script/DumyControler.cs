﻿namespace GoogleARCore.HelloAR
{
	using System.Collections.Generic;
	using GoogleARCore;
	using UnityEngine;
	using UnityEngine.Rendering;
	using GoogleARCore.Examples.Common;

#if UNITY_EDITOR
	// Set up touch input propagation while using Instant Preview in the editor.
	using Input = InstantPreviewInput;
#endif

	/// <summary>
	/// Controls the HelloAR example.
	/// </summary>
	public class DumyControler : MonoBehaviour
	{
		/// <summary>
		/// The first-person camera being used to render the passthrough camera image (i.e. AR background).
		/// </summary>
		public Camera FirstPersonCamera;

		/// <summary>
		/// A prefab for tracking and visualizing detected planes.
		/// </summary>
		public GameObject TrackedPlanePrefab;

		/// <summary>
		/// A model to place when a raycast from a user touch hits a plane.
		/// </summary>
		//public GameObject AndyAndroidPrefab;
		//public GameObject catObject;
		public GameObject MyObject;
		public Canvas MyCanvas;

		public int numberOfObjectsAllowed = 1;
		private int currentNumberOfObjects = 0;
		/// <summary>
		/// A gameobject parenting UI for displaying the "searching for planes" snackbar.
		/// </summary>
		public GameObject SearchingForPlaneUI;


		/// <summary>
		/// A list to hold new planes ARCore began tracking in the current frame. This object is used across
		/// the application to avoid per-frame allocations.
		/// </summary>
		private List<DetectedPlane> m_NewPlanes = new List<DetectedPlane>();

		/// <summary>
		/// A list to hold all planes ARCore is tracking in the current frame. This object is used across
		/// the application to avoid per-frame allocations.
		/// </summary>
		private List<DetectedPlane> m_AllPlanes = new List<DetectedPlane>();

		/// <summary>
		/// True if the app is in the process of quitting due to an ARCore connection error, otherwise false.
		/// </summary>
		private bool m_IsQuitting = false;
		private float zoomSpeed;

		public bool candisplay = true;

		/// <summary>
		/// The Unity Update() method.
		/// </summary>
		public void Update()
		{
			// Exit the app when the 'back' button is pressed.
			if (Input.GetKey(KeyCode.Escape))
			{
				Application.Quit();
			}

			_QuitOnConnectionErrors();

			// Check that motion tracking is tracking.
			if (Session.Status != SessionStatus.Tracking)
			{
				const int lostTrackingSleepTimeout = 15;
				Screen.sleepTimeout = lostTrackingSleepTimeout;
				if (!m_IsQuitting && Session.Status.IsValid())
				{
					SearchingForPlaneUI.SetActive(true);
				}

				return;
			}

			Screen.sleepTimeout = SleepTimeout.NeverSleep;

			//This variable only for check the object is placed or not
			//if placed then stoip the surface detection 
			//else continue the surface detection

			
			Session.GetTrackables<DetectedPlane>(m_NewPlanes, TrackableQueryFilter.New);
			for (int i = 0; i < m_NewPlanes.Count; i++)
			{
				// Instantiate a plane visualization prefab and set it to track the new plane. The transform is set to
				// the origin with an identity rotation since the mesh for our prefab is updated in Unity World
				// coordinates.
				GameObject planeObject = Instantiate(TrackedPlanePrefab, Vector3.zero, Quaternion.identity,
					transform);
				planeObject.GetComponent<DetectedPlaneVisualizer>().Initialize(m_NewPlanes[i]);
			}



			// Hide snackbar when currently tracking at least one plane.
			Session.GetTrackables<DetectedPlane>(m_AllPlanes);
			bool showSearchingUI = true;
			for (int i = 0; i < m_AllPlanes.Count; i++)
			{
				if (m_AllPlanes[i].TrackingState == TrackingState.Tracking)
				{
					showSearchingUI = false;
					//showDisplay = true;
					break;

				}
			}

			SearchingForPlaneUI.SetActive(showSearchingUI);

			
			//m_ObjectPrefeb.SetActive(showDisplay);


			// If the player has not touched the screen, we are done with this update.
			Touch touch;
			if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
			{
				return;
			}

			// Raycast against the location the player touched to search for planes.
			TrackableHit hit;
			TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
			TrackableHitFlags.FeaturePointWithSurfaceNormal;

			if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
			{

				if (currentNumberOfObjects < numberOfObjectsAllowed)
				{

					currentNumberOfObjects = currentNumberOfObjects + 1;

					var DisplayObject = Instantiate(MyObject, hit.Pose.position, hit.Pose.rotation);
					
					if(candisplay)
					{
						MyCanvas.gameObject.SetActive(candisplay);

					}

					var anchor = hit.Trackable.CreateAnchor(hit.Pose);

					// Andy should look at the camera but still be flush with the plane.
					if ((hit.Flags & TrackableHitFlags.PlaneWithinPolygon) != TrackableHitFlags.None)
					{
						// Get the camera position and match the y-component with the hit position.
						Vector3 cameraPositionSameY = FirstPersonCamera.transform.position;
						cameraPositionSameY.y = hit.Pose.position.y;

						// Have object look toward the camera respecting his "up" perspective, which may be from ceiling.
						DisplayObject.transform.LookAt(cameraPositionSameY, DisplayObject.transform.up);
					}

					DisplayObject.transform.parent = anchor.transform;
					

				}
					


			}

			
			  		  
		}

		/// <summary>
		/// Quit the application if there was a connection error for the ARCore session.
		/// </summary>
		private void _QuitOnConnectionErrors()
		{
			if (m_IsQuitting)
			{
				return;
			}

			// Quit if ARCore was unable to connect and give Unity some time for the toast to appear.
			if (Session.Status == SessionStatus.ErrorPermissionNotGranted)
			{
				_ShowAndroidToastMessage("Camera permission is needed to run this application.");
				m_IsQuitting = true;
				Invoke("_DoQuit", 0.5f);
			}
			else if (Session.Status.IsError())
			{
				_ShowAndroidToastMessage("ARCore encountered a problem connecting.  Please start the app again.");
				m_IsQuitting = true;
				Invoke("_DoQuit", 0.5f);
			}
		}

		/// <summary>
		/// Actually quit the application.
		/// </summary>
		private void _DoQuit()
		{
			Application.Quit();
		}

		/// <summary>
		/// Show an Android toast message.
		/// </summary>
		/// <param name="message">Message string to show in the toast.</param>
		private void _ShowAndroidToastMessage(string message)
		{
			AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

			if (unityActivity != null)
			{
				AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
				unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
				{
					AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity,
						message, 0);
					toastObject.Call("show");
				}));
			}
		}
	}
}


