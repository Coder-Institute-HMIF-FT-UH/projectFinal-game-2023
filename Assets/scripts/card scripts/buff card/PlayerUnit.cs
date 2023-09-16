using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public string unitName;      // Nama unit pemain
    public int maxHP;            // Jumlah maksimum darah pemain
    public int currentHP;        // Jumlah darah pemain saat ini
    public bool isDead;          

    public int maxDefense;       // Jumlah maksimum Defense pemain
    public int currentDefense;   // Jumlah Defense pemain saat ini

    public void TakeDamage(int dmg)
    {
        if (currentDefense > 0)
        {
            currentDefense -= dmg;
        }
        else
        {
            currentHP -= dmg;

            // dead
            if (currentHP <= 0)
            {
                currentHP = 0;
                isDead = true;
            }
        }
    }

    public void Heal(int amount)
    {
        // Menyembuhkan pemain dengan menambahkan jumlah tertentu ke jumlah darah saat ini
        currentHP = Mathf.Min(currentHP + amount, maxHP);  // Tetapkan darah saat ini dengan memastikan tidak melebihi darah maksimum
    }
}
