using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None = 0,
    Used = 1,           //사용식 ex.포션
    Ingredient = 2,     //재료 ex철?
    Equipment = 3,      //장비
    Gold = 4,           //돈
    EventItem = 5,      //열쇠 등 이벤트 해결용 아이템
    Skill = 10,         //스킬
}
public class Item : MonoBehaviour
{
    public int itemCode = -1;        
    public string itemName;             //아이템 이름
    public SpriteRenderer itemImage;    //아이템 이미지
    public ItemType itemType;
    public string description;
    public string itemFunction;


    public Character owner;             //사용 캐릭터
    public Monster target;              //타켓 몬스터
    public int count;

    public bool isSetted = false;

    private void Start()
    {
        itemImage = GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        
    }

    public void InitItem()
    {
        itemCode = -1;
        itemName = null;
        itemImage.sprite = null;
        itemType = ItemType.None;
        owner = null;
        target = null;
        count = -1;

        isSetted = false;
    }
    public void SetItemInfo(ItemStruct itemData)
    {
        itemCode = itemData.itemCode;
        itemName = itemData.itemName;
        itemImage.sprite = Resources.Load<Sprite>(itemData.itemImgPath);
        itemType = (ItemType)itemData.itemType;
        description = itemData.description;
        itemFunction = itemData.functionName;


        if (isNeedItemCount())
            count = 1;

        isSetted = true;
    }
    bool isNeedItemCount()
    {
        if (this.itemType == ItemType.Used || this.itemType == ItemType.Ingredient || this.itemType == ItemType.EventItem)
            return true;
        else
            return false;
    }
    public void OnClickFunction()
    {
        Debug.Log("Clicked!!");
        Invoke(itemFunction,0);
    }
    public void temp()
    {

    }
}
