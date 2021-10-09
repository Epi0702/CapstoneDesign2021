﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

enum BattleOrder
{
    None,
    TurnSet,
    DebuffSet,
    Action,
    ActionEnd,
    TurnEnd,
}
public class BattleManager : MonoBehaviour
{
    int turn;
    public bool isBattle;
    public bool turnEnd;
    public bool actionEnd;
    public bool isattacked;


    public Player player;

    public List<Squad> enemySquad = new List<Squad>();

    public List<LivingEntity> turnManager = new List<LivingEntity>();

    public int currentSquad;

    int attackCount;

    bool attackAnim;

    bool debugbool;

    public bool coroutineCheck;
    public bool coroutineCheck2;

   // public Character selectedCharacter;
    public Monster targetMonster;

    public Monster selectedMonster;


    public List<LivingEntity> targetEntity = new List<LivingEntity>();

    public List<int> damageList = new List<int>();
    bool isdamaged;

    public Action<LivingEntity, int> DamageInputEvent;

    [SerializeField]
    EnemyController enemyController;

    BattleOrder battleOrder;

    public bool playerSkillActive;

    [SerializeField]
    GameObject battleStartLogo;

    public MonsterInfoUI monsterinfoUI;
    public PlayerInfoUI playerinfoUI;

    [SerializeField]
    ItemManager itmManager;

    public int killCount;

    public Character selectedCharacter;

    void Awake()
    {


    }
    // Start is called before the first frame update
    void Start()
    {
        InitBattleManager();
        debugbool = false;

        monsterinfoUI.gameObject.SetActive(false);
        //SetSelectedFirst();
    }

    // Update is called once per frame
    void Update()
    {
        if(isBattle)
            Battle_V2();
    }
    public void SetUpSquadsInfo(List<Squad> list)
    {
        enemySquad = list;
    }
    public void InitSelTarget()
    {
        //selectedCharacter = null;
        targetMonster = null;
        selectedMonster = null;
        targetEntity.Clear();
        damageList.Clear();
        DamageInputEvent = null;
        Debug.Log("Target Init");
    }
    public void InitBattleManager()
    {
        battleStartLogo.SetActive(false);   
        isBattle = false;
        turn = 0;
        currentSquad = -1;
        killCount = 0;

        //selectedCharacter = null;
        InitSelTarget();
    }
    public void StartBattle(int currentRoomIndex)
    {
        Debug.Log("Battle Start!!");

        currentSquad = currentRoomIndex;


        turnEnd = false;
        actionEnd = false;
        isattacked = true;
        attackCount = -1;

        GetEnemyInfo();
        for (int i = 0; i < enemySquad.Count; i++)
        {
            if (enemySquad[i].roomNum == currentRoomIndex)
            {
                enemySquad[i].gameObject.SetActive(true);
                currentSquad = i;
            }
        }
        enemyController.SetSquad(enemySquad[currentSquad]);
        //isBattle = true;
        StartCoroutine("BattleStartDelay");
        battleOrder = BattleOrder.TurnSet;
    }
    public void TurnSet()
    {

        for (int i = 0; i < enemySquad[currentSquad].enemy.Count; i++)
        {
            if (!enemySquad[currentSquad].enemy[i].dead)
            {
                turnManager.Add(enemySquad[currentSquad].enemy[i]);
            }
        }
        for (int i = 0; i < player.playerCharacter.Count; i++)
        {
            if (!player.playerCharacter[i].dead)
                turnManager.Add(player.playerCharacter[i]);
        }
        turnManager.Sort(delegate (LivingEntity x, LivingEntity y)
        {
            return x.stats.speed.CompareTo(y.stats.speed);
        });
        turnManager.Reverse();
        turnEnd = false;
    }



    public void Battle_V2()
    {
        
        switch (battleOrder)
        {
            case BattleOrder.None:
                break;
            case BattleOrder.TurnSet:
                BattleOrder_TurnSet();
                break;
            case BattleOrder.DebuffSet:
                BattleOrder_DebuffSet();
                break;
            case BattleOrder.Action:
                BattleOrder_Action();
                break;
            case BattleOrder.ActionEnd:
                BattleOrder_ActionEnd();
                break;
            case BattleOrder.TurnEnd:
                BattleOrder_TurnEnd();
                break;
            default:
                Debug.LogError("BattleManager ERROR!!!!!");
                break;
        }
    }
    public void BattleOrder_TurnSet()
    {
        TurnSet();
        attackCount = 0;
        actionEnd = false;
        battleOrder = BattleOrder.DebuffSet;
    }
    public void BattleOrder_DebuffSet()
    {
        if (turnManager[attackCount].debuff.isBleeding)
        {
            turnManager[attackCount].BleedingActive();
            //애니메이션
            if(turnManager[attackCount].dead)
            {
                Debug.Log(turnManager[attackCount].GetType() + "(죽음) called!! ");
                battleOrder = BattleOrder.TurnEnd;
            }
            else if (turnManager[attackCount].debuff.isStruned)
            {
                turnManager[attackCount].SturnActive();
                //애니메이션
                battleOrder = BattleOrder.TurnEnd;
            }
            else
            {
                battleOrder = BattleOrder.Action;
            }
        }
        else
        {
            if (turnManager[attackCount].debuff.isStruned)
            {
                turnManager[attackCount].SturnActive();
                //애니메이션
                battleOrder = BattleOrder.TurnEnd;
            }
            else
            {
                battleOrder = BattleOrder.Action;
            }
        }


    }
    public void BattleOrder_Action()
    {
        if (!debugbool)
        {
            Debug.Log("Turn : " + turn);
            Debug.Log("ActionCount : " + attackCount + ", " + turnManager[attackCount].GetType() + " 행동!");
            debugbool = true;
        }

        if (turnManager[attackCount].dead)
        {
            Debug.Log(turnManager[attackCount].GetType() + "(죽음) called!! ");
            debugbool = false;
            battleOrder = BattleOrder.TurnEnd;
        }

        else if (turnManager[attackCount].isMonster == false)
        {

            playerSkillActive = true;
            PlayerSKillActive();
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().ItemManager.isSkillActive = true;
            /*
             * 현재 턴 캐릭터 설정, 스킬셋을 현재 캐릭터 스킬로 교체
             */
            selectedCharacter = (Character)turnManager[attackCount];
            //player.ActivePlayerIcon(true);
            SetSelectedPlayer();
        }
        else
        {
            //Debug.Log("Monster Turn");
            selectedMonster = (Monster)turnManager[attackCount];
            turnManager[attackCount].Attack();
            //Debug.Log(turnManager[attackCount].GetType() + " ATTACK!!");
            actionEnd = true;
        }

        if (actionEnd)
        {
            playerSkillActive = false;
            debugbool = false;
            attackAnim = false;
            coroutineCheck = false;
            coroutineCheck2 = false;
            PlayerSKillActive();
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().ItemManager.isSkillActive = false;

            battleOrder = BattleOrder.ActionEnd;
        }
    }
    public void BattleOrder_ActionEnd()
    {
        if (!debugbool)
        {
            Debug.Log("Battle Animation Play!!");
            Debug.Log("Animation Start!!");
            debugbool = true;
        }
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().ItemManager.SetSkillSelectedFrameAllOff();
        if (!attackAnim && !coroutineCheck)
        {
            if (turnManager[attackCount].isMonster == false)
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().AnimationManager.PlayerAttackMonster();
            else
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().AnimationManager.MonsterAtackPlayer();

            isdamaged = false;
        }

        if (coroutineCheck && coroutineCheck2)
        {
            if(!isdamaged)
            {
                isdamaged = true;

                Debug.Log("Damaged!!");
                for (int i = 0; i < targetEntity.Count; i++)
                {
                    targetEntity[i].GetDamage();
                }

            }

            //HP애니메이션
            StartCoroutine("HPBarAnitmationDelay");
        }

        if (attackAnim)
        {
            InitSelTarget();
            debugbool = false;

            battleOrder = BattleOrder.TurnEnd;
        }

    }
    public void BattleOrder_TurnEnd()
    {
        Debug.Log("Battle TurnEnd Phase!!");
        coroutineCheck = false;
        if (player.isAllDead())     //플레이어 전멸
        {
            //GameOver;
        }
        else if (enemySquad[currentSquad].isAllDead())   //플레이어 승리
        {
            BattleOver();
        }
        else
        {
            ActionEnd();
            actionEnd = false;
            if (turnEnd)
            {
                Debug.Log("turn end called");
                battleOrder = BattleOrder.TurnSet;
            }

            else
            {
                Debug.Log("action end called");
                battleOrder = BattleOrder.Action;
            }

        }

    }
    public void ActionEnd()
    {

        attackCount++;
        Debug.Log("actionphase end");

        TurnEnd(turnManager);
    }
    public void TurnEnd(List<LivingEntity> list)
    {
        if (attackCount >= list.Count)
        {

            //Debug.Log("Turn " + turn + " 종료");
            turn++;
            turnEnd = true;
            actionEnd = false;

            turnManager.Clear();
        }
    }

    public void BattleOver()
    {
        //player.ActivePlayerIcon(false);
        Debug.Log("Battle End!!");
        monsterinfoUI.gameObject.SetActive(false);
        killCount++;
        enemyController.SetEnemyHPbar();
        isBattle = false;
        player.playerState = PlayerState.NoneInRoom;
        battleOrder = BattleOrder.None;
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleResultManager.BattleWin();
    }
    public void CheatBattleEnd()
    {
        for (int i = 0; i < enemySquad[currentSquad].enemy.Count; i++)
        {
            enemySquad[currentSquad].enemy[i].OnDamage(100);
        }
        actionEnd = true;
    }

    public void GetEnemyInfo()
    {

    }
    public void PrintCurrentBattle()
    {
        //Debug.Log("Turn : " + turn);
        //Debug.Log("Enemy01 HP : " + monster[0].currentHp);
        //Debug.Log("Enemy02 HP : " + monster[1].currentHp);
        //Debug.Log("Enemy03 HP : " + monster[2].currentHp);
        //Debug.Log("Enemy04 HP : " + monster[3].currentHp);
    }
    public void PlayerSKillActive()
    {
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().ItemManager.SkillUnActiveImg(!playerSkillActive);
    }

    public void SetSelectedPlayer()
    {
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().ItemManager.PlayerSkillSet(selectedCharacter);
        player.SetPlayerIcon();
     
        playerinfoUI.GetPlayerInfo(selectedCharacter);
    }
    public void SetSelectedFirst()
    {
        //Debug.Log(SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().selectedCharacter.GetType());
        for (int i = player.playerCharacter.Count - 1; i >= 0; i--)
        {
            if (player.playerCharacter[i].dead == false)
            {
                selectedCharacter = player.playerCharacter[i];
            }
        }

        SetSelectedPlayer();
    }
    IEnumerator BattleAnimationDelay()
    {
        //애니메이션 셋
        coroutineCheck = true;
        yield return new WaitForSeconds(3f);
        Debug.Log("Animation End!!");
        coroutineCheck2 = true;

    }
    IEnumerator HPBarAnitmationDelay()
    {
        coroutineCheck2 = false;



        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().PlayerController.PrintCurrentHp();
        enemyController.PrintCurrentHp();

        yield return new WaitForSeconds(1f);

        Debug.Log("HP Updated");
        attackAnim = true;
    }
    IEnumerator BattleStartDelay()
    {
        isBattle = false;
        battleStartLogo.SetActive(true);
        yield return new WaitForSeconds(4.5f);
        battleStartLogo.SetActive(false);
        isBattle = true;
    }
    public void Test()
    {

    }
}
