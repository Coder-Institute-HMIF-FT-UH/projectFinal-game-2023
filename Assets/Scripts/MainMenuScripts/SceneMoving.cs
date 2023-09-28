using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoving : MonoBehaviour
{
    public void LoadMapTraversingScene()
    {
        SceneManager.LoadScene("MapTraversingScene", LoadSceneMode.Single);
    }
}
