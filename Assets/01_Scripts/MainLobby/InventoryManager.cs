using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    GameObject Content;
    public List<InvenItem> invenitem = new List<InvenItem>();


    int itemcount;

    public int selectedItem_index;
    // Start is called before the first frame update
    void Start()
    {
        InitInventory();
        selectedItem_index = -1;
        Debug.Log(selectedItem_index);
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedItem_index != -1)
            SetSelectedItem();
    }
    public void InitInventory()
    {
        itemcount = 0;
        for (int i = 0; i < 50; i++)
        {
            CreateNullItem();
            itemcount++;
        }
        for (int i = 0; i < invenitem.Count; i++)
        {
            invenitem[i].gameObject.SetActive(false);
        }
        UpdateInventory();
    }
    public void UpdateInventory()
    {
        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().CheckInvenZero();

        int plusnum;
        for (int i = 0; i < invenitem.Count; i++)
        {
            invenitem[i].gameObject.SetActive(false);
        }

        plusnum = 5 - (SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().InSafe.Count % 5);


        for (int i = 0; i < SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().InSafe.Count; i++)
        {
            invenitem[i].gameObject.SetActive(true);
            invenitem[i].SetItemInfo(SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().InSafe[i]);
            invenitem[i].UpdateCount();
        }
        if (plusnum != 5)
            for (int i = SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().InSafe.Count; i < SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().InSafe.Count + plusnum; i++)
            {
                invenitem[i].iteminfo.InitItemInfo();
                invenitem[i].SetImg();
                invenitem[i].UpdateCount();
                invenitem[i].gameObject.SetActive(true);
            }
        Debug.Log(plusnum);
        if (selectedItem_index != -1)
        {
            if (invenitem[selectedItem_index].iteminfo.itemCode == -1)
            {
                selectedItem_index = -1;
                SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().ShopManager.ActiveSellButton(false);
            }
        }

    }
    public void CreateItem(MainLobbyItem item)
    {
        InvenItem temp;
        temp = Instantiate(Resources.Load<InvenItem>("Prefabs/Shop/InvenItem"));
        temp.transform.parent = Content.transform;
        temp.SetItemInfo(item);
        temp.UpdateCount();
        invenitem.Add(temp);
    }
    public void SetItem(MainLobbyItem item)
    {

    }
    public void CreateNullItem()
    {
        //Debug.Log("CreateNullItem called!!");
        MainLobbyItem none = new MainLobbyItem();
        none.InitItemInfo();

        InvenItem temp;
        temp = Instantiate(Resources.Load<InvenItem>("Prefabs/Shop/InvenItem"));
        temp.transform.parent = Content.transform;
        temp.SetItemInfo(none);
        temp.index = itemcount;
        invenitem.Add(temp);
        //Debug.Log(invenitem.Count);

    }
    public void SellItem(InvenItem item)
    {
        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().CheckInvenZero();
        UpdateInventory();
    }

    public void SetSelectedItem()
    {
        for (int i = 0; i < invenitem.Count; i++)
        {
            if (invenitem[i].index == selectedItem_index)
                invenitem[i].SetFrameActive(true);
            else
                invenitem[i].SetFrameActive(false);
        }
    }

}
