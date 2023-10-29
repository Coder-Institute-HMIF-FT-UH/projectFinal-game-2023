using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] public int maxShield = 100;
    [SerializeField] private int currentShield;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void ApplyDebuff(int debuffValue)
    {
        //debuff logic
        Debug.Log("Debuff musuh");
    }
    private void Die()
    {
        Destroy(gameObject);
    }

    //code moveset musuh
    public void AttackPlayer(Player player, int damage)
    {
        player.TakeDamage(damage);
    }

    public void GainShield(int shieldAmount)
    {
        currentShield += shieldAmount;
    }

    public void HealingSelf(int healAmount)
    {
        currentHealth += healAmount;
    }
}