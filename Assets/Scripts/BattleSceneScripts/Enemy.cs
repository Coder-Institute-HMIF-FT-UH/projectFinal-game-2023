using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int currentHealth;
    [SerializeField] public int maxShield = 100;
    [SerializeField] public int currentShield;

    [SerializeField] public Text floatingTextTemplate;
    public Transform canvasTransform;

    [SerializeField] private int weakenDamageMultiplier = 150;
    [SerializeField] private bool isWeaken = false;

    [SerializeField] private bool isWeak = false;


    private void Start()
    {
        currentHealth = maxHealth;
    }
    //floating text damage/shield/heal enemy
    public void ShowFloatingText(Vector3 position, string message, Color textColor)
    {
        // Instantiate the Text GameObject from the template
        Text floatingTextInstance = Instantiate(floatingTextTemplate, Vector3.zero, Quaternion.identity);
        floatingTextInstance.transform.SetParent(canvasTransform, false);

        // Set its properties
        floatingTextInstance.gameObject.SetActive(true); // Activate the instantiated Text GameObject
        Text textComponent = floatingTextInstance.GetComponent<Text>();
        textComponent.text = message;
        textComponent.color = textColor;

        // Calculate the local position relative to the canvas
        Vector2 localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasTransform as RectTransform, position, null, out localPosition);
        floatingTextInstance.GetComponent<RectTransform>().localPosition = localPosition;

        StartCoroutine(HideFloatingText(floatingTextInstance.gameObject));
    }
    private IEnumerator HideFloatingText(GameObject textObject)
    {
        yield return new WaitForSeconds(2.0f); // Wait for 2 seconds
        Destroy(textObject); // Destroy the instantiated Text GameObject
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
        ShowFloatingText(player.transform.position + new Vector3(0, 3), $"-{damage} HP", Color.red);
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
        ShowFloatingText(gameObject.transform.position + new Vector3(0, 3), $"+{shieldAmount} Shield", Color.gray);
    }
    public void HealingSelf(int healAmount)
    {
        currentHealth += healAmount;
        ShowFloatingText(gameObject.transform.position + new Vector3(0, 3), $"+{healAmount} Heal", Color.green);
    }
}