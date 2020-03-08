using System.Collections;
using System.Collections.Generic;
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

    public void LoadHeelPalmStrikeScene() 
    {
        SceneManager.LoadScene(heelPalmStrikeScene, LoadSceneMode.Single);
    }

    public void LoadHammerStrikeScene()
    {
        SceneManager.LoadScene(hammerStrikeScene, LoadSceneMode.Single);
    }

    public void LoadGroinKickScene()
    {
        SceneManager.LoadScene(groinKickScene, LoadSceneMode.Single);
    }

    public void LoadElbowStrikeScene()
    {
        SceneManager.LoadScene(elbowStrike, LoadSceneMode.Single);
    }

    public void LoadAlternativeElbowStrikeScene()
    {
        SceneManager.LoadScene(alternativeElbowStrike, LoadSceneMode.Single);
    }

    public void LoadBearHugAttackScene()
    {
        SceneManager.LoadScene(bearHugAttack, LoadSceneMode.Single);
    }
}
