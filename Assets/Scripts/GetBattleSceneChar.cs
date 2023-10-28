using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBattleSceneChar : MonoBehaviour
{
    private CharacterId characterid;
    [SerializeField] private List<HeroId> heroIds; 

    private void Start()
    {
        characterid = GameObject.FindObjectOfType<CharacterId>();
        foreach (HeroId heroid in heroIds)
        {
            if (heroid.idHero == characterid.selectedCharId)
            {
                heroid.gameObject.SetActive(true);
                break;
            }
        }
    }
}
