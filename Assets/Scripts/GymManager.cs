using UnityEngine;
using UnityEngine.SceneManagement;

public class GymManager : MonoBehaviour
{
    public string sceneName;

    public void LoadNewScene() 
    {
        SceneManager.LoadScene("gym env", LoadSceneMode.Single);
        SceneManager.LoadScene("KinectAvatarsDemo1", LoadSceneMode.Additive);
    }

    public void UnloadScene() 
    {
        SceneManager.UnloadSceneAsync(sceneName);
        SceneManager.LoadScene("Dashboard", LoadSceneMode.Single);
    }

    public void ExitScene()
    {
        SceneManager.UnloadSceneAsync(sceneName);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ExitGym()
    {
        SceneManager.UnloadSceneAsync("gym env");
        SceneManager.UnloadSceneAsync("KinectAvatarsDemo1");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void LoadVideo()
    {
        SceneManager.UnloadSceneAsync("gym env");
        SceneManager.UnloadSceneAsync("KinectAvatarsDemo1");
        SceneManager.LoadScene(ScenesManager.Instance.currentScene, LoadSceneMode.Single);
    }

    public void LoadDashboard()
    {
        SceneManager.UnloadSceneAsync("gym env");
        SceneManager.UnloadSceneAsync("KinectAvatarsDemo1");
        SceneManager.LoadScene("Dashboard", LoadSceneMode.Single);
    }
}
