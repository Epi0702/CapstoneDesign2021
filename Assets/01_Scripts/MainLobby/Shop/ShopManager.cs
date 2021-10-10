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

    List<SellItemSlot> sellItems = new List<SellItemSlot>();

    [SerializeField]
    GameObject DescriptionPanel;
    [SerializeField]
    Text Description;

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
        
    }

    public void InitShopBuy()
    {
        sellItems.Clear();
    }
    public void SetShopBuy(int itemIndex)
    {
        Debug.Log(SystemManager.Instance.ItemTable.GetItem(itemIndex).itemCode);
        SellItemSlot temp;
        temp = Instantiate(Resources.Load<SellItemSlot>("Prefabs/Shop/Slot_001"));
        temp.transform.parent = buyItem.transform;
        temp.SetItem(SystemManager.Instance.ItemTable.GetItem(itemIndex));
        
    }
    public void AddShopLIst()
    {

    }
    public void ActiveDescriptionPanel(string description)
    {
        DescriptionPanel.SetActive(true);
        Description.text = description;
    }
}
