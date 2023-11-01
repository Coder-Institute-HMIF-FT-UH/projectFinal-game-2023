using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int currentHealth;
    [SerializeField] public int maxShield = 100;
    [SerializeField] public int currentShield;

    [SerializeField] private int weakenDamageMultiplier = 150;
    [SerializeField] private bool isWeaken = false;
    [SerializeField] private int weakDamageNullifier = 2;
    [SerializeField] private bool isWeak = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    //enemy debuff function list
    public void TakeDamage(int damage)
    {
        if (isWeaken)
        {
            damage = Mathf.RoundToInt(damage * weakenDamageMultiplier / 100);
        }

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
    public void TakeDamageAll(int damage)
    {
        // Implement the same damage logic here
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
    public void Weaken()
    {
        isWeaken = true;
    }
    public void CleanWeaken()
    {
        isWeaken = false;
    }
    public void Weak()
    {
        isWeak = true;
    }
    public void CleanWeak()
    {
        isWeak = false;
    }

    //enemy behavior
    public void ApplyDebuff(int debuffValue)
    {
        //debuff logic
        Debug.Log("Debuff musuh");
    }
    public void Die()
    {
        Destroy(gameObject);
    }

    //code moveset musuh
    public void AttackPlayer(Player player, int damage)
    {
        if (isWeak)
        {
            int weakenedAtk = damage / 2;
            player.TakeDamage(weakenedAtk);
        }
        player.TakeDamage(damage);
        //Return damage function list
        if (player.isReturnAndHeal)
        {
            TakeDamage(10);
            player.currentHealth += 8;
        }
        if (player.isReturnToAll)
        {
            // Cari semua musuh yang di attached scriptEnemy
            Enemy[] scriptEnemyObjects2 = FindObjectsOfType<Enemy>();
            // Tiap isi dari scriptEnemyObjects akan dilakukan pemanggilan fungsi
            foreach (Enemy enemies in scriptEnemyObjects2)
            {
                enemies.TakeDamageAll(20);
            }
        }
        if (player.isReturnTwoTurn)
        {
            TakeDamage(10);
        }
        
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