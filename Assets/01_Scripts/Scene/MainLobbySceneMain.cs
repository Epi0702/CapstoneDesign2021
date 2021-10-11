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
    public int gold;

    public List<SaveCharacter> partyCharacters = new List<SaveCharacter>();
    public List<SaveCharacter> allCharacters = new List<SaveCharacter>();

    public List<MainLobbyItem> inventory = new List<MainLobbyItem>();
    public List<MainLobbyItem> InSafe = new List<MainLobbyItem>();


    // Start is called before the first frame update
    protected override void OnAwake()
    {
        base.OnAwake();
    }
    protected override void OnStart()
    {
        base.OnStart();
        gold = DataController.Instance.gameData.gold;
        LoadInsafe(); 
        LoadAllCharacter();
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
}
