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

    /* pemain memiliki buff "Gain Counter-Attack"
    if (playerUnit.hasCounterAttackBuff)
    {
        StartCoroutine(CounterAttackRoutine());
    }
} */

// Metodh mengimplementasikan serangan balasan
/*IEnumerator CounterAttackRoutine()
{
    yield return new WaitForSeconds(1f); // Tunggu sebentar untuk memberikan musuh kesempatan menyerang

    // Simulasikan serangan balasan ke musuh
    // menyesuaikan serangan balasan 
    // hanya akan mengurangkan HP musuh
    enemyUnit.TakeDamage(playerUnit.counterAttackDamage);

    // Kurangi durasi buff
    playerUnit.counterAttackDuration--;

    // Jika durasi buff habis, nonaktifkan buff
    if (playerUnit.counterAttackDuration <= 0)
    {
        playerUnit.hasCounterAttackBuff = false;
    }
}*/

    public void OnApplyBuffButton()
    {
        ApplyBuff();
    }
//}
}