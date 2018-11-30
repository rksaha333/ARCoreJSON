//This is only for the read stream

//-----------------------------------------------------------------------
// <copyright file="HelloARController.cs" company="Google">
//
// Copyright 2017 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.HelloAR
{
	using System;
	using System.Collections.Generic;
	using GoogleARCore;
	using GoogleARCore.Examples.Common;
	using UnityEngine;

#if UNITY_EDITOR
	// Set up touch input propagation while using Instant Preview in the editor.
	using Input = InstantPreviewInput;
#endif

	/// <summary>
	/// Controls the HelloAR example.
	/// </summary>
	public class Controller : MonoBehaviour
    {
        /// <summary>
        /// The first-person camera being used to render the passthrough camera image (i.e. AR background).
        /// </summary>
        public Camera FirstPersonCamera;

		/// <summary>
		/// A prefab for tracking and visualizing detected planes.


		/// <summary>
		/// A model to place when a raycast from a user touch hits a plane.
		/// </summary>
		public GameObject[] ObPrefab = new GameObject[4];
		/// <summary>
		/// A model to place when a raycast from a user touch hits a feature point.
		/// </summary>
		//public GameObject AndyPointPrefab;


		public GameObject SearchingForPlaneUI; //This is the Searcing plane canvas
		public GameObject MyDisplay;   //This is the Visualize info display
		public GameObject NavigationPlaneUI;//This is navigation display

		//public bool TrackState = true;
		//public bool showSearchingUI; //Condition for the sercing canvas
		//public bool showNavigationUI;   //condition for the Navigation canvas



		/// <summary>
		/// The rotation in degrees need to apply to model when the Andy model is placed.
		/// </summary>
		private const float k_ModelRotation = 180.0f;

        /// <summary>
        /// A list to hold all planes ARCore is tracking in the current frame. This object is used across
        /// the application to avoid per-frame allocations.
        /// </summary>
        private List<DetectedPlane> m_AllPlanes = new List<DetectedPlane>();

        /// <summary>
        /// True if the app is in the process of quitting due to an ARCore connection error, otherwise false.
        /// </summary>
        private bool m_IsQuitting = false;

		//private int currentNumberOfObjects=0;
		//public int numberOfObjectsAllowed;
		 int index;
		/// <summary>
		/// The Unity Update() method.
		/// </summary>
		public void Update()
        {
            _UpdateApplicationLifecycle();

            // Hide snackbar when currently tracking at least one plane.
            Session.GetTrackables<DetectedPlane>(m_AllPlanes);
			bool showSearchingUI=true; //Condition for the sercing canvas
			bool showNavigationUI=false;

			for (int i = 0; i < m_AllPlanes.Count; i++)
            {
				if (m_AllPlanes[i].TrackingState == TrackingState.Tracking)
				{	
					showSearchingUI = false;
					showNavigationUI = true;
					//if(gameObject.GetComponent<TouchControl>().)
					
					break;
                }
				
            }

            SearchingForPlaneUI.SetActive(showSearchingUI);
			NavigationPlaneUI.SetActive(showNavigationUI);
			//When the navigation panel diapare then the object canvas also need to disapare
			if(showNavigationUI==false)
			{
				gameObject.GetComponent<TouchControl>().ObjectCanvas.gameObject.SetActive(false);
			}
			

			// If the player has not touched the screen, we are done with this update.


			Touch touch;
            if (Input.touchCount < 1 || (touch = Input.GetTouch(0)).phase != TouchPhase.Began)
            {
				return;
            } 
			TrackableHit hit;
			TrackableHitFlags raycastFilter = TrackableHitFlags.PlaneWithinPolygon |
			TrackableHitFlags.FeaturePointWithSurfaceNormal;
			
				//here create a loop to control the number of object allowed
				if (Frame.Raycast(touch.position.x, touch.position.y, raycastFilter, out hit))
				{
					// Use hit pose and camera pose to check if hittest is from the
					// back of the plane, if it is, no need to create the anchor.
					if ((hit.Trackable is DetectedPlane) &&
						Vector3.Dot(FirstPersonCamera.transform.position - hit.Pose.position,
							hit.Pose.rotation * Vector3.up) < 0)
					{
						Debug.Log("Hit at back of the current DetectedPlane");
					}

					else
					{
						//From here the touch will be activated
						//touch control start from here
						//if touch control buton activate the tuch will be activated from here as well
					
						if (gameObject.GetComponent<TouchControl>().TouchState==true)
						{
								if(gameObject.GetComponent<ObjectSelection>().IMS3VisualState == true)
								{
									gameObject.GetComponent<ObjectSelection>().numobject[index=0] = ObPrefab[index=0];
									//ObjectRegistration();
									var andyObject = Instantiate(ObPrefab[index=0], hit.Pose.position, hit.Pose.rotation);

									// Compensate for the hitPose rotation facing away from the raycast (i.e. camera).
									andyObject.transform.Rotate(0, k_ModelRotation, 0, Space.Self);

									// Create an anchor to allow ARCore to track the hitpoint as understanding of the physical
									// world evolves.
									var anchor = hit.Trackable.CreateAnchor(hit.Pose);

									// Make Andy model a child of the anchor.
									andyObject.transform.parent = anchor.transform;


								}

								if (gameObject.GetComponent<ObjectSelection>().IMS4VisualState == true)
								{
									gameObject.GetComponent<ObjectSelection>().numobject[index=1] = ObPrefab[index=1];
									var andyObject = Instantiate(ObPrefab[index=1], hit.Pose.position, hit.Pose.rotation);

									// Compensate for the hitPose rotation facing away from the raycast (i.e. camera).
									andyObject.transform.Rotate(0, k_ModelRotation, 0, Space.Self);

									// Create an anchor to allow ARCore to track the hitpoint as understanding of the physical
									// world evolves.
									var anchor = hit.Trackable.CreateAnchor(hit.Pose);

									// Make Andy model a child of the anchor.
									andyObject.transform.parent = anchor.transform;

								}
								if (gameObject.GetComponent<ObjectSelection>().IMS5VisualState == true)
								{
									gameObject.GetComponent<ObjectSelection>().numobject[index=2] = ObPrefab[index=2];
									
									var andyObject = Instantiate(ObPrefab[index=2], hit.Pose.position, hit.Pose.rotation);

									// Compensate for the hitPose rotation facing away from the raycast (i.e. camera).
									andyObject.transform.Rotate(0, k_ModelRotation, 0, Space.Self);

									// Create an anchor to allow ARCore to track the hitpoint as understanding of the physical
									// world evolves.
									var anchor = hit.Trackable.CreateAnchor(hit.Pose);

									// Make Andy model a child of the anchor.
									andyObject.transform.parent = anchor.transform;

								}
								if (gameObject.GetComponent<ObjectSelection>().IMS7VisualState == true)
								{
									gameObject.GetComponent<ObjectSelection>().numobject[index=3] = ObPrefab[index = 3];
									
									var andyObject = Instantiate(ObPrefab[index=3], hit.Pose.position, hit.Pose.rotation);

									// Compensate for the hitPose rotation facing away from the raycast (i.e. camera).
									andyObject.transform.Rotate(0, k_ModelRotation, 0, Space.Self);

									// Create an anchor to allow ARCore to track the hitpoint as understanding of the physical
									// world evolves.
									var anchor = hit.Trackable.CreateAnchor(hit.Pose);

									// Make Andy model a child of the anchor.
									andyObject.transform.parent = anchor.transform;
									
								}




						}

						



					}


				}



				
		} 
		
		/// Check and update the application lifecycle.
		private void _UpdateApplicationLifecycle()
        {
            // Exit the app when the 'back' button is pressed.
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            // Only allow the screen to sleep when not tracking.
            if (Session.Status != SessionStatus.Tracking)
            {
                const int lostTrackingSleepTimeout = 15;
                Screen.sleepTimeout = lostTrackingSleepTimeout;
            }
            else
            {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }

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

		public static implicit operator GameObject(Controller v)
		{
			throw new NotImplementedException();
		}
	}
}
