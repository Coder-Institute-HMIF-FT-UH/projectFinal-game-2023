/*using System.Collections.Generic;
using UnityEngine;

public class Decks : MonoBehaviour
{
    public List<GameObject> drawPool = new List<GameObject>();
    public List<GameObject> handPool = new List<GameObject>();
    public List<GameObject> cardTypes = new List<GameObject>();
    private List<GameObject> deck = new List<GameObject>();


    private void Start()
    {
       //DrawToHand();
       InitializeDeck();
    }

    public void DrawToHand()
    {
       /* if (drawPoolCard < 5)
        {
           //Draw pool = Discard pool 
           
        }
        else
        {
            //Ambil 5 kartu random,Taruh ke handPool

        }
        
    }
    public void RemainingCardInHand()
    {
        //Semua Card di hand pool,masuk ke discard

    }


    public void InitializeDeck()
    {
        deck.Clear();

        foreach (GameObject cardType in cardTypes)
        {
            // Tambahkan kartu dari setiap jenis ke deck
            for (int i = 0; i < 5; i++)
            {
                GameObject newCard = Instantiate(cardType);
                newCard.SetActive(false); // Nonaktifkan kartu saat pertama kali dibuat
                deck.Add(newCard);
            }
        }
    }

    public List<GameObject> DrawCards(int count)
    {
        List<GameObject> drawnCards = new List<GameObject>();

        for (int i = 0; i < count; i++)
        {
            if (deck.Count > 0)
            {
                int randomIndex = Random.Range(0, deck.Count);
                GameObject drawnCard = deck[randomIndex];
                deck.RemoveAt(randomIndex);
                drawnCards.Add(drawnCard);

                // Setelah menggambar kartu, aktifkan timer untuk menghilangkan kartu setelah 3 detik
                Invoke("HideCard", 3f);
            }
            else
            {
                Debug.LogWarning("Deck is empty.");
                break; // Keluar dari loop jika deck kosong
            }
        }

        return drawnCards;
    }

    public void ReturnToDeck(GameObject card)
    {
        // Implementasikan logika untuk mengembalikan kartu ke deck di sini.
        card.transform.position = new Vector3(0f, 0f, 0f); // Atur ke posisi awal atau luar layar
        card.SetActive(false);
        deck.Add(card);
    }

    // Metode ini akan dipanggil setelah 3 detik untuk menghilangkan kartu
    private void HideCard()
    {
        if (deck.Count > 0)
        {
            int randomIndex = Random.Range(0, deck.Count);
            GameObject cardToHide = deck[randomIndex];
            cardToHide.SetActive(false);
            ReturnToDeck(cardToHide);
        }
    }
}
*/