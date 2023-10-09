using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCode : MonoBehaviour
{
    [SerializeField] public int nodeTypeRandom;
    
    void Start()
    {
        nodeTypeRandom = Random.Range(2, 4);
    }

    
    void Update()
    {
        if (nodeTypeRandom == 2)
        {
            //klo 2 dia pindah ke Battle
        }

        else
        {
            //klo 3 dia pindah ke restarea
        }
    }
}
