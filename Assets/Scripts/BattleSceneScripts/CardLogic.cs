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

public class CardLogic : MonoBehaviour
{
    public int value;
    public int energyCost;
    public CardType cardType;

    public Player player; // Reference to the Player object.

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
                    player.ApplyBuff(value);
                }
                break;
            case CardType.Debuff:
                if (player.UseEnergy(energyCost))
                {
                    enemy.ApplyDebuff(value);
                }
                break;
            default:
                Debug.LogWarning("Unknown card type: " + cardType);
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
                    }
                }
            }

            // If not over an enemy, move the card back to its default position.
            transform.position = defaultPosition;
        }

    }
}
