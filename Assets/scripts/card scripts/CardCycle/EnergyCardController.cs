using UnityEngine;
using UnityEngine.UI;

public class EnergyCardController : MonoBehaviour
{
    public GameObject energyCardStack; // t4 tumpukan kartu energi
    public Sprite[] energyCardSprites; // Gambar kartu energi

    private Image stackImage;

    private void Start()
    {
        stackImage = energyCardStack.GetComponent<Image>();
    }

    public void ShowRandomEnergyStack()
    {
        if (energyCardSprites.Length > 0)
        {
            // Acak gambar kartu energi
            int randomIndex = Random.Range(0, energyCardSprites.Length);
            stackImage.sprite = energyCardSprites[randomIndex];//variasi visual yang berbeda untuk kartu energi

            // Aktifkan tampilan tumpukan kartu energi
            energyCardStack.SetActive(true);
        }
    }

    public void HideEnergyStack()
    {
        // Nonaktifkan tampilan tumpukan kartu energi
        energyCardStack.SetActive(false);
    }
}

