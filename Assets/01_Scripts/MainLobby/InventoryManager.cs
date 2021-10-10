using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    GameObject Content;

    List<InvenItem> invenitem = new List<InvenItem>();
    int count;

    // Start is called before the first frame update
    void Start()
    {
        InitInventory();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void InitInventory()
    {
        for (int i = 0; i < 50; i++)
        {
            CreateNullItem();
        }
        for (int i = 0; i < invenitem.Count; i++)
        {
            invenitem[i].gameObject.SetActive(false);
        }
        UpdateInventory();
    }
    public void UpdateInventory()
    {
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
            for (int i = SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().InSafe.Count; i < SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().InSafe.Count+plusnum; i++)
            {
                invenitem[i].gameObject.SetActive(true);
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
        Debug.Log("CreateNullItem called!!");
        MainLobbyItem none = new MainLobbyItem();
        none.InitItemInfo();

        InvenItem temp;
        temp = Instantiate(Resources.Load<InvenItem>("Prefabs/Shop/InvenItem"));
        temp.transform.parent = Content.transform;
        temp.SetItemInfo(none);
        temp.index = count;
        count++;
        invenitem.Add(temp);
        Debug.Log(invenitem.Count);

    }
    public void SellItem(InvenItem item)
    {
        item.iteminfo.MinusItem();
        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().CheckInvenZero();
        UpdateInventory();
    }
}
