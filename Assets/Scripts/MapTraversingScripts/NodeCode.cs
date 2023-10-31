using UnityEngine;
using UnityEngine.SceneManagement;

public class NodeCode : MonoBehaviour
{
    [SerializeField] public Sprite[] nodeSprites;
    [SerializeField] public int nodeTypeRandom;
    [SerializeField] public string battleScene00 = "BattleScene00";
    [SerializeField] public string battleScene01 = "BattleScene01";
    [SerializeField] public string battleScene02 = "BattleScene02";
    [SerializeField] public string battleScene10 = "BattleScene10";
    [SerializeField] public string battleScene11 = "BattleScene11";
    [SerializeField] public string battleScene12 = "BattleScene12";
    [SerializeField] public string battleScene20 = "BattleScene20";
    [SerializeField] public string battleScene21 = "BattleScene21";
    [SerializeField] public string battleScene22 = "BattleScene22";
    [SerializeField] public string restAreaScene = "RestAreaScene";
    [SerializeField] public string bossFightScene = "BossFightScene";
    [SerializeField] public GameObject finalBoss, potentialRestArea1, potentialRestArea2;
    

    [SerializeField] public NodeCode neighborNode1, neighborNode2, nextNode1, nextNode2, nextNode3;
    [SerializeField] public bool hasLoadedScene;


    // warna asli
    public Color originalColor;
    private SpriteRenderer spriteRenderer;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        //nodeTypeRandom = Random.Range(2, 4);
        ////pengecualian final node
        //if (finalBoss)
        //{
        //    GetComponent<NodeCode>().nodeTypeRandom = 9;
        //}

        //// Change the sprite based on nodeTypeRandom
        //if (nodeTypeRandom == 2)
        //{
        //    spriteRenderer.sprite = nodeSprites[0];
        //}
        //else if (nodeTypeRandom == 3)
        //{
        //    spriteRenderer.sprite = nodeSprites[1];
        //}
        //else
        //{
        //    spriteRenderer.sprite = nodeSprites[2];
        //}
        if (potentialRestArea1)
        {
            nodeTypeRandom = 5;
            if (nodeTypeRandom == 4)
            {
                spriteRenderer.sprite = nodeSprites[0];
            }
            else if (nodeTypeRandom == 5)
            {
                spriteRenderer.sprite = nodeSprites[1];
            }
        }
        if (potentialRestArea2)
        {
            nodeTypeRandom = 5;
            if (nodeTypeRandom == 4)
            {
                spriteRenderer.sprite = nodeSprites[0];
            }
            else if (nodeTypeRandom == 5)
            {
                spriteRenderer.sprite = nodeSprites[1];
            }
        }

        // Simpan warna asli
        originalColor = GetComponent<SpriteRenderer>().color;
    }

    public void OnMouseDown()
    {
        if (hasLoadedScene) // cek apakah node sudah terpilih dan scene sudah dimuat
        {
            switch (nodeTypeRandom)
            {
                case 0:
                    SceneManager.LoadScene(battleScene00, LoadSceneMode.Single);
                    break;
                case 1:
                    SceneManager.LoadScene(battleScene01, LoadSceneMode.Single);
                    break;
                case 2:
                    SceneManager.LoadScene(battleScene02, LoadSceneMode.Single);
                    break;
                case 3:
                    SceneManager.LoadScene(battleScene10, LoadSceneMode.Single);
                    break;
                case 4:
                    SceneManager.LoadScene(battleScene11, LoadSceneMode.Single);
                    break;
                case 5:
                    SceneManager.LoadScene(restAreaScene, LoadSceneMode.Single);
                    break;
                case 6:
                    SceneManager.LoadScene(battleScene12, LoadSceneMode.Single);
                    break;
                case 7:
                    SceneManager.LoadScene(battleScene20, LoadSceneMode.Single);
                    break;
                case 8:
                    SceneManager.LoadScene(battleScene21, LoadSceneMode.Single);
                    break;
                case 9:
                    SceneManager.LoadScene(battleScene22, LoadSceneMode.Single);
                    break;
                default:
                    SceneManager.LoadScene(bossFightScene, LoadSceneMode.Single);
                    break;
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
            nextNode.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void DisableNeighborNodes(NodeCode neighborNode)
    {
        if (neighborNode != null)
        {
            neighborNode.hasLoadedScene = false;
            neighborNode.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f);
        }
    }
}