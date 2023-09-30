using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject characterA;
    public GameObject characterB;
    public GameObject characterC;
    public SceneMoving sceneMoving;

    public int selectedCharacter = 0;
    public void selectchar(int choosenSelectedCharacter)
    {
        selectedCharacter = choosenSelectedCharacter;
    }

    public void StartGamePreparation()
    {
        if (selectedCharacter == 0)
        {
            Destroy(characterB);
            Destroy(characterC);
        }
        else if (selectedCharacter == 1)
        {
            Destroy(characterA);
            Destroy(characterC);
        }
        else
        {
            Destroy(characterA);
            Destroy(characterB);
        }
        sceneMoving.LoadMapTraversingScene();
    }
}
