using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffSystems : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject buffCardPrefab;

    PlayerUnit playerUnit;
    CardPlayer1 buffCardUnit;

    public Text playerHealthText;

    // Start is called before the first frame update
    void Start()
    {
        SetupBuff();
    }

    void SetupBuff()
    {
        playerUnit = playerPrefab.GetComponent<PlayerUnit>();
        buffCardUnit = buffCardPrefab.GetComponent<CardPlayer1>();

        playerHealthText.text = "HP: " + playerUnit.currentHP.ToString() + "/" + playerUnit.maxHP.ToString();
    }

    void ApplyBuff()
    {
        buffCardUnit.UseCard(playerUnit);
        SetupBuff();
    }

    public void OnApplyBuffButton()
    {
        ApplyBuff();
    }
}
