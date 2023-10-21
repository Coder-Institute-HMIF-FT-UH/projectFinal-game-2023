using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NodeCode : MonoBehaviour
{
    [SerializeField] public int nodeTypeRandom;
    [SerializeField] public string battleScene = "BattleScene";
    [SerializeField] public string restAreaScene = "RestAreaScene";
    private bool hasLoadedScene = false;

    // scene sebelumnya
    private string previousScene;

    // warna asli
    private Color originalColor;


    void Start()
    {
        nodeTypeRandom = Random.Range(2, 4);

        // Warna Node
        if (PlayerPrefs.GetInt(name) == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.green; 
        }

        // Simpan warna asli
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    void OnMouseDown()
    {
        if (!hasLoadedScene)
        {
            // Simpan adegan sebelumnya
            previousScene = SceneManager.GetActiveScene().name;

            if (nodeTypeRandom == 2)
            {
                SceneManager.LoadScene(battleScene, LoadSceneMode.Single);
                hasLoadedScene = true;
            }
            else
            {
                SceneManager.LoadScene(restAreaScene, LoadSceneMode.Single);
                hasLoadedScene = true;
            }

            // Node stay color
            GetComponent<SpriteRenderer>().color = Color.black; 
            PlayerPrefs.SetInt(name, 1);

            // coba pindah otomatis ke adegan awal setelah 10 detik memilih node
            Invoke("ReturnToPreviousScene", 10);

        }
    }

    // Fungsi agar kita dapat kembali ke scane sebelumnya
    void ReturnToPreviousScene()
    {
        SceneManager.LoadScene(previousScene, LoadSceneMode.Single);

    }
}