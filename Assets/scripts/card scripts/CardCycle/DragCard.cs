using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCard : MonoBehaviour
{
    private Vector3 startPos;
    private bool isBeingHeld = false;
    private Transform targetTransform; // Menyimpan referensi ke player/enemy yang menjadi target

    private Vector3 touchOffset;

    public void InitializeDrag()
    {
        // Set posisi awal saat kartu diambil
        startPos = transform.localPosition;
    }

    void Update()
    {
        if (isBeingHeld)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                // Adjust the card's position based on touch offset
                transform.localPosition = new Vector3(touchPos.x - touchOffset.x, touchPos.y - touchOffset.y, 0);
            }
        }
    }

    private void OnMouseDown()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch is within the collider bounds of the card
            if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(touch.position)))
            {
                Debug.Log("Touch Down");
                isBeingHeld = true;

                // Calculate touch offset to maintain the card's relative position to the touch
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                touchOffset = touchPos - transform.position;
            }
        }
    }

    private void OnMouseUp()
    {
        Debug.Log("Touch Up");
        isBeingHeld = false;

        // Kembalikan kartu ke posisi awal jika tidak ditarik ke target
        if (targetTransform != null && Vector3.Distance(transform.position, targetTransform.position) >= 1.0f)
        {
            transform.localPosition = startPos;
        }
    }

    public void SetTarget(Transform target)
    {
        targetTransform = target;
    }
}


/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCard : MonoBehaviour
{
    private Vector3 startPos;
    private bool isBeingHeld = false;
    private Transform targetTransform; // Menyimpan referensi ke player/enemy yang menjadi target

    public void InitializeDrag()
    {
        // Set posisi awal saat kartu diambil
        startPos = transform.localPosition;
    }

    void Update()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Down");
            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse Up");
        isBeingHeld = false;

        // Kembalikan kartu ke posisi awal jika tidak ditarik ke target
        if (targetTransform != null && Vector3.Distance(transform.position, targetTransform.position) >= 1.0f)
        {
            transform.localPosition = startPos;
        }
    }

    public void SetTarget(Transform target)
    {
        targetTransform = target;
    }
}
*/

/*
using UnityEngine;

public class DragCard : MonoBehaviour
{
    private Vector3 startPos;
    private bool isBeingHeld = false;
    private Transform currentTarget; // Menyimpan referensi ke player/enemy yang menjadi target
    private int originalSortingOrder;
    private SpriteRenderer spriteRenderer;

    public void InitializeDrag(Transform target)
    {
        // Set posisi awal saat kartu diambil
        startPos = transform.localPosition;
        currentTarget = target;
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSortingOrder = spriteRenderer.sortingOrder;
    }

    void Update()
    {
        if (isBeingHeld)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            // Kartu selalu berada di atas elemen lainnya
            spriteRenderer.sortingOrder = originalSortingOrder + 1;

            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Down");
            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        Debug.Log("Mouse Up");
        isBeingHeld = false;

        // Kembalikan kartu ke posisi awal jika tidak ditarik ke target
        if (currentTarget != null && Vector3.Distance(transform.position, currentTarget.position) >= 1.0f)
        {
            transform.localPosition = startPos;
        }

        // Reset sorting order
        spriteRenderer.sortingOrder = originalSortingOrder;
    }

    public void SetTarget(Transform target)
    {
        currentTarget = target;
    }
}
*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private Transform parentToReturnTo;
    private bool isBeingHeld = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
        startPosition = transform.position;
        parentToReturnTo = transform.parent;
        transform.SetParent(transform.parent.parent); // Membuat objek kartu berada di atas elemen lain
        GetComponent<CanvasGroup>().blocksRaycasts = false; // Mencegah kartu menghalangi raycast
        isBeingHeld = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Drag");
        transform.SetParent(parentToReturnTo);
        transform.position = startPosition;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        isBeingHeld = false;
    }
}

*/

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCard : MonoBehaviour
{
    private float startPosX;
    private float startPostY;
    private bool isBeingHeld = false;

    void Update()
    {
        if(isBeingHeld == true)
        {
            vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToworldPoint(mousePos);

            this. myCardPrefab.transform.localPosition= new Vector3(mousePos.x - startPosX, mousePos.y - startPostY, 0);
        }
    }

    private void OnMouseDown()
    {
        if(Input.GetMouseButtonDown(0))
        {
            vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
*/

/*using UnityEngine;
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