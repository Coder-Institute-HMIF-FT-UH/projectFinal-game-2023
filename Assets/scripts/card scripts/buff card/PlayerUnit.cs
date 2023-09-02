using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public string unitName;      // Nama unit pemain
    public int maxHP;            // Jumlah maksimum darah pemain
    public int currentHP;        // Jumlah darah pemain saat ini

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;        // Mengurangi jumlah darah pemain dengan nilai dmg (kerusakan)
    }

    public void Heal(int amount)
    {
        // Menyembuhkan pemain dengan menambahkan jumlah tertentu ke jumlah darah saat ini
        currentHP = Mathf.Min(currentHP + amount, maxHP);  // Tetapkan darah saat ini dengan memastikan tidak melebihi darah maksimum
    }
}
