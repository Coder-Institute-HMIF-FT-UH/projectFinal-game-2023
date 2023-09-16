//drawpool
using UnityEngine;
using System.Collections.Generic;

public class DrawpoolToHandcardManager : MonoBehaviour
{
    public GameObject drawpool;
    public GameObject handcard;
    public GameObject myCardPrefab; // nama prefab sesuai dengan prefab card
    public int totalCards = 50;
    public int cardsInHand = 5;

    private List<GameObject> drawpoolCards = new List<GameObject>();

    private void Start()
    {
        InitializeDrawpool();
    }

    private void InitializeDrawpool()
    {
        for (int i = 0; i < totalCards; i++)
        {
            int randomCost = Random.Range(1, 4); // Acak cost antara 1 hingga 3
            GameObject newCard = Instantiate(myCardPrefab); // Menggunakan prefab kartu 
            // Menggunakan metode SetCost pada MyCard
            newCard.GetComponent<MyCard>().SetCost(randomCost);

            newCard.transform.SetParent(drawpool.transform);
            newCard.SetActive(false);
            drawpoolCards.Add(newCard);
        }

        // Setelah menginisialisasi drawpool, pindahkan kartu ke handcard
        MoveCardsToHand();
    }

    private void MoveCardsToHand()
    {
        for (int i = 0; i < cardsInHand; i++)
        {
            if (drawpoolCards.Count == 0)
                break;

            GameObject cardToMove = drawpoolCards[0];
            // mengambil kartu pertama dan menggerakkannya ke tangan pemain 
            drawpoolCards.RemoveAt(0);

            cardToMove.transform.SetParent(handcard.transform);
            cardToMove.SetActive(true);
        }
    }
}



/*
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    public GameObject drawpool; // GameObject untuk drawpool
    public GameObject handcard; // GameObject untuk handcard

    public GameObject cardPrefab; // Prefab untuk kartu (membuat kartu prefab terlebih dahulu)
    public int totalCards = 50; // Jumlah total kartu
    public int cardsInHand = 5; // Jumlah kartu yang akan pindah ke handcard setiap iterasi
    public float delayBetweenIterations = 2f; // Delay antara iterasi (2 detik)

    private List<GameObject> drawpoolCards = new List<GameObject>();

    private void Start()
    {
        // Inisialisasi drawpool dengan kartu-kartu awal
        InitializeDrawpool();
        
        // Mulai Coroutine untuk menggerakkan kartu secara otomatis
        StartCoroutine(MoveCardsToHand());
    }

    private void InitializeDrawpool()
    {
        // membuat kartu-kartu awal di drawpool secara acak
        for (int i = 0; i < totalCards; i++)
        {
            // Random cost antara 1 dan 3
            int randomCost = Random.Range(1, 4);

            // Buat kartu dengan cost yang telah diacak
            GameObject newCard = Instantiate(cardPrefab);
            newCard.GetComponent<Card>().SetCost(randomCost);

            // Tambahkan kartu ke drawpool dan nonaktifkan
            newCard.transform.SetParent(drawpool.transform);
            newCard.SetActive(false);
            drawpoolCards.Add(newCard);
        }
    }

    private IEnumerator MoveCardsToHand()
    {
        yield return new WaitForSeconds(delayBetweenIterations);

        // Pindahkan kartu ke handcard secara otomatis
        for (int i = 0; i < cardsInHand; i++)
        {
            if (drawpoolCards.Count == 0)
                break;

            GameObject cardToMove = drawpoolCards[0];
            drawpoolCards.RemoveAt(0);

            // Atur parent kartu ke handcard
            cardToMove.transform.SetParent(handcard.transform);

            // Aktifkan kartu di handcard
            cardToMove.SetActive(true);

            yield return new WaitForSeconds(delayBetweenIterations);
        }
    }
}
*/

/*Drawpool
using System.Collections.Generic;
using UnityEngine;

public class DrawCard : MonoBehaviour
{
    public GameObject cardPrefab; // Prefab kartu
    private List<int> drawPool = new List<int>();
    private List<GameObject> hand = new List<GameObject>();

    private bool gameStarted = false; // Menandakan apakah permainan sudah dimulai

    // Tentukan posisi dan ukuran tangan kartu
    public float handPosX = -4f;
    public float handPosY = -20f;
    public float handPosZ = 0f;
    public float width = 1f; // Lebar kartu
    public float height = 1f; // Tinggi kartu

    // Posisi awal kartu di draw pool (di luar layar)
    public float drawPoolPosX = -195f;
    public float drawPoolPosY = -65f;
    public float drawPoolPosZ = 0f;

    private void Start()
    {
        // Membuat DrawPool dengan 50 kartu
        for (int i = 0; i < 50; i++)
        {
            int cost = Random.Range(1, 4); // Biaya antara 1 hingga 3
            drawPool.Add(cost);
        }

        // Shuffle DrawPool 
        ShuffleDrawPool();

        // Menempatkan kartu di draw pool (di luar layar)
        for (int i = 0; i < drawPool.Count; i++)
        {
            GameObject cardObject = Instantiate(cardPrefab);
            cardObject.transform.position = new Vector3(drawPoolPosX, drawPoolPosY, drawPoolPosZ);
            hand.Add(cardObject);
        }
    }

    private void Update()
    {
        // Cek apakah permainan sudah dimulai
        if (!gameStarted)
        {
            int cardsToDraw = Mathf.Min(5, drawPool.Count); // Mengambil maksimal 5 kartu atau sebanyak yang tersedia
            for (int i = 0; i < cardsToDraw; i++)
            {
                if (drawPool.Count > 0)
                {
                    int randomIndex = Random.Range(0, drawPool.Count);
                    GameObject cardObject = hand[i];
                    CardsDraw cardsDraw = cardObject.GetComponent<CardsDraw>();
                    int cardCost = drawPool[randomIndex];
                    cardsDraw.SetCost(cardCost); // Set biaya kartu sesuai yang diambil dari drawPool

                    // Set posisi kartu di tangan pemain
                    cardObject.transform.position = new Vector3(handPosX + i * width, handPosY, handPosZ);

                    // Hapus kartu dari draw pool
                    drawPool.RemoveAt(randomIndex);
                }
            }

            // Menandakan bahwa permainan telah dimulai
            gameStarted = true;
        }
    }

    private void ShuffleDrawPool()
    {
        int n = drawPool.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int value = drawPool[k];
            drawPool[k] = drawPool[n];
            drawPool[n] = value;
        }
    }
}
*/