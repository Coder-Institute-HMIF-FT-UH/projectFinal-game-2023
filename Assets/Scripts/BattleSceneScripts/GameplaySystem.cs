using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplaySystem : MonoBehaviour
{
    public List<GameObject> handDeckCards;
    public DrawDeck drawDeckScript;
    public DiscardDeck discardDeckScript; 
    public Transform[] spawnPoints; 

    public Player player;
    public Enemy enemy;

    public Text energyText;

    [SerializeField] private bool isYourTurn; 

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        enemy = GameObject.FindObjectOfType<Enemy>();
        isYourTurn = true;
        DrawCardToHand();
    }

    void Update()
    {
        energyText.text = player.currentEnergy.ToString(); //energy text ui update
        if (!isYourTurn)
        {
            //kalau nd sampai 5 di drawdeck, dia reset duluan isi drawdeck
            if (drawDeckScript.drawDeckCards.Count <= 4)
            {
                drawDeckScript.drawDeckCards.AddRange(discardDeckScript.discardDeckCards);
                discardDeckScript.discardDeckCards.Clear();
            }
            //method beberapa serangan musuh (random.range + switch case) + invoke 1 detik
            Invoke("RandomlySelectEnemyMove", 1f);
            //invoke 3 detik, method 5 card dari draw deck ke (handpool) + invoke 1 detik
            Invoke("DrawCardToHand", 1f);
            //isyurturn = true
            isYourTurn = true;  
        }
    }

    public void EndTurn()
    {
        isYourTurn = false;
        CleaningInstantiateCard();
        player.ReplenishEnergy(player.maxEnergy);
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
                discardDeckScript.discardDeckCards.Add(randomObject);
                drawDeckScript.drawDeckCards.RemoveAt(randomIndex); // Remove the object from the source list to avoid duplicates.

                // Instantiate the object and set its position based on the spawnPoints
                GameObject instantiatedObject = Instantiate(randomObject, spawnPoints[i].position, Quaternion.identity);
            }


        }
        else
        {
            Debug.LogWarning("List Dari Draw Deck Kurang Dari 5, mengambil dari discard deck");
            drawDeckScript.drawDeckCards.AddRange(discardDeckScript.discardDeckCards);
            discardDeckScript.discardDeckCards.Clear();
        }
    }

    public void CleaningInstantiateCard()
    {
        // Find all objects with the specified tag in the scene
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Card");

        // Iterate through the tagged objects and destroy them
        foreach (GameObject obj in taggedObjects)
        {
            Destroy(obj);
        }
    }

    public void RandomlySelectEnemyMove()
    {
        int randomMove = Random.Range(1, 4); // Generate a random number between 1 and 3
        switch (randomMove)
        {
            case 1:
                enemy.AttackPlayer(player, 10); // Choose the first moveset (attack)
                break;
            case 2:
                enemy.GainShield(20); // Choose the second moveset (gain shield)
                break;
            case 3:
                enemy.HealingSelf(5); 
                break;
        }
        Debug.Log(randomMove);
    }
}
