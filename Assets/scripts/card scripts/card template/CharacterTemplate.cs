using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTemplate : MonoBehaviour
{
    public string unitName;      // Nama unit pemain
    public int maxHP;            // Jumlah maksimum darah pemain
    public int currentHP;        // Jumlah darah pemain saat ini
    public int maxDefense;   // Jumlah Defense pemain
	public int currentDefense;   // Jumlah Defense pemain

    public void TakeDamage(int dmg)
    {
		if(currentDefense > 0)
		{
			currentDefense -= dmg;        // Mengurangi jumlah darah pemain dengan nilai dmg (kerusakan)
		}
		else
		{
			currentHP -= dmg
		}
    }

    public void Heal(int amount)
    {
        // Menyembuhkan pemain dengan menambahkan jumlah tertentu ke jumlah darah saat ini
        currentHP = Mathf.Min(currentHP + amount, maxHP);  // Tetapkan darah saat ini dengan memastikan tidak melebihi darah maksimum
    }

    public void Defense(int amount)
    {
        // Menambahkan defense pemain dengan menambahkan jumlah tertentu ke jumlah darah saat ini
        currentDefense = Mathf.Min(currentDefense + amount, maxDefense);  // Tetapkan Defense saat ini dengan memastikan tidak melebihi Defense maksimum
    }
}