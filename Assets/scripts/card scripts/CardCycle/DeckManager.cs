using UnityEngine;
using System.Collections.Generic;

public class DeckManager : MonoBehaviour
{
    public GameObject deck;
    public GameObject drawpool;
    public GameObject cardPrefab;
    public int totalCards = 50;

    private List<GameObject> deckCards = new List<GameObject>();

    private void Start()
    {
        InitializeDeck();
    }

    private void InitializeDeck()
    {
        // Inisialisasi deck dengan cards awal
        for (int i = 0; i < totalCards; i++)
        {
            int randomCost = Random.Range(1, 4);

            GameObject newCard = Instantiate(cardPrefab);
            newCard.GetComponent<MyCard>().SetCost(randomCost);

            newCard.transform.SetParent(deck.transform);
            newCard.SetActive(false);
            deckCards.Add(newCard);
        }
    }

    public void ReturnToDrawpool()
    {
        // Aktifkan kembali semua card di deck
        foreach (GameObject card in deckCards)
        {
            card.SetActive(true);
            card.transform.SetParent(drawpool.transform);
        }

        // Bersihkan daftar card di deck
        deckCards.Clear();
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardScripts; //  namespace yang digunakan oleh CardsDraw

public class Desk : MonoBehaviour
{
    private List<CardsDraw> cardsOnDesk = new List<CardsDraw>(); // List untuk menyimpan kartu di atas meja
    private float cardDropDelay = 5f; // Waktu penundaan sebelum kartu yang tidak digunakan dihapus dari meja

    private void Update()
    {
        // Cek kartu yang tidak digunakan dan hapus mereka setelah waktu tertentu
        StartCoroutine(CheckUnusedCards());
    }

    public void AddCardToDesk(CardsDraw card)
    {
        // + kartu ke list kartu di atas meja
        cardsOnDesk.Add(card);

        // Set posisi kartu di atas handplayer/meja kartu
        Vector3 deskPosition = transform.position;
        deskPosition.z = 0f; // Pastikan posisi di atas meja memiliki z = 0
        card.transform.position = deskPosition;
    }

    private IEnumerator CheckUnusedCards()
    {
        yield return new WaitForSeconds(cardDropDelay);

        // Mengecek kartu yang tidak sedang di-drag dan menghapusnya dari meja
        for (int i = cardsOnDesk.Count - 1; i >= 0; i--)
        {
            CardsDraw card = cardsOnDesk[i];

            // Jika kartu tidak sedang di-drag, hapus dari meja
            if (!card.IsDragging)
            {
                cardsOnDesk.RemoveAt(i);
                Destroy(card.gameObject);
            }
        }
    }
}
*/