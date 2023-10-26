using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardDeck : MonoBehaviour
{
    public GameObject drawDeck;
    public GameObject discardDeck;
    public List<GameObject> discardDeckCards;

    public void HandCardToDiscard(GameObject handCard)
    {
        discardDeckCards.Add(handCard);
    }
}
