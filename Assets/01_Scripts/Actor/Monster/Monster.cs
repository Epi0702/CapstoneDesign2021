using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Monster : LivingEntity
{
    protected GameObject monsterSprite;
    protected MonsterAnimation anim;

    protected Difficulty difficulty;

    protected Monster selected_monster;

    // Start is called before the first frame update
    void Awake()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void TransformPosition() //for monster
    {
        switch (position)
        {
            case CharacterPosition.Fourth:
                this.transform.localPosition = new Vector3(7.49f, -0.5f, 0);
                break;
            case CharacterPosition.Third:
                this.transform.localPosition = new Vector3(5.83f, -0.5f, 0);
                break;
            case CharacterPosition.Second:
                this.transform.localPosition = new Vector3(4.17f, -0.5f, 0);
                break;
            case CharacterPosition.First:
                this.transform.localPosition = new Vector3(2.51f, -0.5f, 0);
                break;
            default:
                break;
        }
    }
    public override void Setup()
    {
        base.Setup();
        this.isMonster = true;
        monsterSprite = transform.Find("Monster").gameObject;

        anim = monsterSprite.GetComponent<MonsterAnimation>();

    }
    public override void Die()
    {
        base.Die();
        StartCoroutine("DeadAnim");
    }
    IEnumerator DeadAnim()
    {
        anim.SetAnimation(MonsterActing.Die);
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
    public virtual void SetDifficulty(Difficulty dif)
    {

    }

    public override void OnDamage(int damage)
    {
        base.OnDamage(damage);
    }
    public override void Attack()
    {
        int randnum = UnityEngine.Random.Range(0, 4);
        selected_monster = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.selectedMonster;

        switch (randnum)
        {
            case 0:
                Skill00();
                break;
            case 1:
                Skill00();
                break;
            case 2:
                Skill01();
                break;
            case 3:
                Skill01();
                break;
        }
    }
    public void MonsterAnimate(MonsterActing act)
    {
        selected_monster.SetAnimation(act);
    }
    public virtual void Skill00()
    {

    }
    public virtual void Skill01()
    {

    }
    public virtual void Skill02()
    {

    }
    public virtual void Skill03()
    {

    }
    public void TestAnimation()
    {
        anim.Hurt();
    }
    public void TestAnimation2()
    {
        anim.Idle();
    }
    public override void SetAnimation(MonsterActing act)
    {
        anim.SetAnimation(act);
    }
    public virtual RewardItem GenerateItem()
    {
        int randnum = UnityEngine.Random.Range(0, 100);
        RewardItem rewardItem;
        if(randnum > 75)
        {
            rewardItem.itemCode = 1;
            rewardItem.count = 500;
        }
        else if(randnum > 50)
        {
            rewardItem.itemCode = 1;
            rewardItem.count = 750;
        }
        else if(randnum >25)
        {
            rewardItem.itemCode = 4;
            rewardItem.count = 1;
        }
        else
        {
            rewardItem.itemCode = 0;
            rewardItem.count = 0;

        }

        return rewardItem;
    }
}
