/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool isDragging = false;
    private Vector2 startPosition;
    private GameObject deck;

    private void Start()
    {
        // Temukan objek "Deck" dalam permainan
        deck = GameObject.Find("Deck");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;

        // Periksa apakah kartu harus dikembalikan ke deck
        if (!IsDroppedOnValidArea())
        {
            ReturnToDeck();
        }
        else
        {
            // Hancurkan kartu saat di-drop ke area yang valid
            Destroy(gameObject);
        }
    }

   private bool IsDroppedOnValidArea()
{
    // Misalnya, jika kartu di-drop di atas area pemain (Player Area) dengan tag "PlayerArea"
    if (transform.parent != null && transform.parent.CompareTag("PlayerArea"))
    {
        return true;
    }

    // Jika kartu di-drop di area lain yang dianggap valid, tambahkan logika validasi di sini

    return false; // Kartu tidak di-drop di area yang valid
}

    private void ReturnToDeck()
    {
        gameObject.SetActive(false);
        deck.GetComponent<Decks>().ReturnToDeck(gameObject);
    }
}
*/