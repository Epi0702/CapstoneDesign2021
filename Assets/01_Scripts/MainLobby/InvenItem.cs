using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InvenItem : MonoBehaviour
{
    [SerializeField]
    Image itemImg;
    [SerializeReference]
    TextMeshProUGUI itemCount;
    [SerializeField]
    Image SelectedFrame;
    public MainLobbyItem iteminfo;
    public int index;
    bool check;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        //SellItem();
        check = true;
    }
    public void SetImg()
    {
        itemImg.sprite = Resources.Load<Sprite>("Img/ItemImg/None");
    }
    public void SetItemInfo(MainLobbyItem item)
    {
        this.name = $"invItem_{Random.Range(0, 10000)}";
        MainLobbyItem temp = new MainLobbyItem();
        if (item.itemCode == -1)
        {
            itemCount.gameObject.SetActive(false);
        }
        else
        {

            temp.SetItemInfo(item);

            this.iteminfo = temp;
            itemCount.gameObject.SetActive(true);

            itemImg.sprite = Resources.Load<Sprite>(SystemManager.Instance.ItemTable.GetItem(item.itemCode).itemImgPath);
            itemCount.text = iteminfo.count.ToString();
        }

    }
    public void UpdateCount()
    {
        itemCount.text = iteminfo.count.ToString();
        if(iteminfo.count <= 0)
        {
            itemCount.gameObject.SetActive(false);
        }
    }
    public void SellItem()
    {
        Debug.Log(this.name + " " + this.GetType());
        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().InventoryManager.selectedItem_index = this.index;
    }
    public void SetFrameActive(bool onoff)
    {
        SelectedFrame.gameObject.SetActive(onoff);
    }
}
