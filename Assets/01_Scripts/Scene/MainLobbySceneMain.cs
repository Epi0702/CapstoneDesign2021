using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[System.Serializable]
public class MainLobbyItem
{
    public int itemCode;
    public string itemName;             //아이템 이름
    public ItemType itemType = ItemType.None;
    public string description;
    public string itemFunction;
    public int price = 0;
    public int count = 0;
    public int maxcount;

    public void InitItemInfo()
    {
        itemCode = -1;
        itemName = " ";
        itemType = ItemType.None;
        description = " ";
        itemFunction = " ";
        maxcount = 0;
        count = 0;
        price = -1;
    }
    public void SetItemInfo(ItemStruct itemData)
    {
        itemCode = itemData.itemCode;
        itemName = itemData.itemName;
        itemType = (ItemType)itemData.itemType;
        description = itemData.description;
        itemFunction = itemData.functionName;
        maxcount = itemData.maxCount;
        price = itemData.price;
    }
    public void SetItemInfo(MainLobbyItem itemData)
    {
        itemCode = itemData.itemCode;
        itemName = itemData.itemName;
        itemType = itemData.itemType;
        description = itemData.description;
        itemFunction = itemData.itemFunction;
        maxcount = itemData.maxcount;
        count = itemData.count;
        price = itemData.price;
    }
    public void MinusItem()
    {
        count -= 1;
    }

}
[System.Serializable]
public enum Page
{
    None = 0,
    Shop = 1,
    Hero = 2,
    Inventory  =3,
}
public class MainLobbySceneMain : BaseSceneMain
{
    [SerializeField]
    LoadScene loadScene;
    public LoadScene LoadScene
    {
        get
        {
            return loadScene;
        }
    }
    [SerializeField]
    ShopManager shopManager;
    public ShopManager ShopManager
    {
        get
        {
            return shopManager;
        }
    }
    [SerializeField]
    InventoryManager inventoryManager;
    public InventoryManager InventoryManager
    {
        get
        {
            return inventoryManager;
        }
    }  
    [SerializeField]
    HeroCreator heroCreator;
    public HeroCreator HeroCreator
    {
        get
        {
            return heroCreator;
        }
    }   
    [SerializeField]
    HeroManager heroManager;
    public HeroManager HeroManager
    {
        get
        {
            return heroManager;
        }
    }



    public int gold;

    public List<SaveCharacter> partyCharacters = new List<SaveCharacter>();
    public List<SaveCharacter> allCharacters = new List<SaveCharacter>();

    public List<MainLobbyItem> inventory = new List<MainLobbyItem>();
    public List<MainLobbyItem> InSafe = new List<MainLobbyItem>();

    public GameObject[] pages;

    [SerializeField]
    GameObject Herolist;
    [SerializeField]
    GameObject HeroHireList;
    [SerializeField]
    GameObject BuyPanel;
    [SerializeField]
    GameObject SellPanel;

    // Start is called before the first frame update
    protected override void OnAwake()
    {
        base.OnAwake();
    }
    protected override void OnStart()
    {

        base.OnStart();

        InitMainLobby();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Test()
    {
        loadScene.gameObject.SetActive(true);
        loadScene.SceneLoader(3);
        //LoadScene.Instance.SceneLoader(SceneName.InGameScene);
    }
    void InitParty()
    {
        SaveCharacter temp = new SaveCharacter();
        temp.Init();
        partyCharacters.Add(temp);
    }
    void InitMainLobby()
    {
        InitPages();
        
        gold = DataController.Instance.gameData.gold;
        
        LoadInsafe();
        LoadAllCharacter();
        LoadInventory();

    }
    public void AddItem()
    {
        //MainLobbyItem temp = new MainLobbyItem();
        //temp.SetItemInfo(SystemManager.Instance.ItemTable.GetItem(4));
        //temp.count = 1;
        ////InSafe.Add(temp);
        //AddInSafeItem(temp);        
        for(int i = 0; i < InSafe.Count; i++)
        {
            Debug.Log(InSafe[i].itemName + " " + InSafe[i].count);
        }
    }
    public void AddInSafeItem(MainLobbyItem add)
    {

        for (int i = 0; i < InSafe.Count; i++)
        {
            if (add.count > 0)
            {
                if (InSafe[i].itemCode == add.itemCode)
                {
                    if (InSafe[i].count < InSafe[i].maxcount)
                    {
                        if (InSafe[i].maxcount - InSafe[i].count > add.count)
                        {
                            InSafe[i].count += add.count;
                            add.count = 0;
                        }
                        else
                        {
                            add.count -= (InSafe[i].maxcount - InSafe[i].count);
                            InSafe[i].count = InSafe[i].maxcount;
                        }
                    }
                }
            }
        }
        if (add.count > 0)
        {
            InSafe.Add(add);
        }
    }
    public void SaveInsafe()
    {
        SystemManager.Instance.JsonParse.SaveInSafeItem();
    }
    public void LoadInsafe()
    {
        InSafe.Clear();
        InSafe = SystemManager.Instance.JsonParse.LoadInSafeItem();
        //InventoryManager.UpdateInventory();
        for(int i = 0; i<InSafe.Count; i++)
        {
            InSafe[i].SetItemInfo(SystemManager.Instance.ItemTable.GetItem(InSafe[i].itemCode));
        }
        Debug.Log(InSafe[0].itemName);

    }
    public void LoadInventory()
    {
        inventory.Clear();
        inventory = SystemManager.Instance.JsonParse.LoadInvenItem();
        for (int i = 0; i < inventory.Count; i++)
        {
            inventory[i].SetItemInfo(SystemManager.Instance.ItemTable.GetItem(inventory[i].itemCode));
        }
        Debug.Log(inventory[0].itemName);
        Debug.Log(inventory[0].itemName);
    }
    public void LoadAllCharacter()
    {
        allCharacters.Clear();
        allCharacters = SystemManager.Instance.JsonParse.LoadAllCharacter();
        Debug.Log("Character Load!!");
    }
    public void CheckInvenZero()
    {
        for(int i = 0; i < InSafe.Count; i++)
        {
            if(InSafe[i].count == 0)
            {
                InSafe.RemoveAt(i);
            }
        }
    }
    public void InitPages()
    {
        for (int i = 1; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }
        Herolist.SetActive(false);
        SellPanel.SetActive(false);
        BuyPanel.SetActive(false);
        HeroHireList.SetActive(false);

    }
    public void SetPage(Page page)
    {
        switch (page)
        {
            case Page.None:
                InitPages();
                break;
            case Page.Shop:
                InitPages();
                pages[1].SetActive(true);
                BuyPanel.SetActive(true);
                inventoryManager.isShop = true;
                break;
            case Page.Hero:
                InitPages();
                pages[2].SetActive(true);
                Herolist.SetActive(true);
                break;
            case Page.Inventory:
                InitPages();
                pages[3].SetActive(true);
                SellPanel.SetActive(true);
                inventoryManager.isShop = false;
                break;
            default:
                InitPages();
                break;
        }
    }

    public void OnShop()
    {
        SetPage(Page.Shop);
    }   
    public void OnHero()
    {
        SetPage(Page.Hero);
    }   
    public void OnInven()
    {
        SetPage(Page.Inventory);
    }
    public void OnHome()
    {
        SetPage(Page.None);
    }
}
