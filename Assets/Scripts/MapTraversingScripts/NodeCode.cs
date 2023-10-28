using UnityEngine;
using UnityEngine.SceneManagement;

public class NodeCode : MonoBehaviour
{
    [SerializeField] public int nodeTypeRandom;
    [SerializeField] public string battleScene = "BattleScene";
    [SerializeField] public string restAreaScene = "RestAreaScene";
  

    [SerializeField] public NodeCode neighborNode1, neighborNode2, nextNode1, nextNode2, nextNode3;
    [SerializeField] public bool hasLoadedScene;

    // scene sebelumnya
    private string previousScene;

    // warna asli
    public Color originalColor;


    void Start()
    {
        //hasLoadedScene = true;
        nodeTypeRandom = Random.Range(2, 4);

        // Warna Node
        if (PlayerPrefs.GetInt(name) == 1)
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }

        // Simpan warna asli
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    public void OnMouseDown()
    {
        if (hasLoadedScene) // cek apakah node sudah terpilih dan scene sudah dimuat
        {
            // Simpan adegan sebelumnya
            previousScene = SceneManager.GetActiveScene().name;

            if (nodeTypeRandom == 2)
            {
                SceneManager.LoadScene(battleScene, LoadSceneMode.Single);

            }
            else
            {
                SceneManager.LoadScene(restAreaScene, LoadSceneMode.Single);

            }

            // Node stay color
            GetComponent<SpriteRenderer>().color = Color.black;
            PlayerPrefs.SetInt(name, 1);


            hasLoadedScene = false;
            //disini tetangga dan next
            DisableNeighborNodes(neighborNode1);
            DisableNeighborNodes(neighborNode2);
            EnableNextNodes(nextNode1);
            EnableNextNodes(nextNode2);
            EnableNextNodes(nextNode3);
            Invoke("ReturnToPreviousScene", 5f);
        }
    }

    //function untuk enable dan disable node
    public void EnableNextNodes(NodeCode nextNode)
    {
        if (nextNode != null)
        {
            nextNode.hasLoadedScene = true;
        }
    }

    public void DisableNeighborNodes(NodeCode neighborNode)
    {
        if (neighborNode != null)
        {
            neighborNode.hasLoadedScene = false;
        }
    }

    // Fungsi agar kita dapat kembali ke scane sebelumnya
    private void ReturnToPreviousScene()
    {
        SceneManager.LoadScene(previousScene, LoadSceneMode.Single);
    }
}