using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostBattleScript : MonoBehaviour
{
    public SceneMoving sceneMovingScript;
    public GameObject realHistoryImage;
    public GameObject thankYouImage;
    public float countdownTime = 20f;
    private float currentTime;

    private void Start()
    {
        currentTime = countdownTime;
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            realHistoryImage.SetActive(true);
            if (currentTime <= 10f)
            {
                thankYouImage.SetActive(true);
            }
        }
        else
        {
            sceneMovingScript.LoadMainMenuScene();
            // You can add logic here for what to do when the countdown reaches zero.
        }
    }
}
