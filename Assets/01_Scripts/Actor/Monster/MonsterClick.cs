using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterClick : MonoBehaviour
{
    Monster monster;
    private void Start()
    {
        monster = this.GetComponent<Monster>();
    }
    private void OnMouseDown()
    {
        Debug.Log(monster.GetType());
        if(!monster.dead)
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.targetMonster = monster;
    }
    private void OnMouseEnter()
    {
        if(!monster.dead)
        {
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.monsterinfoUI.gameObject.SetActive(true);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.monsterinfoUI.GetMonsterInfo(monster);
        }
    }
    private void OnMouseExit()
    {
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.monsterinfoUI.gameObject.SetActive(false);
    }
}
