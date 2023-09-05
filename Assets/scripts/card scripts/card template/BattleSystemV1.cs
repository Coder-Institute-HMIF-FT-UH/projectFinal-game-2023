using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystemV1 : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject cardPrefab;

    CharactersUnit playerUnit;
    CharactersUnit enemyUnit;

    CardsUnit cardUnit;

    public Text playerHealthText;
    public Text enemyHealthText;


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
        playerDefenseText.text = playerUnit.maxDefense.ToString() + "/" + playerUnit.currentDefense.ToString();

        enemyHealthText.text = enemyUnit.maxHP.ToString() + "/" + enemyUnit.currentHP.ToString();
        enemyHealthText.text = enemyUnit.maxHP.ToString() + "/" + enemyUnit.currentHP.ToString();
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
        SetupBattle();
    }

    public void OnApplyBuffButton()
    {
        ApplyBuff();
    }
}
