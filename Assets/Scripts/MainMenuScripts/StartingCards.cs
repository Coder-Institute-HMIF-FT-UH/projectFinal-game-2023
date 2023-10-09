using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCards : MonoBehaviour
{
    [SerializeField] public List<GameObject> cardDeck; 
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartingDeckInit();
    }


    void Update()
    {
        
    }

    public void StartingDeckInit()
    {
        //ambil 5 kartu dari folder Resource/Cards/Hasanuddin terus kasih masuk ke list
    }
}
