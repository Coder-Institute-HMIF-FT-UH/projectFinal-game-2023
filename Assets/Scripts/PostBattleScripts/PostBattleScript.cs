using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostBattleScript : MonoBehaviour
{
    public SceneMoving sceneMovingScript;
    public Text realHistoryImage;
    public Text thankYouImage;
    public float countdownTime = 20f;
    private float currentTime;
    [SerializeField] private bool isFadeIn1;
    [SerializeField] private bool isFadeIn2;

    private void Start()
    {
        currentTime = countdownTime;
        SetTextAlpha(realHistoryImage, 0.0f);
        SetTextAlpha(thankYouImage, 0.0f);
        isFadeIn1 = true;
        isFadeIn2 = false;
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            if (isFadeIn1)
            {
                //realHistoryImage fade in
                if (realHistoryImage.color.a <= 1.0f)
                {
                    realHistoryImage.color += new Color(0.0f, 0.0f, 0.0f, 0.15f) * Time.deltaTime;
                    if (realHistoryImage.color.a >= 1.0f)
                    {
                        isFadeIn1 = false;
                    }
                }
            }
            if (!isFadeIn1)
            {
                //realHistoryImage fade out
                realHistoryImage.color -= new Color(0.0f, 0.0f, 0.0f, 0.15f) * Time.deltaTime;
                if (realHistoryImage.color.a <= 0.0f)
                {
                    isFadeIn2 = true;
                }
            }


            if (isFadeIn2)
            {
                //thankYouImage fade in
                if (thankYouImage.color.a <= 1.0f)
                {
                    thankYouImage.color += new Color(0.0f, 0.0f, 0.0f, 0.2f) * Time.deltaTime;
                    if (thankYouImage.color.a >= 1.0f)
                    {
                        isFadeIn2 = false;
                    }
                }
            }
        }
        else
        {
            sceneMovingScript.LoadMainMenuScene();
        }
    }

    private void SetTextAlpha(Text text, float alpha)
    {
        Color textColor = text.color;
        textColor.a = alpha;
        text.color = textColor;
    }
}
