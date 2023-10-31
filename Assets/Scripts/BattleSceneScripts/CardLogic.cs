using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Attack,
    Defense,
    Buff,
    Debuff
}

public enum BuffVariation
{
    Buff1,
    ShieldEach,
    DoubleShield,
    ReturnAndHeal,
    ReturnToAll,
    Return2Turn,
    Heal,
    // Add more variations as needed
}

public enum DebuffVariation
{
    Debuff1,
    DamageToAll,
    EqualShield,
    Weaken,
    Weak,
    // Add more variations as needed
}

public class CardLogic : MonoBehaviour
{
    public int value;
    public int energyCost;
    public CardType cardType;

    public Player player; // Reference to the Player object.
    public BuffVariation buffVariation; // Variation for Buff cards
    public DebuffVariation debuffVariation; // Variation for Debuff cards

    private Vector3 defaultPosition;
    private Vector3 touchStartPos;
    private Vector3 objectStartPos;
    private bool isDragging = false;

    private void Start()
    {
        defaultPosition = transform.position;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    public void ApplyCardEffect(Enemy enemy)
    {
        switch (cardType)
        {
            case CardType.Attack:
                if (player.UseEnergy(energyCost))
                {
                    enemy.TakeDamage(value);
                }
                break;
            case CardType.Defense:
                if (player.UseEnergy(energyCost))
                {
                    player.GainShield(value);
                }
                break;
            case CardType.Buff:
                if (player.UseEnergy(energyCost))
                {
                    ApplyBuff(enemy, buffVariation);
                }
                break;
            case CardType.Debuff:
                if (player.UseEnergy(energyCost))
                {
                    ApplyDebuff(enemy, debuffVariation);
                }
                break;
            default:
                Debug.LogWarning("Unknown card type: " + cardType);
                break;
        }
    }

    private void ApplyBuff(Enemy enemy, BuffVariation variation)
    {
        switch (variation)
        {
            case BuffVariation.Buff1:
                // Implement Buff1 logic
                break;
            case BuffVariation.ShieldEach:
                //currentshield += 3
                //hitung jumlah musuh, int = getcomponent<enemy>().count()
                //currentshield = currentshield * int
                player.currentShield += 3;
                int enemyCount = FindObjectsOfType<Enemy>().Length;
                player.currentShield *= enemyCount;
                break;
            case BuffVariation.DoubleShield:
                //currentshield += 6
                //currentshield * 2
                player.currentShield += 6;
                player.currentShield *= 2;
                break;
            case BuffVariation.Heal:
                //heal 14
                player.currentHealth += 14;
                break;
            case BuffVariation.ReturnAndHeal:
                //Taruh variabel di musuh
                //jika musuh menyerang, kena demeg
                //heal
                break;
            case BuffVariation.ReturnToAll:
                //Taruh variabel di musuh
                //jika musuh menyerang, kena demeg tapi ke semua musuh (broadcast)
                break;
            case BuffVariation.Return2Turn:
                //Taruh variabel di musuh
                //jika musuh menyerang, kena demeg, tapi buff ini bertahan 2 turn
                break;
                
        }
    }

    private void ApplyDebuff(Enemy enemy, DebuffVariation variation)
    {
        switch (variation)
        {
            case DebuffVariation.Debuff1:
                // Implement Debuff1 logic
                break;
            case DebuffVariation.DamageToAll:
                //Panggil fungsi broadcast yang ada di enemy
                BroadcastMessage("TakeDamageAll");
                break;
            case DebuffVariation.EqualShield:
                //attack musuh dimana damage = currentshield
                break;
            case DebuffVariation.Weaken:
                //aktifkan variabel weaken di musuh, int = 1
                break;
            case DebuffVariation.Weak:
                //aktifkan variabel weak di musuh, int = 1
                break;
        }
    }

    private void OnMouseDown()
    {
        if (Input.touchCount > 0)
        {
            touchStartPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
        else
        {
            touchStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        objectStartPos = transform.position;
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        // Add this method to handle the drag behavior.
        if (isDragging)
        {
            Vector3 currentPos;

            if (Input.touchCount > 0)
            {
                currentPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            }
            else
            {
                currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            transform.position = objectStartPos + (currentPos - touchStartPos);
        }
    }
    private void OnMouseUp()
    {
        if (isDragging)
        {
            isDragging = false;

            // Check if the card is over an enemy.
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.1f);
            foreach (Collider2D hit in hits)
            {
                if (hit.CompareTag("Enemy"))
                {
                    Enemy enemy = hit.GetComponent<Enemy>();
                    if (enemy != null)
                    {
                        ApplyCardEffect(enemy); // Pass the enemy reference to the ApplyCardEffect method.
                                                //kartu dibawa ke discard deck
                                                //hilangkan karu
                        Destroy(gameObject);
                        //if (player.UseEnergy(energyCost) == true)
                        //{
                            
                        //}
                        //else
                        //{
                        //    transform.position = defaultPosition;
                        //}
                    }
                }
            }

            // If not over an enemy, move the card back to its default position.
            transform.position = defaultPosition;
        }
    }
}
