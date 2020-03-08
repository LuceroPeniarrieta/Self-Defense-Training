using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GymManager : MonoBehaviour
{
    public void LoadNewScene() 
    {
        SceneManager.LoadScene("gym env", LoadSceneMode.Single);
        SceneManager.LoadScene("KinectAvatarsDemo1", LoadSceneMode.Additive);
    }
}
