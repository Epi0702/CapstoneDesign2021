using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    TextMeshPro getGold;
    [SerializeField]
    TextMeshPro getExp;
    [SerializeField]
    GameObject Victory_Label;
    [SerializeField]
    GameObject Fail_Lable;
    [SerializeField]
    GameObject Panel;

    [SerializeField]
    ItemManager itmManager;

    int _getGold;
    int _getExp;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        Victory_Label.SetActive(false);
        Fail_Lable.SetActive(false);
        Panel.SetActive(false);
        _getGold = 0;
        _getExp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver(bool success)
    {
        SetPlayerPosition();       
        SumInvenGold();
        SumExp();
        getGold.text = _getGold.ToString();
        getExp.text = _getExp.ToString();

        Panel.SetActive(true);
        if (success)
        {          
            SetPlayerAnimation(Acting.Dance3);
            Victory_Label.SetActive(true);
        }
        else
        {
            SetPlayerAnimation(Acting.Sad);
            Fail_Lable.SetActive(true);
        }
    }
    //public void GameOver_F()
    //{
    //    SetPlayerPosition();
    //    SumInvenGold();
    //    SumExp();
    //}
    void SetPlayerPosition()
    {
        player = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.player;

        for(int i = 0; i< player.playerCharacter.Count; i++)
        {
            if (!player.playerCharacter[i].dead)
            {
                player.playerCharacter[i].transform.position = new Vector3(2.49f - (1.66f * i), -1f, 0);
                player.playerCharacter[i].renderer.sortingLayerName = "CreditPlayer";
            }
        }
            
    }
    void SetPlayerAnimation(Acting act)
    {
        for (int i = 0; i < player.playerCharacter.Count; i++)
        {
            if (!player.playerCharacter[i].dead)
            {
                player.playerCharacter[i].SetAnimation(act);
            }
        }
    }
    void SumInvenGold()
    {
        for(int i = 0; i < itmManager.inventory.Length; i++)
        {
            if (itmManager.inventory[i].itemType == ItemType.Gold)
                _getGold += itmManager.inventory[i].count;
        }
    }
    void SumExp()
    {
        Difficulty temp;
        temp = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().MapManager.mapDifficulty;

        switch (temp)
        {
            case Difficulty.Easy:
                _getExp = 10;
                break;
            case Difficulty.Normal:
                _getExp = 20;
                break;
            case Difficulty.Hard:
                _getExp = 30;
                break;
            default:
                break;
        }
        _getExp += SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.killCount;
    }
}
