using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningCondition : MonoBehaviour
{
    public Transform parentGameObject; // Assign the parent object in the Unity Inspector
    public GameObject winningPanel; // Assign the winning panel in the Unity Inspector
    public StartingCards inventoryCardScripts;

    private int childCount; // Store the initial child count

    private void Start()
    {
        inventoryCardScripts = GameObject.FindObjectOfType<StartingCards>();
        // Get the initial child count
        childCount = parentGameObject.childCount;

        // Subscribe to the OnDestroy event of each child object
        foreach (Transform child in parentGameObject)
        {
            if (child != null)
            {
                var childDestroyListener = child.gameObject.AddComponent<ChildDestroyListener>();
                childDestroyListener.OnChildDestroyed += CheckForWin;
            }
        }
    }

    // This method is called when a child object gets destroyed
    private void CheckForWin()
    {
        childCount--; // Decrease the child count when a child is destroyed

        // Check if all children are destroyed
        if (childCount == 0)
        {
            // Activate the winning panel
            winningPanel.SetActive(true);
            inventoryCardScripts.AddingCardReward();
        }
    }
}
