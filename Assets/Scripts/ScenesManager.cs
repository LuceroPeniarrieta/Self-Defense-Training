using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public string heelPalmStrikeScene;
    public string hammerStrikeScene;
    public string groinKickScene;
    public string elbowStrike;
    public string alternativeElbowStrike;
    public string bearHugAttack;
    public string currentScene;

    private static ScenesManager _instance;

    public static ScenesManager Instance { get; private set; } // static singleton
    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    public void LoadHeelPalmStrikeScene() 
    {
        SceneManager.LoadScene(heelPalmStrikeScene, LoadSceneMode.Single);
        currentScene = heelPalmStrikeScene;
    }

    public void LoadHammerStrikeScene()
    {
        SceneManager.LoadScene(hammerStrikeScene, LoadSceneMode.Single);
        currentScene = hammerStrikeScene;
    }

    public void LoadGroinKickScene()
    {
        SceneManager.LoadScene(groinKickScene, LoadSceneMode.Single);
        currentScene = groinKickScene;
    }

    public void LoadElbowStrikeScene()
    {
        SceneManager.LoadScene(elbowStrike, LoadSceneMode.Single);
        currentScene = elbowStrike;
    }

    public void LoadAlternativeElbowStrikeScene()
    {
        SceneManager.LoadScene(alternativeElbowStrike, LoadSceneMode.Single);
        currentScene = alternativeElbowStrike;
    }

    public void LoadBearHugAttackScene()
    {
        SceneManager.LoadScene(bearHugAttack, LoadSceneMode.Single);
        currentScene = bearHugAttack;
    }

    public void Back()
    {
        SceneManager.UnloadSceneAsync("Dashboard");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
