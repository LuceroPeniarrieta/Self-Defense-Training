using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using com.rfilkov.kinect;
using Assets.Scripts;

namespace com.rfilkov.components
{
    /// <summary>
    /// Simple gesture listener that only displays the status and progress of the given gestures.
    /// </summary>
    public class SimpleGestureListener : MonoBehaviour, GestureListenerInterface
    {
        [Tooltip("Index of the player, tracked by this component. 0 means the 1st player, 1 - the 2nd one, 2 - the 3rd one, etc.")]
        public int playerIndex = 0;

        [Tooltip("List of the gestures to detect.")]
        public List<GestureType> detectGestures = new List<GestureType>();

        [Tooltip("UI-Text to display the gesture-listener output.")]
        public UnityEngine.UI.Text gestureInfo;

        // private bool to track if progress message has been displayed
        private bool progressDisplayed;
        private float progressGestureTime;


        // invoked when a new user is detected
        public void UserDetected(ulong userId, int userIndex)
        {
            if (userIndex == playerIndex)
            {
                // as an example - detect these user specific gestures
                KinectGestureManager gestureManager = KinectManager.Instance.gestureManager;

                foreach(GestureType gesture in detectGestures)
                {
                    gestureManager.DetectGesture(userId, gesture);
                }
            }

            if (gestureInfo != null)
            {
                //gestureInfo.text = "Please do the gestures and look for the gesture detection state.";
            }
        }


        // invoked when the user is lost
        public void UserLost(ulong userId, int userIndex)
        {
            if (userIndex != playerIndex)
                return;

            if (gestureInfo != null)
            {
                gestureInfo.text = string.Empty;
            }
        }


        // invoked to report gesture progress. important for the continuous gestures, because they never complete.
        public void GestureInProgress(ulong userId, int userIndex, GestureType gesture,
                                      float progress, KinectInterop.JointType joint, Vector3 screenPos)
        {
            if (userIndex != playerIndex)
                return;

            // check for continuous gestures
            switch(gesture)
            {
                case GestureType.ZoomOut:
                case GestureType.ZoomIn:
                    if (progress > 0.5f && gestureInfo != null)
                    {
                        string sGestureText = string.Format("{0} - {1:F0}%", gesture, screenPos.z * 100f) + " realizado - Exitosamente";
                        gestureInfo.text = sGestureText;
                        DataStore.Text = DataStore.Text + "\n" + sGestureText;

                        progressDisplayed = true;
                        progressGestureTime = Time.realtimeSinceStartup;
                    }
                    break;

                case GestureType.Wheel:
                case GestureType.InclinacionIzquierda:
                case GestureType.InclinacionDerecha:
                case GestureType.InclincacionDelantera:
                case GestureType.InclincacionTrasera:
                    if (progress > 0.5f && gestureInfo != null)
                    {
                        string sGestureText = string.Format("{0} - {1:F0} grados", gesture, screenPos.z) + " realizado - Exitosamente";
                        gestureInfo.text = sGestureText;
                        DataStore.Text = DataStore.Text + "\n" + sGestureText;

                        progressDisplayed = true;
                        progressGestureTime = Time.realtimeSinceStartup;
                    }
                    break;

                case GestureType.Run:
                    if (progress > 0.5f && gestureInfo != null)
                    {
                        string sGestureText = string.Format("{0} - progress: {1:F0}%", gesture, progress * 100) + " realizado - Exitosamente";
                        gestureInfo.text = sGestureText;
                        DataStore.Text = sGestureText;
                        DataStore.Text = DataStore.Text + "\n" + sGestureText;

                        progressDisplayed = true;
                        progressGestureTime = Time.realtimeSinceStartup;
                    }
                    break;
            }
        }


        // invoked when a (discrete) gesture is complete.
        public bool GestureCompleted(ulong userId, int userIndex, GestureType gesture,
                                      KinectInterop.JointType joint, Vector3 screenPos)
        {
            if (userIndex != playerIndex)
                return false;

            if (progressDisplayed)
                return true;

            string sGestureText = gesture + " realizado - Exitosamente";
            if (gestureInfo != null)
            {
                gestureInfo.text = sGestureText;
                DataStore.Text = sGestureText;
                DataStore.Text = DataStore.Text + "\n" + sGestureText;
            }

            return true;
        }


        // invoked when a gesture gets cancelled by the user
        public bool GestureCancelled(ulong userId, int userIndex, GestureType gesture,
                                      KinectInterop.JointType joint)
        {
            if (userIndex != playerIndex)
                return false;

            if (progressDisplayed)
            {
                progressDisplayed = false;

                if (gestureInfo != null)
                {
                    gestureInfo.text = String.Empty;
                }
            }

            return true;
        }


        public void Update()
        {
            // checks for timed out progress message
            if (progressDisplayed && ((Time.realtimeSinceStartup - progressGestureTime) > 2f))
            {
                progressDisplayed = false;

                if (gestureInfo != null)
                {
                    gestureInfo.text = String.Empty;
                }

                Debug.Log("Forced progress to end.");
            }
        }

    }
}
