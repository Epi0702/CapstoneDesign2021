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
    public ItemType itemType;
    public string description;
    public string itemFunction;

    public GameObject Icon;
    public SpriteRenderer itemImage;    //아이템 이미지


    public LivingEntity owner;             //사용 캐릭터
    public LivingEntity target;              //타켓 몬스터
    public int count;

    public bool isSetted = false;


    public bool skillSelected;               //스킬 선택
    public bool skillActive;               //스킬 발동
    public bool skillCancel;               //스킬 중복선택        스킬 발동하면 true됨
    public bool targetSet;                  //타겟 셋

    public SkillClick skillClick;

    private void Awake()
    {
        Icon = transform.Find("Icon").gameObject;
        itemImage = Icon.GetComponent<SpriteRenderer>();

        skillClick = GetComponent<SkillClick>();
    }
    private void Start()
    {
    }
    public void Update()
    {

    }

    public void InitItem()
    {
        itemCode = -1;
        itemName = null;
        itemImage.sprite = Resources.Load<Sprite>("Img/itemImg/colliderTest");
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
        switch (itemType)
        {
            case ItemType.None:
                break;
            case ItemType.Used:
                UsedItemFuction();
                break;
            case ItemType.Ingredient:
                break;
            case ItemType.Equipment:
                break;
            case ItemType.Gold:
                break;
            case ItemType.EventItem:
                break;
            case ItemType.Skill:
                SkillFunction();
                break;
            default:
                break;
        }

    }

    public void UsedItemFuction()
    {
        Debug.Log("Item Clicked!!");
        Invoke(itemFunction, 0);
    }

    public void IngredientItemFunction()
    {
        Debug.Log("Item Clicked!!");
        Invoke(itemFunction, 0);
    }

    public void EquipmentItemFunction()
    {
        Debug.Log("Item Clicked!!");
        Invoke(itemFunction, 0);
    }

    public void EventItemItemFunction()
    {
        Debug.Log("Item Clicked!!");
        Invoke(itemFunction, 0);
    }

    public void SkillFunction()
    {
        StopAllCoroutines();
        Debug.Log("SKill Clicked!!");

        StartCoroutine("CheckSkillCancel");
        StartCoroutine(itemFunction);

    }
    public void temp()
    {

    }
    IEnumerator CheckSkillCancel()
    {
        while(skillSelected)
        {
            //Debug.Log("Checking");
            yield return null;
        }
        StopAllCoroutines();
    }
    IEnumerator AttackTest()
    {
        Debug.Log("Coroutine 2");
        target = null;
        InitTarget();
        while (target == null)
        {

            yield return null;

            SetTarget();
        }
        if (target != null)
        {
            Debug.Log("Attack!!");
            target.OnDamage(10);
            //InitTarget();
            ActionEnd();
        }
        StopAllCoroutines();
        Debug.Log("SkillSuccess");
    }
    public void SetTarget()
    {
        target = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetMonster;
    }
    public void InitTarget()
    {
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetMonster = null;
    }
    public void ActionEnd()
    {
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.actionEnd = true;
    }

}
