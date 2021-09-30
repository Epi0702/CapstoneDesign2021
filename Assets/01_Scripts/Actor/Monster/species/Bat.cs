using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Monster
{
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

        //attackDamage = 5;
        //speed = 5;
        
    }

    void SetStatsByDifficulty()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                {
                    maxHp = 20;
                    currentHp = maxHp;
                    attackDamage = 20;
                    defense = 5;
                    speed = 5;
                }
                break;
            case Difficulty.Normal:
                {
                    maxHp = 25;
                    currentHp = maxHp;
                    attackDamage = 20;
                    defense = 5;
                    speed = 6;
                }
                break;
            case Difficulty.Hard:
                {
                    maxHp = 30;
                    currentHp = maxHp;
                    attackDamage = 20;
                    defense = 5;
                    speed = 7;
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



    public void OnDamageEvent()
    {

    }
    public override void Die()
    {
        base.Die();
        Debug.Log("Bat Die");
    }

    public void Test()
    {
        Debug.Log("Bat HP : " + currentHp);
    }

    public override void Attack()
    {
        base.Attack();
    }
    public override void Skill00()          //한명 공격
    {
        Player tempplayer = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.player;
        bool check = false;
        while (!check)
        {
            int randtarget = UnityEngine.Random.Range(0, 4);
            if (IsTargetAlive(tempplayer.playerCharacter[randtarget]))
            {
                tempplayer.playerCharacter[randtarget].OnDamage(this.attackDamage);
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetEntity.Add(tempplayer.playerCharacter[randtarget]);
                Debug.Log("Target Set!!!");
                check = true;
            }
        }
    }
    public override void Skill01()      //후방 두명 공격
    {
        Player tempplayer = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.player;
        int damage = attackDamage;//데미지 설정

        if (IsTargetAlive(tempplayer.playerCharacter[2]))
        {
            //tempplayer.playerCharacter[2].OnDamage(this.attackDamage);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetEntity.Add(tempplayer.playerCharacter[2]);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.damageList.Add(damage);
        }
        if (IsTargetAlive(tempplayer.playerCharacter[3]))
        {
            //tempplayer.playerCharacter[3].OnDamage(this.attackDamage);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetEntity.Add(tempplayer.playerCharacter[3]);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.damageList.Add(damage);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.DamageInputEvent += DamageSet;
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
     
    //public override void Skill01()      //후방 두명 공격
    //{
    //    Player tempplayer = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.player;


    //    if (tempplayer.playerCharacter[2] != null || tempplayer.playerCharacter[2] != dead)
    //    {
    //        tempplayer.playerCharacter[2].OnDamage(this.attackDamage);
    //        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetCharacter.Add(tempplayer.playerCharacter[2]);
    //    }
    //    if (tempplayer.playerCharacter[3] != null || tempplayer.playerCharacter[3] != dead)
    //    {
    //        tempplayer.playerCharacter[3].OnDamage(this.attackDamage);
    //        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetCharacter.Add(tempplayer.playerCharacter[3]);
    //    }

    //}
    public override void Skill02()
    {
        
    }
    public override void Skill03()
    {
        
    }
}
