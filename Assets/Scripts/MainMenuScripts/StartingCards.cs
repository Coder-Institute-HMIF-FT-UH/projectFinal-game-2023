using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCards : MonoBehaviour
{
    [SerializeField] public List<GameObject> cardDeck; //Kartu Inventory
    [SerializeField] private List<GameObject> loadedCards = new List<GameObject>(); // Stores the loaded prefabs
    private static GameObject instance;
    void Start()
    {
        if (instance == null)
        {
            instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Replace the old instance with the new one
            Destroy(instance);

            instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        LoadCardPrefabs();
    }

    private void LoadCardPrefabs()
    {
        // Check if we haven't loaded the cards yet
        if (loadedCards.Count == 0)
        {
            // Load all prefabs from the "Resources/Cards/Char1" folder
            GameObject[] cardPrefabs = Resources.LoadAll<GameObject>("Cards/Hasanuddin");

            if (cardPrefabs.Length > 0)
            {
                loadedCards.AddRange(cardPrefabs);
            }
            else
            {
                Debug.LogError("No card prefabs found in the 'Resources/Cards/Hasanuddin' folder.");
            }
        }
    }

    public List<GameObject> GetInventoryCards()
    {
        return cardDeck;
    }
    public void AddingCardReward()
    {
        //Menambah 1 kartu random ke list kartu inventory
        if (loadedCards.Count > 0)
        {
            // Get a random index to select a random prefab from the loadedCards list
            int randomIndex = Random.Range(0, loadedCards.Count);

            // Add the selected prefab reference to the cardDeck list
            cardDeck.Add(loadedCards[randomIndex]);
        }
        else
        {
            Debug.LogError("No card prefabs have been loaded from 'Resources/Cards/Hasanuddin'.");
        }
    }
}
