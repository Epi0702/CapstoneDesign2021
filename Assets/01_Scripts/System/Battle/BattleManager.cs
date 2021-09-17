using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    int turn;
    public bool isBattle;

    [SerializeField]
    Player player;

    public List<Squad> enemySquad = new List<Squad>();

    public List<LivingEntity> turnManager = new List<LivingEntity>();

    int currentSquad;

    // Start is called before the first frame update
    void Start()
    {
        InitBattleManager();
        //enemySpawner.DEBUGSQUADTABLE();
    }

    // Update is called once per frame
    void Update()
    {
        //Battle();
    }
    public void SetUpSquadsInfo(List<Squad> list)
    {
        enemySquad = list;
    }
    public void InitBattleManager()
    {
        isBattle = false;
        turn = 0;
        currentSquad = -1;
    }
    public void StartBattle(int currentRoomIndex)               //enemysquad active
    {
        Debug.Log("Battle Start!!");

        GetEnemyInfo();
        for (int i = 0; i < enemySquad.Count; i++)
        {
            if (enemySquad[i].roomNum == currentRoomIndex)
            {
                enemySquad[i].gameObject.SetActive(true);
                currentSquad = i;
            }
        }
        for (int i = 0; i < enemySquad[currentSquad].enemy.Count; i++)
        {
            turnManager.Add(enemySquad[currentSquad].enemy[i]);
        }
        for (int i = 0; i < player.playerCharacter.Count; i++)
        {
            turnManager.Add(player.playerCharacter[i]);
        }
        turnManager.Sort(delegate (LivingEntity x, LivingEntity y)
        {
            return x.speed.CompareTo(y.speed);
        });
        turnManager.Reverse();

        isBattle = true;
    }
    public void Battle()
    {

    }

    public void BattleOver()
    {
        Debug.Log("Battle End!!");
        isBattle = false;
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.SetCurrentRoom();
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.SetRelRoomButton();
    }
    public void TurnEndButton()
    {
        PrintCurrentBattle();
        turn++;
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

}
