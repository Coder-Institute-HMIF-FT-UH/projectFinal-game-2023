using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterId : MonoBehaviour
{
    public int selectedCharId;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
}
