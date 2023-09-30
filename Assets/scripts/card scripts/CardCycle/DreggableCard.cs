/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableCard : MonoBehaviour
{
    private Vector3 mousePositionOffset;
    private Camera mainCamera; // Tambahkan referensi ke kamera

    private void Start()
    {
        // Dapatkan referensi ke kamera utama (pastikan kamera ini ada dalam scene)
        mainCamera = Camera.main;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Ganti "camera" menjadi "mainCamera" untuk merujuk ke kamera utama
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        // Dapatkan offset antara posisi kartu dan posisi mouse saat ini
        mousePositionOffset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        // Perbarui posisi kartu berdasarkan pergerakan mouse
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }
}

*/

    /*

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
        // dapat menambahkan logika pembaruan yang diperlukan di sini
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
using UnityEngine.EventSystems;

public class DreggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private bool isDragging = false;
    private Vector2 startPosition;
    private Transform initialParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isDragging)
        {
            isDragging = true;
            startPosition = transform.position;
            initialParent = transform.parent;
            transform.SetParent(transform.parent.parent); // Mendorong objek ke atas untuk menempatkan di atas elemen lain
            GetComponent<CanvasGroup>().blocksRaycasts = false; // Menonaktifkan raycast agar objek tidak menghalangi input lain
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            isDragging = false;
            transform.SetParent(initialParent); // Mengembalikan objek ke parent awal
            transform.position = startPosition;
            GetComponent<CanvasGroup>().blocksRaycasts = true; // Mengaktifkan kembali raycast

            // Tambahkan logika penanganan saat objek di-drop di sini
            if (IsDroppedOnValidArea(eventData.pointerEnter))
            {
                HandleDrop();
            }
        }
    }

    private bool IsDroppedOnValidArea(GameObject dropArea)
    {
        // Tambahkan logika validasi di sini berdasarkan objek tempat jatuhnya objek
        // Misalnya, Anda dapat memeriksa tag atau komponen tertentu pada objek dropArea
        return true; // Gantilah dengan logika validasi yang sesuai
    }

    private void HandleDrop()
    {
        // Tambahkan logika penanganan objek yang di-drop di sini
        // Misalnya, Anda dapat mengaktifkan atau menghancurkan objek, atau melakukan tindakan lainnya
        // Anda juga dapat memindahkan objek ke posisi tertentu atau melibatkan mekanik permainan lainnya
    }
}
*/