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

    [SerializeField]
    Button GetButton;
    bool empty; 
    
    int rewardsItemcount = 0;

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
        rewardItem.itemCode = 0;
        rewardItem.count = 0;
        Debug.Log(rewardItem.itemCode + " " + rewardItem.count);
        rewardsItemcount = 0;

        for (int i =0; i< bm.enemySquad[bm.currentSquad].enemy.Count; i++)
        {
            rewardItem = bm.enemySquad[bm.currentSquad].enemy[i].GenerateItem();

            if(rewardItem.itemCode != 0)
            {
                rewardItems[rewardsItemcount].SetItemInfo(itm.itemDataTable.GetItem(rewardItem.itemCode));
                rewardItems[rewardsItemcount].count = rewardItem.count;
                rewardsItemcount++;
            }
        }
        if (rewardsItemcount == 0)
            GenerateItem();
        
    }
    public void InitRewards()
    {
        for (int i = 0; i < rewardItems.Length; i++)
            rewardItems[i].SetItemInfo(itm.itemDataTable.GetItem(0));

    }
    public void BattleWin()
    {
        GenerateItem();
        SetOnOffPanel(true);
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

        itm.CountItem();
        OnNoButton();
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
                            reward.count = 0;
                        }
                        else
                        {
                            itm.inventory[i].count = itm.inventory[i].maxcount;
                            reward.count -= (itm.inventory[i].maxcount - itm.inventory[i].count);
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
            if(rewardItems[i].itemCode != -1)
            {
                rewardItems[i].gameObject.SetActive(onoff);
                rewardCount[i].gameObject.SetActive(onoff);
                rewardCount[i].text = rewardItems[i].count.ToString();
            }
            else
            {
                rewardItems[i].gameObject.SetActive(false);
                rewardCount[i].gameObject.SetActive(false);
            }
        }
        if (rewardsItemcount == 0)
        {
            GetButton.gameObject.SetActive(false);
        }
        else
            GetButton.gameObject.SetActive(true);
        rewardPanel.gameObject.SetActive(onoff);
    }
}
