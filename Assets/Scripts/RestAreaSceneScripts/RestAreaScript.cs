using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestAreaScript : MonoBehaviour
{
    [SerializeField] public int pertambahanHP;

    public Player player;
    public SceneMoving sceneMovingScript;
    public StartingCards inventoryCardScripts;
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        inventoryCardScripts = GameObject.FindObjectOfType<StartingCards>();
    }

    public void Istirahat()
    {
        player.currentHealth += pertambahanHP;
        sceneMovingScript.LoadMapTraversingScene();
        inventoryCardScripts.AddingCardReward();
    }

    public void LanjutPerjalanan()
    {
        sceneMovingScript.LoadMapTraversingScene();
        inventoryCardScripts.AddingCardReward();
    }
}
