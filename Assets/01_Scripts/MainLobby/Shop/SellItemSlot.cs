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


    public MainLobbyItem itemInfo;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        itemInfo = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetItem(ItemStruct itemData)
    {
        MainLobbyItem temp = new MainLobbyItem();

        temp.SetItemInfo(itemData);

        this.itemInfo = temp;
        count = itemInfo.maxcount;
        ItemImg.sprite = Resources.Load<Sprite>(itemData.itemImgPath);
        itemCount.text = (count.ToString() + " / " + itemInfo.maxcount);
        itemdes.text = itemInfo.price.ToString();
        itemName.text = itemInfo.itemName;
        Debug.Log(this.itemInfo.description);
    }
    public void ActiveDescription()
    {
        Debug.Log(this.itemInfo.description);

        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().ShopManager.ActiveDescriptionPanel(itemInfo.description);
    }
}
