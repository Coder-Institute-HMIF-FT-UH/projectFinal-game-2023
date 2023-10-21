using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySystem : MonoBehaviour
{
    [SerializeField] public int energy;
    public List<GameObject> handDeckCards;
    public DrawDeck drawDeckScript;
    public DiscardDeck discardDeckScript; 
    public Transform spawnPoint; 
    public float spacing = 1.0f; 


    [SerializeField] private bool isYourTurn; 

    void Start()
    {
        isYourTurn = true;
        DrawCardToHand();
    }

    void Update()
    {
        if (!isYourTurn)
        {
            //method beberapa serangan musuh (random.range + switch case)
            //isyurturn = true
            //invoke 3 detik, method 5 card dari draw deck ke (handpool)
        }
    }

    public void EndTurn()
    {
        isYourTurn = false;
    }

    public void DrawCardToHand()
    {
        // Ensure that the source list has at least 5 objects to avoid index out of range errors
        if (drawDeckScript.drawDeckCards.Count >= 5)
        {
            for (int i = 0; i < 5; i++)
            {
                int randomIndex = Random.Range(0, drawDeckScript.drawDeckCards.Count);
                GameObject randomObject = drawDeckScript.drawDeckCards[randomIndex];
                handDeckCards.Add(randomObject);
                drawDeckScript.drawDeckCards.RemoveAt(randomIndex); // Remove the object from the source list to avoid duplicates.
            }
            foreach (var gameObject in handDeckCards)
            {
                Instantiate(gameObject, spawnPoint.position, Quaternion.identity);
                spawnPoint.position += new Vector3(spacing, 0, 0);
            }
        }
        else
        {
            Debug.LogWarning("List Dari Draw Deck Kurang Dari 5");
        }
    }
}
