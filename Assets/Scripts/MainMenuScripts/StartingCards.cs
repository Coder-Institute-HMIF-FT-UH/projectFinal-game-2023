using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCards : MonoBehaviour
{
    [SerializeField] public List<GameObject> cardDeck; //Kartu Inventory

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartingDeckInit();
    }

    void Update()
    {

    }

    public void StartingDeckInit()
    {
        // Load semua resource yang ada di Resources/Cards/Hasanuddin dan memasukkan kedalam array
        Object[] cards = Resources.LoadAll("Cards/Hasanuddin", typeof(GameObject));

        // Pastikan ada cukup kartu untuk diambil
        if (cards.Length < 5)
        {
            Debug.LogError("Not enough cards in the folder!");
            return;
        }

        List<int> selectedIndices = new List<int>(); // Menyimpan indeks yang sudah terpilih

        // Ambil 5 kartu secara acak
        for (int i = 0; i < 5; i++)
        {
            int randomIndex;

            // Pastikan tidak mengambil kartu yang sama
            do
            {
                randomIndex = Random.Range(0, cards.Length);
            } while (selectedIndices.Contains(randomIndex));

            // Menambahkan kartu acak ke list
            GameObject card = cards[randomIndex] as GameObject;
            cardDeck.Add(card);

            // Menandai indeks yang sudah terpilih
            selectedIndices.Add(randomIndex);
        }
    }

    public List<GameObject> GetInventoryCards()
    {
        return cardDeck;
    }
    public void AddingCardReward()
    {
        //Menambah 1 kartu random ke list kartu inventory
    }
}
