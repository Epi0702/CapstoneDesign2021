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
    public MainLobbyItem iteminfo;
    public int index;
    bool check;
    // Start is called before the first frame update
    void Start()
    {
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!check)
        {

            SellItem();
            check = true;
        }
    }
    public void SetItemInfo(MainLobbyItem item)
    {
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
    }
    public void SellItem()
    {
        if (Input.GetMouseButtonUp(1))
        {

                Debug.Log("sell");
                Debug.Log(index);
                //SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().InventoryManager.SellItem(this);
            
        }
    }
}
