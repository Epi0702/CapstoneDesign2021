﻿using System.Collections;
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
    public override void TransformPosition() //for monster
    {
        switch (position)
        {
            case CharacterPosition.Fourth:
                this.transform.localPosition = new Vector3(7.49f, 0.5f, 0);
                break;
            case CharacterPosition.Third:
                this.transform.localPosition = new Vector3(5.83f, 0.5f, 0);
                break;
            case CharacterPosition.Second:
                this.transform.localPosition = new Vector3(4.17f, 0.5f, 0);
                break;
            case CharacterPosition.First:
                this.transform.localPosition = new Vector3(2.51f, 0.5f, 0);
                break;
            default:
                break;
        }
    }

    void SetStatsByDifficulty()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                {
                    name = "약한 박쥐";
                    stats.maxHp = 10;
                    stats.currentHp = stats.maxHp;
                    stats. attackDamage= 20;
                    stats.defense = 5;
                    stats.speed = 15;
                }
                break;
            case Difficulty.Normal:
                {
                    name = "박쥐"; 
                    stats.maxHp = 25;
                    stats.currentHp = stats.maxHp;
                    stats.attackDamage = 20;
                    stats.defense = 5;
                    stats.speed = 6;
                }
                break;
            case Difficulty.Hard:
                {
                    name = "강한 박쥐";
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
        Debug.Log("Bat HP : " + stats.currentHp);
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

    
    public override void Skill01()      //후방 두명 공격
    {
        Player tempplayer = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.player;
        int damage = stats.attackDamage;//데미지 설정

        if (IsTargetAlive(tempplayer.playerCharacter[2]))
        {
            //tempplayer.playerCharacter[2].OnDamage(this.attackDamage);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetEntity.Add(tempplayer.playerCharacter[2]);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.damageList.Add(damage);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.DamageInputEvent += DamageSet;
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().AnimationManager.monsterattackerAnimEvent += MonsterAnimate;
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().AnimationManager.monsterAct = MonsterActing.Attack;
        }
        if (IsTargetAlive(tempplayer.playerCharacter[3]))
        {
            //tempplayer.playerCharacter[3].OnDamage(this.attackDamage);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetEntity.Add(tempplayer.playerCharacter[3]);
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
