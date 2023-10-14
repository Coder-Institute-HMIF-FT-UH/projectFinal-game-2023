using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawDeck : MonoBehaviour
{
    public GameObject inventory;
    public GameObject drawDeck;
    public List<GameObject> drawDeckCards;
    void Start()
    {
        inventory = GameObject.Find("Inventory");

        drawDeckCards.Clear();
        List<GameObject> inventoryCards = inventory.GetComponent<StartingCards>().GetInventoryCards();
        drawDeckCards.AddRange(inventoryCards);
    }

}
