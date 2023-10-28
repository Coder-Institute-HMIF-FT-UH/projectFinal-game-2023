using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NodeCode : MonoBehaviour
{
    [SerializeField] public int nodeTypeRandom;
    [SerializeField] public string battleScene = "BattleScene";
    [SerializeField] public string restAreaScene = "RestAreaScene";
    private bool hasLoadedScene = false;

    void Start()
    {
        nodeTypeRandom = Random.Range(2, 4);
    }

    void OnMouseDown()
    {
        if (!hasLoadedScene)
        {
            if (nodeTypeRandom == 2)
            {
                SceneManager.LoadScene(battleScene, LoadSceneMode.Single);
                hasLoadedScene = true;
            }
            else
            {
                SceneManager.LoadScene(restAreaScene, LoadSceneMode.Single);
                hasLoadedScene = true;
            }
        }
    }
}

