using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxEnergy = 10;
    public int currentEnergy;
    public int maxShield = 0;
    public int currentShield = 0;
    public int maxHealth = 100;
    public int currentHealth;

    public Text energyText;
    public Text shieldText;
    public Text healthText;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        currentEnergy = maxEnergy;
        currentShield = 0;
    }

    public bool UseEnergy(int energyCost)
    {
        if (currentEnergy >= energyCost)
        {
            currentEnergy -= energyCost;
            return true;
        }
        else
        {
            Debug.Log("Not enough energy to use this card.");
            return false;
        }
    }

    public void ReplenishEnergy(int energyAmount)
    {
        currentEnergy = energyAmount;
        if (currentEnergy < 0)
        {
            currentEnergy = 0;
        }
        else if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
    }

    public void GainShield(int shieldValue)
    {
        currentShield += shieldValue;
        if (currentShield < 0)
        {
            currentShield = 0;
        }
    }

    public void ApplyBuff(int buffValue)
    {
        // Implement buff logic here
        Debug.Log("buff sendiri");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //klo mati balik ke main menu
    }

    //private void UpdateUI()
    //{
    //    energyText.text = "Energy: " + currentEnergy + " / " + maxEnergy;
    //    shieldText.text = "Shield: " + currentShield + " / " + maxShield;
    //    healthText.text = "Health: " + currentHealth + " / " + maxHealth;
    //}
}
