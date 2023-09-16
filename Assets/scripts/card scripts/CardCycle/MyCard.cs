using UnityEngine;

public class MyCard : MonoBehaviour
{
    public int cost; // Atribut cost kartu

    // Metode untuk mengatur cost kartu
    public void SetCost(int newCost)
    {
        cost = newCost;
    }
}


/*untuk player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int energyPlayer = 10;

    public void PlayCard(CardsDraw cardDraw)
    {
        int energyCost = cardDraw.CostEnergy;

        // apakah pemain memiliki cukup energi untuk memainkan kartu?
        if (energyPlayer >= energyCost)
        {
            energyPlayer -= energyCost;
            // Lakukan tindakan yang sesuai dengan memainkan kartu di sini
        }
        else
        {
            Debug.LogWarning("Energi pemain tidak cukup untuk memainkan kartu ini.");
            // menampilkan pesan kesalahan atau mengambil tindakan lain sesuai dengan kebijakan permainan Anda.
        }
    }
}
*/
