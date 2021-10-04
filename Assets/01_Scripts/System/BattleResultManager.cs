using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleResultManager : MonoBehaviour
{
    [SerializeField]
    ItemManager itm;
    [SerializeField]
    BattleManager bm;
    public Item[] rewardItems;

    [SerializeField]
    Image rewardPanel;

    [SerializeField]
    Text[] rewardCount;
    bool empty;
    // Start is called before the first frame update
    void Start()
    {
        SetOnOffPanel(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateItem()
    {
        RewardItem rewardItem;
        for (int i =0; i< bm.enemySquad[bm.currentSquad].enemy.Count; i++)
        {
            rewardItem = bm.enemySquad[bm.currentSquad].enemy[i].GenerateItem();
            rewardItems[i].SetItemInfo(itm.itemDataTable.GetItem(rewardItem.itemCode));
            rewardItems[i].count = rewardItem.count;
        }
        
    }
    public void InitRewards()
    {
        for (int i = 0; i < rewardItems.Length; i++)
            rewardItems[i].SetItemInfo(itm.itemDataTable.GetItem(0));

    }
    public void BattleWin()
    {
        SetOnOffPanel(true);
        GenerateItem();
    }
    public void OnYesButton()
    {

    }
    public void OnNoButton()
    {
        SetOnOffPanel(false);
        InitRewards();
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().MapManager.BattleEndRoom();
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.SetCurrentRoom();
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.SetRelRoomButton();

    }
    public void OnGetButton()
    {
        for(int i = 0; i< rewardItems.Length; i++)
        {
            if(rewardItems[i].itemCode != 0)
            {
                GetRewardToInventory(rewardItems[i]);
            }
        }
        SetOnOffPanel(false);
        InitRewards();
        itm.CountItem();
    }
    public void GetRewardToInventory(Item reward)
    {
        for (int i = 0; i < itm.inventory.Length; i++)
        {
            if (reward.count > 0)
            {
                if (itm.inventory[i].itemCode == reward.itemCode)
                {
                    if (itm.inventory[i].count < itm.inventory[i].maxcount)
                    {
                        if (itm.inventory[i].maxcount - itm.inventory[i].count > reward.count)
                        {
                            itm.inventory[i].count += reward.count;
                        }
                        else
                        {
                            reward.count -= (itm.inventory[i].maxcount - itm.inventory[i].count);
                            itm.inventory[i].count = itm.inventory[i].maxcount;
                        }
                    }
                }
            }
        }
        for(int i = 0; i < itm.inventory.Length; i++)
        {
            if(reward.count > 0)
            {
                if(itm.inventory[i].itemCode == 0)
                {
                    itm.inventory[i].SetItemInfo(itm.itemDataTable.GetItem(reward.itemCode));
                    itm.inventory[i].count = reward.count;
                    reward.count = 0;
                }
            }
        }
    }

    public void SetOnOffPanel(bool onoff)
    {
        for(int i = 0; i< rewardItems.Length; i++)
        {
            rewardItems[i].gameObject.SetActive(onoff);
            rewardCount[i].gameObject.SetActive(onoff);
            rewardCount[i].text = rewardItems[i].count.ToString();
        }
        rewardPanel.gameObject.SetActive(onoff);
    }
}
