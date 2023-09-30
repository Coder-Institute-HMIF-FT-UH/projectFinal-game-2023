/*using UnityEngine;

public class HandcardToDeckManager : MonoBehaviour
{
    public GameObject handcard; // Prefab kartu tangan
    public GameObject deck; // GameObject yang merepresentasikan tumpukan deck

    private GameObject draggedCard;
    private bool isDragging = false;
    private float dragTimer = 0f; // Untuk mengontrol proses drag-and-drop.
    private float maxDragTime = 4f; // Waktu maksimum sebelum kartu otomatis dipindahkan ke deck.

    private void Update()
    {
        if (isDragging)
        {
            dragTimer += Time.deltaTime;

            if (dragTimer >= maxDragTime)
            {
                MoveCardToDeck(draggedCard);
            }
        }
    }

    public void StartDrag(GameObject myCardPrefab)
    {
        draggedCard = Instantiate(myCardPrefab); // Buat salinan kartu yang akan di-drag.
        isDragging = true;
        dragTimer = 0f;
    }

    public void EndDrag()
    {
        isDragging = false;
    }

    public void DropCardOnPlayerArea()
    {
        if (draggedCard != null)
        {
            //tambahan

            Destroy(draggedCard); // Hapus kartu yang sedang di-drag.
            EndDrag();
        }
    }

    public void DropCardOnEnemyArea()
    {
        if (draggedCard != null)
        {
            //

            Destroy(draggedCard); 
            EndDrag();
        }
    }

    private void MoveCardToDeck(GameObject card)
    {
        card.transform.SetParent(deck.transform);
        card.SetActive(false);
    }
}

*/


/*using UnityEngine;

public class HandcardToDeckManager : MonoBehaviour
{
    public GameObject handcard;
    public GameObject deck;

    private GameObject draggedCard;
    private bool isDragging = false;
    private float dragTimer = 0f; //ntuk mengontrol proses drag-and-drop. 
    private float maxDragTime = 4f; //waktu maksimum sebelum kartu otomatis dipindahkan ke deck.

    private void Update()
    //Jika kartu sedang ditarik, dragTimer akan terus bertambah. Jika dragTimer melebihi maxDragTime, kartu akan dipindahkan ke deck.
    {
        if (isDragging)
        {
            dragTimer += Time.deltaTime;

            if (dragTimer >= maxDragTime)
            {
                MoveCardToDeck(draggedCard);
            }
        }
    }

    public void StartDrag(GameObject myCardPrefab)
    {
        draggedCard =myCardPrefab;
        isDragging = true;
        dragTimer = 0f;
    }

    public void EndDrag()
    {
        isDragging = false;
    }

    public void DropCardOnPlayerArea()
    {
        if (draggedCard != null)
        {
            // + Implementasikan pemindahan ke area player

            MoveCardToDeck(draggedCard);
            EndDrag();
        }
    }

    public void DropCardOnEnemyArea()
    {
        if (draggedCard != null)
        {
            // + Implementasikan pemindahan ke area enemy
            MoveCardToDeck(draggedCard);
            EndDrag();
        }
    }

    private void MoveCardToDeck(GameObject card)
    {
        card.transform.SetParent(deck.transform);
        card.SetActive(false);
    }
}
*/



/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCard : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    private static readonly Vector3 handPosition = new Vector3(-4f, -20f, 0f);

    public bool IsDragging
    {
        get { return isDragging; }
    }

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            transform.position = new Vector3(newPosition.x, newPosition.y, 0f);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;

        if (!IsOverHand())
        {
            ReturnToHand();
        }
    }

    private bool IsOverHand()
    {
        float minX = handPosition.x - 1f;
        float maxX = handPosition.x + 1f;
        float minY = handPosition.y - 1f;
        float maxY = handPosition.y + 1f;

        Vector3 cardPosition = transform.position;

        return (cardPosition.x >= minX && cardPosition.x <= maxX &&
                cardPosition.y >= minY && cardPosition.y <= maxY);
    }

    private void ReturnToHand()
    {
        transform.position = handPosition;
    }
}

*/