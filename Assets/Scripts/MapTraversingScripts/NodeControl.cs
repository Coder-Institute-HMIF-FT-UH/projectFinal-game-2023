/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    [SerializeField] public GameObject[] nodes;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }
}
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    [SerializeField] public GameObject[] nodes;

    // var u/mengecek apakah node dalam satu kolom sudah dipilih
    public static bool isNodeSelectedInColumn = false;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (!isNodeSelectedInColumn)
        {
            // set variabel isNodeSelectedInColumn menjadi true setelah node dipilih
            isNodeSelectedInColumn = true;
        }
    }
    void ReturnToPreviousScene()
    {
        // set variabel isNodeSelectedInColumn menjadi false setelah kembali ke scane sebelumnya
        isNodeSelectedInColumn = false;
    }
}
