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

        maxHp = 20;
        currentHp = maxHp;

        attackDamage = 5;
        defense = 0;
        speed = 7;

        critical = 10;

        size = 1;
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
        Debug.Log("Zombie HP : " + currentHp);
    }
    public override void Attack()
    {
        base.Attack();
    }
    public override void Skill00()
    {
        Player tempplayer = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.player;
        bool check = false;
        while (!check)
        {
            int randtarget = UnityEngine.Random.Range(0, 4);
            if (tempplayer.playerCharacter[randtarget] != null && tempplayer.playerCharacter[randtarget] != dead)
            {
                tempplayer.playerCharacter[randtarget].OnDamage(this.attackDamage);
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetCharacter.Add(tempplayer.playerCharacter[randtarget]);
                Debug.Log("Target Set!!!");
                check = true;
            }
        }
    }

    public override void Skill01()      //전방 두명 공격
    {
        Player tempplayer = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.player;


        if (tempplayer.playerCharacter[0] != null || tempplayer.playerCharacter[0] != dead)
        {
            tempplayer.playerCharacter[0].OnDamage(this.attackDamage);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetCharacter.Add(tempplayer.playerCharacter[0]);
        }
        if (tempplayer.playerCharacter[1] != null || tempplayer.playerCharacter[1] != dead)
        {
            tempplayer.playerCharacter[1].OnDamage(this.attackDamage);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetCharacter.Add(tempplayer.playerCharacter[1]);
        }

    }

}
