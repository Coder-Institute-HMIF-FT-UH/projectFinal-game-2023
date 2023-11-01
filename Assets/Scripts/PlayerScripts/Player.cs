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

    public bool isReturnAndHeal = false;
    public bool isReturnToAll = false;
    public bool isReturnTwoTurn = false;
    public int returnTwo = 2;

    public Text energyText;
    public Text shieldText;
    public Text healthText;

    private static GameObject instance;
    private void Start()
    {
        if (instance == null)
        {
            instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Replace the old instance with the new one
            Destroy(instance);

            instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        currentEnergy = maxEnergy;
        currentShield = 0;
        isReturnAndHeal = false;
        isReturnToAll = false;
        isReturnTwoTurn = false;
    }
    
    //Player behaviour
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

    //Player damage function
    public void TakeDamage(int damage)
    {
        if (currentShield > 0)
        {
            if (damage <= currentShield)
            {
                currentShield -= damage;
            }
            else
            {
                damage -= currentShield;
                currentShield = 0;
                currentHealth -= damage;
            }
        }
        else
        {
            currentHealth -= damage;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void ReturnAndHeal()
    {
        isReturnAndHeal = true;
    }
    public void CleanReturnAndHeal()
    {
        isReturnAndHeal = false;
    }
    public void ReturnToAll()
    {
        isReturnToAll = true;
    }
    public void CleanReturnToAll()
    {
        isReturnToAll = false;
    }
    public void ReturnTwoTurn()
    {
        returnTwo = 2;
        isReturnTwoTurn = true;
    }
    public void CleanReturnTwoTurn()
    {
        returnTwo -= 1;
        if (returnTwo <= 0)
        {
            isReturnTwoTurn = false;
        }
    }
    private void Die()
    {
        //balik ke main menu
    }
}
