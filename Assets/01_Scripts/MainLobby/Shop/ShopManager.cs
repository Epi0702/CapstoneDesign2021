using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    ScrollContanetsCount buyItem;
    [SerializeField]
    ScrollRect sellItem;

    List<SellItemSlot> buyItems = new List<SellItemSlot>();

    [SerializeField]
    GameObject DescriptionPanel;
    [SerializeField]
    Text Description;

    [SerializeField]
    Button SellButton;
    [SerializeField]
    InventoryManager ivManager;

    public int sellItemCount;

    // Start is called before the first frame update
    void Start()
    {
        InitShopBuy();
        SetShopBuy(4);
        SetShopBuy(5);
        SetShopBuy(6);
        SetShopBuy(7);
        SetShopBuy(8);
    }

    // Update is called once per frame
    void Update()
    {
        if (ivManager.selectedItem_index != -1)
            ActiveSellButton(true);
        else
            ActiveSellButton(false);
    }

    public void InitShopBuy()
    {
        buyItems.Clear();
    }
    public void SetShopBuy(int itemIndex)
    {
        Debug.Log(SystemManager.Instance.ItemTable.GetItem(itemIndex).itemCode);
        SellItemSlot temp;
        temp = Instantiate(Resources.Load<SellItemSlot>("Prefabs/Shop/Slot_001"));
        temp.transform.parent = buyItem.transform;
        temp.SetItem(SystemManager.Instance.ItemTable.GetItem(itemIndex));

        buyItems.Add(temp);
    }
    public void AddShopLIst()
    {

    }
    public void ActiveDescriptionPanel(string description)
    {
        DescriptionPanel.SetActive(true);
        Description.text = description;
    }
    public void ActiveSellButton(bool ononff)
    {
        SellButton.gameObject.SetActive(ononff);
    }
    public void OnSellButton()
    {
        if (ivManager.invenitem[ivManager.selectedItem_index].iteminfo.count == 1)
        {
            ivManager.invenitem[ivManager.selectedItem_index].iteminfo.count -= 1;
            SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().InSafe[ivManager.selectedItem_index].count -= 1;
            SellButton.gameObject.SetActive(false);
        }
        else
        {
            ivManager.invenitem[ivManager.selectedItem_index].iteminfo.count -= 1;
            SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().InSafe[ivManager.selectedItem_index].count -= 1;
        }
        //if(ivManager.invenitem[ivManager.selectedItem_index].iteminfo.count == 0)
        //{
        //    ivManager.invenitem[ivManager.selectedItem_index].iteminfo.InitItemInfo();
        //}
        ivManager.UpdateInventory();
    }
    public void OnBuyButton()
    {

    }
}
