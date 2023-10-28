using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    [SerializeField] public GameObject[] nodes;
    private static GameObject instance;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (instance == null)
            instance = gameObject;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        
    }
}
