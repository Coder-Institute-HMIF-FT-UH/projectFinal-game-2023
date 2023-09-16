using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 startPosition;
    private GameObject deck;
    private int drawnCardCount = 0; // Menyimpan jumlah kartu yang telah ditarik

    public int cost; // Biaya kartu

    // Inisialisasi objek kartu untuk 5 jenis kartu
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;
    public GameObject dragArea; // Tempat kartu ditarik

    // Tentukan biaya (cost) untuk setiap kartu
    public int Card1Cost = 1; // Cost untuk Card1
    public int Card2Cost = 1; // Cost untuk Card2
    public int Card3Cost = 1; // Cost untuk Card3
    public int Card4Cost = 1; // Cost untuk Card4
    public int Card5Cost = 1; // Cost untuk Card5

    private void Start()
    {
        // Temukan objek "Deck" dalam permainan
        deck = GameObject.Find("Deck");
    }

    public void OnClick()
    {
        // Cek apakah sudah mencapai batas 5 kartu
        if (drawnCardCount < 5)
        {
            // Daftar GameObject untuk menampung kartu-kartu yang ditarik
            List<GameObject> drawnCards = new List<GameObject>();

            // Menggambar 5 kartu secara acak (ganti angka 5 sesuai kebutuhan)
            for (int i = 0; i < 5; i++)
            {
                // variabel untuk menyimpan GameObject kartu yang akan diinstansiasi
                GameObject newCard = null;

                // jenis kartu secara acak 
                int randomCardType = Random.Range(1, 6); // Mengasumsikan ada 5 jenis kartu (1-5)

                // Instansiasi kartu berdasarkan jenis yang dipilih
                switch (randomCardType)
                {
                    case 1:
                        if (Card1Cost > 0)
                        {
                            newCard = Instantiate(Card1, Vector3.zero, Quaternion.identity);
        
                        }
                        break;
                    case 2:
                        if (Card2Cost > 0)
                        {
                            newCard = Instantiate(Card2, Vector3.zero, Quaternion.identity);
                        }
                        break;
                    case 3:
                        if (Card3Cost > 0)
                        {
                            newCard = Instantiate(Card3, Vector3.zero, Quaternion.identity);
                        }    
                        break;
                    case 4:
                        if (Card4Cost > 0)
                        {
                            newCard = Instantiate(Card4, Vector3.zero, Quaternion.identity);
                            
                        }
                        break;
                    case 5:
                        if (Card5Cost > 0)
                        {
                            newCard = Instantiate(Card5, Vector3.zero, Quaternion.identity);
                            
                        }
                        break;
                    default:
                        break;
                }

                if (newCard != null)
                {
                    // Tambahkan kartu yang diinstansiasi ke daftar drawnCards
                    drawnCards.Add(newCard);
                }
            }
                }
    }
}
/*
        Tempatkan kartu-kartu yang ditarik di dalam objek baru (dragArea)
            foreach (var drawnCard in drawnCards)
            {
                drawnCard.transform.SetParent(dragArea.transform, false);
                drawnCard.SetActive(true); // Mengaktifkan kartu yang ditarik
            }

            // Menambahkan 1 ke drawnCardCount setelah menggambar kartu
            drawnCardCount += 1;
        }


    // Fungsi ini bisa digunakan untuk menghapus kartu setelah digunakan
    public void UseCard()
    {
        // Hapus kartu dari permainan
        Destroy(gameObject);

        // Kurangi jumlah kartu yang ditarik
        drawnCardCount -= 1;
    }
}
*/