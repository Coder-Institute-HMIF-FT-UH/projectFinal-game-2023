//From Hand, Used Card go to Discard Deck//
//From Hand, Unused Card go to Discard Deck//
/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDiscardDeck : MonoBehaviour
{
    public GameObject hand; // Panel atau objek tempat kartu tangan pemain.

    private void Update()
    {
        // Menggunakan kartu dari tangan pemain jika pemain menekan tombol tertentu (misalnya, "Space").
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UseCardFromHand();
        }
    }

    void UseCardFromHand()
    {
        // Loop melalui semua kartu di tangan pemain.
        for (int i = 0; i < hand.transform.childCount; i++)
        {
            GameObject card = hand.transform.GetChild(i).gameObject.GetComponent<Card>();

            if (card != null)
            {
                card.UseCard(); // Panggil fungsi UseCard di komponen kartu.
            }
        }
    }
}
*/