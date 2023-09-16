/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 

public class BattleSystemV1_A : MonoBehaviour
{
    // Event yang dapat dipanggil oleh kelas lain
    public event Action<int> OnAttackEvent;

    // Metode untuk memanggil event saat serangan terjadi
    public void Attack(int damage)
    {
        OnAttackEvent?.Invoke(damage);
    }
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject cardPrefab;

    CharactersUnit playerUnit;
    CharactersUnit enemyUnit;

    CardsUnit cardUnits;

    public Text playerHealthText;
    public Text enemyHealthText;
    public Text playerDefenseText; // Tambahkan ini

    // Start is called before the first frame update
   
 void Starts()
    {
        SetupBattle();
    }
    void SetupBattle()
{
    playerUnit = playerPrefab.GetComponent<CharactersUnit>();
    enemyUnit = enemyPrefab.GetComponent<CharactersUnit>();
    cardUnit = cardPrefab.GetComponent<CardsUnit>();

    // Inisialisasi teks Defense pemain dan Health musuh
    playerDefenseText.text = "Defense: " + playerUnit.currentDefense.ToString() + "/" + playerUnit.maxDefense.ToString();
    playerHealthText.text = "HP: " + playerUnit.currentHP.ToString() + "/" + playerUnit.maxHP.ToString();
    enemyHealthText.text = "HP: " + enemyUnit.currentHP.ToString() + "/" + enemyUnit.maxHP.ToString();
}
    void PlayerAttacks()
    {
        cardUnits.UseCard(enemyUnit);
        SetupBattle();
    }

    public void OnAttackButtons() 
    {
        PlayerAttacks();
    }

    void ApplyBuffs()
    {
        cardUnit.UseCard(playerUnit);
        SetupBattle();
    }

    public void OnApplyBuffButtons()
    {
        ApplyBuffs();
    }
}
*/