using UnityEngine;
using UnityEngine.SceneManagement;

public class NodeCode : MonoBehaviour
{
    [SerializeField] public Sprite[] nodeSprites;
    [SerializeField] public int nodeTypeRandom;
    [SerializeField] public string battleScene = "BattleScene";
    [SerializeField] public string restAreaScene = "RestAreaScene";
    [SerializeField] public string bossFightScene = "BossFightScene";
    [SerializeField] public GameObject finalBoss;
  

    [SerializeField] public NodeCode neighborNode1, neighborNode2, nextNode1, nextNode2, nextNode3;
    [SerializeField] public bool hasLoadedScene;


    // warna asli
    public Color originalColor;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //hasLoadedScene = true;
        nodeTypeRandom = Random.Range(2, 4);
        //pengecualian final node
        if (finalBoss)
        {
            GetComponent<NodeCode>().nodeTypeRandom = 9;
        }

        // Change the sprite based on nodeTypeRandom
        if (nodeTypeRandom == 2)
        {
            spriteRenderer.sprite = nodeSprites[0];
        }
        else if (nodeTypeRandom == 3)
        {
            spriteRenderer.sprite = nodeSprites[1];
        }
        else
        {
            spriteRenderer.sprite = nodeSprites[2];
        }


        // Simpan warna asli
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    public void OnMouseDown()
    {
        if (hasLoadedScene) // cek apakah node sudah terpilih dan scene sudah dimuat
        {
            if (nodeTypeRandom == 2)
            {
                SceneManager.LoadScene(battleScene, LoadSceneMode.Single);

            }
            else if (nodeTypeRandom == 3)
            {
                SceneManager.LoadScene(restAreaScene, LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene(bossFightScene, LoadSceneMode.Single);
            }

            // Node stay color
            GetComponent<SpriteRenderer>().color = Color.black;


            hasLoadedScene = false;
            //disini tetangga dan next
            DisableNeighborNodes(neighborNode1);
            DisableNeighborNodes(neighborNode2);
            EnableNextNodes(nextNode1);
            EnableNextNodes(nextNode2);
            EnableNextNodes(nextNode3);
            //Invoke("ReturnToPreviousScene", 5f);
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
}