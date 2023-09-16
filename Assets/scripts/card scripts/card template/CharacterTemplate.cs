/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystemV1_B : MonoBehaviour
{
    private void Start()
    {
        // Berlangganan event dari BattleSystemV1_A
        battleSystemA.OnAttackEvent += HandleAttackEvent;
    }

    // Metode yang akan dipanggil saat event OnAttackEvent terjadi
    private void HandleAttackEvent(int damage)
    {
        Debug.Log($"Received attack with damage: {damage}");
    }

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject cardPrefab;

    CharactersUnit playerUnit;
    CharactersUnit enemyUnit;

    CardsUnit cardUnit;

    public Text playerHealthText;
    public Text enemyHealthText;
    public Text playerDefenseText; // Tambahkan ini

    // Start is called before the first frame update
    void Start()
    {
        SetupBattle();
    }

    void SetupBattle()
    {
        playerUnit = playerPrefab.GetComponent<CharactersUnit>();
        enemyUnit = enemyPrefab.GetComponent<CharactersUnit>();
        cardUnit = cardPrefab.GetComponent<CardsUnit>();

        playerDefenseText.text = playerUnit.maxDefense.ToString() + "/" + playerUnit.currentDefense.ToString();
        playerHealthText.text = "HP: " + playerUnit.currentHP.ToString() + "/" + playerUnit.maxHP.ToString();
        enemyHealthText.text = "HP: " + enemyUnit.currentHP.ToString() + "/" + enemyUnit.maxHP.ToString();
    }

    void PlayerAttack()
    {
        CardUnit.UseCard(enemyUnit);
        SetupBattle();
    }

    public void OnAttackButton()
    {
        PlayerAttack();
    }

    void ApplyBuff()
    {
        CardUnit.UseCard(playerUnit);
        SetupBattlee();
    }

    public void OnApplyBuffButton()
    {
        ApplyBuff();
    }
}
*/