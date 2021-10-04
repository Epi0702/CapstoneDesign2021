using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Monster
{


    // Start is called before the first frame update
    private void Awake()
    {
        Setup();
    }
    private void Start()
    {

    }
    void Update()
    {

    }
    public override void Setup()
    {
        base.Setup();

        //maxHp = 20;
        //currentHp = maxHp;

        //attackDamage = 20;
        //defense = 0;
        //speed = 7;

        //critical = 10;

        //size = 1;
    }
    void SetStatsByDifficulty()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                {
                    stats.maxHp = 10;
                    stats.currentHp = stats.maxHp;
                    stats.attackDamage = 20;
                    stats.defense = 5;
                    stats.speed = 5;
                }
                break;
            case Difficulty.Normal:
                {
                    stats.maxHp = 25;
                    stats.currentHp = stats.maxHp;
                    stats.attackDamage = 20;
                    stats.defense = 5;
                    stats.speed = 6;
                }
                break;
            case Difficulty.Hard:
                {
                    stats.maxHp = 30;
                    stats.currentHp = stats.maxHp;
                    stats.attackDamage = 20;
                    stats.defense = 5;
                    stats.speed = 7;
                }
                break;
            default:
                break;
        }
    }
    public override void SetDifficulty(Difficulty dif)
    {
        this.difficulty = dif;
        SetStatsByDifficulty();
    }
    public override void SetPositionData(int pos)
    {
        base.SetPositionData(pos);
    }
    public override void TransformPosition()
    {
        base.TransformPosition();
    }

    public void OnDamageEvent()
    {

    }
    public override void Die()
    {
        base.Die();
    }

    public void Test()
    {
        Debug.Log("Zombie HP : " + stats.currentHp);
    }
    public override void Attack()
    {
        base.Attack();
    }
    public override void Skill00()
    {
        Player tempplayer = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.player;
        int damage = stats.attackDamage;//데미지 설정
        bool check = false;
        while (!check)
        {
            int randtarget = UnityEngine.Random.Range(0, 4);
            if (tempplayer.playerCharacter[randtarget] != null && tempplayer.playerCharacter[randtarget] != dead)
            {
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetEntity.Add(tempplayer.playerCharacter[randtarget]);
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.damageList.Add(damage);
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.DamageInputEvent += DamageSet;
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().AnimationManager.monsterattackerAnimEvent += MonsterAnimate;
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().AnimationManager.monsterAct = MonsterActing.Attack;
                check = true;
            }
        }
    }

    public override void Skill01()      //전방 두명 공격
    {
        Player tempplayer = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.player;
        int damage = stats.attackDamage;//데미지 설정

        if (IsTargetAlive(tempplayer.playerCharacter[0]))
        {
            //tempplayer.playerCharacter[2].OnDamage(this.attackDamage);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetEntity.Add(tempplayer.playerCharacter[0]);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.damageList.Add(damage);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.DamageInputEvent += DamageSet;
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().AnimationManager.monsterattackerAnimEvent += MonsterAnimate;
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().AnimationManager.monsterAct = MonsterActing.Attack;
        }
        if (IsTargetAlive(tempplayer.playerCharacter[1]))
        {
            //tempplayer.playerCharacter[3].OnDamage(this.attackDamage);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetEntity.Add(tempplayer.playerCharacter[1]);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.damageList.Add(damage);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.DamageInputEvent += DamageSet; 
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().AnimationManager.monsterattackerAnimEvent += MonsterAnimate;
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().AnimationManager.monsterAct = MonsterActing.Attack;
        }
    }

    public bool IsTargetAlive(LivingEntity character)
    {
        if (character != null || character != dead)
            return true;
        else
            return false;
    }
    public void DamageSet(LivingEntity character, int damage)
    {
        character.OnDamage(damage);
    }


}
