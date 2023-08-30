using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleSystems : MonoBehaviour
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

        playerHealthText.text = playerUnit.maxHP.ToString() + "/" + playerUnit.currentHP.ToString();
        enemyHealthText.text = enemyUnit.maxHP.ToString() + "/" + enemyUnit.currentHP.ToString();
    }

    void PlayerAttack()
    {
        enemyUnit.currentHP -= cardUnit.Damage;
        SetupBattle();
    }

    public void OnAttackButton() 
    {
        PlayerAttack();
    }
}