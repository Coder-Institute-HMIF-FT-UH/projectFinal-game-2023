using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoving : MonoBehaviour
{
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }
    public void LoadMapTraversingScene()
    {
        SceneManager.LoadScene("MapTraversingScene", LoadSceneMode.Single);
    }

    public void LoadBattleScene()
    {
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
    }

    public void LoadPostLastBattleScene()
    {
        SceneManager.LoadScene("PostLastBattleScene", LoadSceneMode.Single);
    }
}
