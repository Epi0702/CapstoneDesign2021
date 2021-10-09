using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AnimationManager : MonoBehaviour
{
    //public Character currentPlayerEntity;
    //public Character[] TestEntity;
    //public List<Monster> targetEntity = new List<Monster>();

    //public GameObject playerCurrent;
    //public Event currentTurnEntityAnim;

    public BattleManager bm;

    public Image blurPanel;
    Animator anim;

    public GameObject currentPlayerTrans;
    public GameObject currentMonsterTrans;

    public Action<Acting> attackerAnimEvent;
    public Action<MonsterActing> monsterattackerAnimEvent;

    public Acting playerAct;
    public MonsterActing monsterAct;

    public GameObject[] targetPlayerTrans;
    public GameObject[] targetMonsterTrans;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        //playerCurrent = currentPlayerEntity.gameObject;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayerAttackMonster()
    {
        //currentPlayerTrans = currentMonsterTrans = null;
        //targetMonsterTrans = null;
        currentPlayerTrans = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.selectedCharacter.gameObject;
        for (int i = 0; i < bm.targetEntity.Count; i++)
        {
            targetMonsterTrans[i] = bm.targetEntity[i].gameObject;
        }
        StartCoroutine("PlayerAttackAnimation", playerAct);
    }
    public void MonsterAtackPlayer()
    {
        currentMonsterTrans = bm.selectedMonster.gameObject;
        for (int i = 0; i < bm.targetEntity.Count; i++)
        {
            targetPlayerTrans[i] = bm.targetEntity[i].gameObject;
        }
        StartCoroutine("EnemyAttackAnimation", monsterAct);
    }
    //IEnumerator Test()
    //{
    //    anim.Play("PlayerAttack");
    //    blurPanel.gameObject.SetActive(true);
    //    playerCurrent.transform.position = new Vector3(-2, 0, -6);
    //    playerCurrent.transform.localScale = new Vector3(2, 2, 2);



    //    yield return new WaitForSeconds(0.5f);
    //    currentPlayerEntity.TestAnimation();
    //    yield return new WaitForSeconds(1f);
    //    targetEntity[0].TestAnimation();
    //    yield return new WaitForSeconds(1.5f);
    //    playerCurrent.transform.localScale = new Vector3(1, 1, 1);
    //    playerCurrent.gameObject.transform.position = new Vector3(-5.8f, 0, 0);
    //    currentPlayerEntity.TestAnimation2();
    //    targetEntity[0].TestAnimation2();
    //}

    IEnumerator PlayerAttackAnimation(Acting animName)
    {
        bm.coroutineCheck = true;
        blurPanel.gameObject.SetActive(true);

        currentPlayerTrans.transform.position = new Vector3(-1.5f, -0.5f, -6);
        currentPlayerTrans.transform.localScale = new Vector3(2, 2, 1);
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.selectedCharacter.renderer.sortingOrder = 2;


        for (int i = 0; i < bm.targetEntity.Count; i++)
        {
            targetMonsterTrans[i].transform.position = new Vector3(1.5f + 2.5f * i, targetMonsterTrans[i].transform.position.y, -6);
            targetMonsterTrans[i].transform.localScale = new Vector3(2, 2, 1);
            bm.targetEntity[i].renderer.sortingOrder = 2;
        }
        yield return new WaitForSeconds(1f);


        attackerAnimEvent(animName);
        yield return new WaitForSeconds(1f);


        for (int i = 0; i < bm.targetEntity.Count; i++)
        {
            bm.DamageInputEvent(bm.targetEntity[i], bm.damageList[i]);
            bm.targetEntity[i].SetAnimation(MonsterActing.Hurt);
        }
        yield return new WaitForSeconds(1.5f);


        currentPlayerTrans.transform.position = new Vector3(0, 0, 0);
        currentPlayerTrans.transform.localScale = new Vector3(1, 1, 1);
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.selectedCharacter.SetAnimation(Acting.Idle);
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.selectedCharacter.TransformPosition();
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.selectedCharacter.renderer.sortingOrder = 0;


        for (int i = 0; i < bm.targetEntity.Count; i++)
        {
            targetMonsterTrans[i].transform.position = new Vector3(0, 0, 0);
            targetMonsterTrans[i].transform.localScale = new Vector3(1, 1, 1);
            bm.targetEntity[i].SetAnimation(MonsterActing.Idle);
            bm.targetEntity[i].TransformPosition();
            bm.targetEntity[i].renderer.sortingOrder = 0;
        }

        playerAct = Acting.Idle; 
        monsterAct = MonsterActing.Idle;

        attackerAnimEvent = null;
        bm.coroutineCheck2 = true;
        blurPanel.gameObject.SetActive(false);

        Debug.Log("Player Attack End!!");
    }

    IEnumerator EnemyAttackAnimation(MonsterActing animName)
    {
        bm.coroutineCheck = true;
        blurPanel.gameObject.SetActive(true);

        currentMonsterTrans.transform.position = new Vector3(1.5f, bm.selectedMonster.transform.position.y, -6);
        currentMonsterTrans.transform.localScale = new Vector3(2, 2, 1);
        bm.selectedMonster.renderer.sortingOrder = 2;


        for (int i = 0; i < bm.targetEntity.Count; i++)
        {
            targetPlayerTrans[i].transform.position = new Vector3((1.5f + 2.5f * i) * (-1), targetPlayerTrans[i].transform.position.y, -6);
            targetPlayerTrans[i].transform.localScale = new Vector3(2, 2, 1);
            bm.targetEntity[i].renderer.sortingOrder = 2;
        }
        yield return new WaitForSeconds(1f);


        monsterattackerAnimEvent(animName);
        yield return new WaitForSeconds(1f);


        for (int i = 0; i < bm.targetEntity.Count; i++)
        {
            bm.DamageInputEvent(bm.targetEntity[i], bm.damageList[i]);
            bm.targetEntity[i].SetAnimation(Acting.Hurt);
        }
        yield return new WaitForSeconds(1.5f);


        currentMonsterTrans.transform.position = new Vector3(0, 0, 0);
        currentMonsterTrans.transform.localScale = new Vector3(1, 1, 1);
        bm.selectedMonster.SetAnimation(MonsterActing.Idle);
        bm.selectedMonster.TransformPosition();
        bm.selectedMonster.renderer.sortingOrder = 0;


        for (int i = 0; i < bm.targetEntity.Count; i++)
        {
            targetPlayerTrans[i].transform.position = new Vector3(0, 0, 0);
            targetPlayerTrans[i].transform.localScale = new Vector3(1, 1, 1);
            bm.targetEntity[i].SetAnimation(Acting.Idle);
            bm.targetEntity[i].TransformPosition();
            bm.targetEntity[i].renderer.sortingOrder = 0;
        }

        playerAct = Acting.Idle;
        monsterAct = MonsterActing.Idle;
        monsterattackerAnimEvent = null;
        bm.coroutineCheck2 = true;
        blurPanel.gameObject.SetActive(false);

        Debug.Log("Monster Attack End!!");

    }
}
