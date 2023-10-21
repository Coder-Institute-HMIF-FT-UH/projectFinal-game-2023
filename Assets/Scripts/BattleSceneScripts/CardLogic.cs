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
    private DragObject dragScript;

    public int value;
    public int energyCost;
    public CardType cardType;

    public Player player; // Reference to the Player object.

    private Vector3 defaultPosition;

    private void Start()
    {
        dragScript = GetComponent<DragObject>();
        defaultPosition = transform.position;
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    private void OnMouseUp()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            Enemy enemy = hit.collider.GetComponent<Enemy>();
            if (enemy != null)
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
        }

        transform.position = defaultPosition;
    }
}
