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
public struct RewardItem
{
    public int itemCode;
    public int count;
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
    public int maxcount;

    public bool isSetted = false;


    public bool skillSelected;               //스킬 선택
    public bool skillActive;               //스킬 발동
    public bool skillCancel;               //스킬 중복선택        스킬 발동하면 true됨
    public bool targetSet;                  //타겟 셋

    public Skill skill;
    Character selected_character;


    private void Awake()
    {
        Icon = transform.Find("Icon").gameObject;
        itemImage = Icon.GetComponent<SpriteRenderer>();

        skill = GetComponent<Skill>();
    }
    private void Start()
    {
    }
    public void Update()
    {

    }

    public void InitItem()
    {
        itemCode = 0;
        itemName = null;
        itemImage.sprite = Resources.Load<Sprite>("Img/itemImg/none_item");
        itemType = ItemType.None;
        owner = null;
        target = null;
        count = 0;

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
        maxcount = itemData.maxCount;

        isSetted = true;
    }
    public bool isNeedItemCount()
    {
        if (this.itemType == ItemType.Used || this.itemType == ItemType.Ingredient || this.itemType == ItemType.Gold)
            return true;
        else
            return false;
    }

    public void OnClickFunction()
    {
        switch (itemType)
        {
            case ItemType.None:
                NoneItemFunction();
                break;
            case ItemType.Used:
                UsedItemFuction();
                break;
            case ItemType.Ingredient:
                break;
            case ItemType.Equipment:
                break;
            case ItemType.Gold:
                GoldItemFunction();
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
    public void NoneItemFunction()
    {
        Debug.Log("Item Clicked!!");
        Invoke(itemFunction, 0);
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
    public void GoldItemFunction()
    {
        Debug.Log("돈이 최고야");
    }

    public void EventItemItemFunction()
    {
        Debug.Log("Item Clicked!!");
        Invoke(itemFunction, 0);
    }

    public void SkillFunction()
    {

        StopAllCoroutines();

        selected_character = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().selectedCharacter;
        Debug.Log("SKill Clicked!!");

        StartCoroutine("CheckSkillCancel");
        StartCoroutine(itemFunction);

    }
    void None()
    {
        Debug.Log("None Clikcked!!");
    }
    IEnumerator CheckSkillCancel()
    {
        while (skillSelected)
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
    public void DamageSet(LivingEntity character, int damage)
    {
        character.OnDamage(damage);
    }
    public void PlayerAnimate(Acting act)
    {
        selected_character.SetAnimation(act);
    }


    IEnumerator Knight01()
    {
        target = null;
        InitTarget();
        while (target == null)
        {

            yield return null;

            SetTarget();
        }
        if (target != null)
        {
            Debug.Log("Knight01 Active");
            //target.OnDamage(selected_character.stats.attackDamage);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetEntity.Add(target);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.damageList.Add(selected_character.stats.attackDamage);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.DamageInputEvent += DamageSet;
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().AnimationManager.attackerAnimEvent += PlayerAnimate;
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().AnimationManager.playerAct = Acting.Smash;
            //InitTarget();
            ActionEnd();
        }
        StopAllCoroutines();
        Debug.Log("SkillSuccess");
    }

    IEnumerator Fighter01()
    {
        target = null;
        InitTarget();
        while (target == null)
        {

            yield return null;

            SetTarget();
        }
        if (target != null)
        {
            Debug.Log("Fighter01 Active");
            //target.OnDamage(selected_character.stats.attackDamage);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetEntity.Add(target);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.damageList.Add(selected_character.stats.attackDamage);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.DamageInputEvent += DamageSet;
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().AnimationManager.attackerAnimEvent += PlayerAnimate;
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().AnimationManager.playerAct = Acting.Smash;
            //InitTarget();
            ActionEnd();
        }
        StopAllCoroutines();
        Debug.Log("SkillSuccess");


    }

}
