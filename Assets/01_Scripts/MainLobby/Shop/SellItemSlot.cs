using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SellItemSlot : MonoBehaviour
{
    [SerializeField]
    Image ItemImg;
    [SerializeField]
    Text itemName;
    [SerializeField]
    Text itemdes;
    [SerializeField]
    Text itemCount;
    [SerializeField]
    Image UnactiveBuy;

    public MainLobbyItem itemInfo;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetItem(ItemStruct itemData)
    {
        this.name = $"slot_{Random.Range(0, 10000)}";
        MainLobbyItem temp = new MainLobbyItem();

        temp.SetItemInfo(itemData);

        Debug.Log($"{this.name} : {itemData.itemCode}");

        this.itemInfo = new MainLobbyItem()
        {

            description = temp.description,
            itemCode = temp.itemCode,
            itemFunction = temp.itemFunction,
            itemName = temp.itemName,
            itemType = temp.itemType,
            maxcount = temp.maxcount,
            price = temp.price
        };


        itemInfo.count = this.itemInfo.maxcount;
        if (itemInfo.count > 0)
            UnactiveBuy.gameObject.SetActive(false);

        ItemImg.sprite = Resources.Load<Sprite>(itemData.itemImgPath);
        itemCount.text = (itemInfo.count.ToString() + " / " + itemInfo.maxcount);
        itemdes.text = itemInfo.price.ToString();
        itemName.text = itemInfo.itemName;
        Debug.Log(this.name + " "+itemInfo.count);
        Debug.Log(this.name + " "+itemInfo.maxcount);
    }

    public void ActiveDescription()
    {
        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().ShopManager.ActiveDescriptionPanel(itemInfo.description);
    }
    public void OnBuyButton()
    {
        if (itemInfo.count >= 1)
        {
            this.itemInfo.count -= 1;
            if (this.itemInfo.count == 0)
                UnactiveBuy.gameObject.SetActive(true);
        }
        MainLobbyItem temp = new MainLobbyItem();
        temp.SetItemInfo(this.itemInfo);
        temp.count = 1;


        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().AddInSafeItem(temp);
        Debug.Log("BUY!!");
        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().InventoryManager.UpdateInventory();
        UpdateCount();
    }
    public void UpdateCount()
    {
        itemCount.text = (itemInfo.count.ToString() + " / " + itemInfo.maxcount);
    }
}
