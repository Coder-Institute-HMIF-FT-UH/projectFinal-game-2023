using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterId : MonoBehaviour
{
    public int selectedCharId;
    private static GameObject instance;
    private void Start()
    {
        if (instance == null)
        {
            instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Replace the old instance with the new one
            Destroy(instance);

            instance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
    }
}
