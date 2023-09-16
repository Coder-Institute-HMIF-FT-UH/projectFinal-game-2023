using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlayer1 : MonoBehaviour
{
    public string cardName;     // Nama kartu
    public int Damage;          // Jumlah kerusakan yang akan diberikan ke pemain
    public int HealAmount;      // Jumlah penyembuhan yang akan diberikan ke pemain

    public void UseCard(PlayerUnit targetPlayer)
    {
        targetPlayer.TakeDamage(Damage);         // Memanggil metode TakeDamage pada pemain dengan nilai kerusakan
        targetPlayer.Heal(HealAmount);           // Memanggil metode Heal pada pemain dengan nilai penyembuhan

        // Aktifkan buff "Gain Counter-Attack"
        //targetPlayer.hasCounterAttackBuff = true;
        //targetPlayer.counterAttackDuration = 2; // Buff aktif selama 2 putaran

        Destroy(gameObject);                    // Menghapus objek kartu dari permainan setelah digunakan
    }
}
