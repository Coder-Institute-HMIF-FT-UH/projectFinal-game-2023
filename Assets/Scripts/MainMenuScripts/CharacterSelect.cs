using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public SceneMoving sceneMoving;
    private CharacterId characterid;

    private void Start()
    {
        characterid = GameObject.FindObjectOfType<CharacterId>();
        PlayerPrefs.DeleteKey("CameraPositionX"); //menghapus data camera dari maptraversing
    }
    public void selectchar(int choosenSelectedCharacter)
    {
        characterid.selectedCharId = choosenSelectedCharacter;
    }

    public void StartGamePreparation()
    {
        sceneMoving.LoadMapTraversingScene();
    }
}
