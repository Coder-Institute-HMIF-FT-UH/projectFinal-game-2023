/*using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject[] myCardPrefab; // 5 kartu
    public GameObject[] Player;
    public GameObject[] Enemie;
    public float jarak;

    private Vector3[] initialCardPositions; // Simpan posisi awal

    void Start()
    {
        // Inisialisasi array initialCardPositions dengan posisi awal myCardPrefabs
        initialCardPositions = new Vector3[myCardPrefab.Length];
        for (int i = 0; i < myCardPrefab.Length; i++)
        {
            initialCardPositions[i] = myCardPrefab[i].transform.localPosition;
        }
    }

    public void ItemDrag(int number)
    {
        myCardPrefab[number].transform.position = Input.mousePosition;
    }

    public void MyCardPrefabEndDrag(int number)
    {
        float jarakKePlayer = Vector3.Distance(myCardPrefab[number].transform.localPosition, Player[number].transform.localPosition);
        float jarakKeEnemy = Vector3.Distance(myCardPrefab[number].transform.localPosition, Enemie[number].transform.localPosition);

        if (jarakKePlayer < jarak)
        {
            myCardPrefab[number].transform.localPosition = initialCardPositions[number];
        }
        else if (jarakKeEnemy < jarak)
        {
            myCardPrefab[number].transform.localPosition = initialCardPositions[number];
        }
        else
        {
            // Tentukan apakah kartu harus ditempatkan bersama "Players" atau "Enemies" berdasarkan kondisi tertentu
            // Sebagai contoh, Anda dapat memeriksa flag boolean atau logika permainan lainnya
            bool tempatkanDenganPlayer = true; // Gantilah ini dengan kondisi sesungguhnya Anda

            if (tempatkanDenganPlayer)
            {
                myCardPrefab[number].transform.localPosition = Player[number].transform.localPosition;
            }
            else
            {
                myCardPrefab[number].transform.localPosition = Enemie[number].transform.localPosition;
            }
        }
    }
}
*/

/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    public GameObject handcard;
    public GameObject deck;

    private GameObject draggedCard;
    private bool isDragging = false;
    private float dragTimer = 0f; // untuk mengontrol proses drag-and-drop.
    private float maxDragTime = 4f; // waktu maksimum sebelum kartu otomatis dipindahkan ke deck.

    public GameObject[] myCardPrefab; // 5 kartu
    public GameObject[] Player;
    public GameObject[] Enemie;
    private Vector3[] initialCardPositions; // Simpan posisi awal
    public float jarak;

    void Start()
    {
        // Inisialisasi array initialCardPositions dengan posisi awal myCardPrefabs
        initialCardPositions = new Vector3[myCardPrefab.Length];
        for (int i = 0; i < myCardPrefab.Length; i++)
        {
            initialCardPositions[i] = myCardPrefab[i].transform.localPosition;
        }
    }

    void Update()
    {
        // Anda dapat menambahkan logika pembaruan yang diperlukan di sini
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
        draggedCard = myCardPrefab;
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

    public void ItemDrag(int number)
    {
        myCardPrefab[number].transform.position = Input.mousePosition;
    }

    public void MyCardPrefabEndDrag(int number)
    {
        float jarakKePlayer = Vector3.Distance(myCardPrefab[number].transform.localPosition, Player[number].transform.localPosition);
        float jarakKeEnemy = Vector3.Distance(myCardPrefab[number].transform.localPosition, Enemie[number].transform.localPosition);

        if (jarakKePlayer < jarak)
        {
            myCardPrefab[number].transform.localPosition = initialCardPositions[number];
        }
        else if (jarakKeEnemy < jarak)
        {
            myCardPrefab[number].transform.localPosition = initialCardPositions[number];
        }
        else
        {
            // Tentukan apakah kartu harus ditempatkan bersama "Players" atau "Enemies" berdasarkan kondisi tertentu
            // Sebagai contoh, Anda dapat memeriksa flag boolean atau logika permainan lainnya
            bool tempatkanDenganPlayer = true; // Gantilah ini dengan kondisi sesungguhnya Anda

            if (tempatkanDenganPlayer)
            {
                myCardPrefab[number].transform.localPosition = Player[number].transform.localPosition;
            }
            else
            {
                myCardPrefab[number].transform.localPosition = Enemie[number].transform.localPosition;
            }
        }
    }
}

*/
