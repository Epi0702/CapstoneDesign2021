using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //<int, Queue<GameObject>> Caches = new Dictionary<int, Queue<GameObject>>();
    //roomnum , GameObject
    [SerializeField]
    Transform battleManager;
    public List<Squad> enemySquad = new List<Squad>();
    public SquadTable squadData;


    int maxSquadCount;

    int tableIndex;
    int maxTableIndex;
    bool isrunning;

    int tempStageNum = 0;
    public void initSpawner()
    {
        squadData.Load();
        maxTableIndex = squadData.GetCount();

        Debug.Log("EnemySpawn Start!!" + maxTableIndex);

        //GenerateSquad();
        //SetSquadPosition();
        //SetSquadPosition();
        //Debug.Log("count : " + enemySquad.Count);
        isrunning = true;
    }
    public void DEBUGSQUADTABLE()
    {
        for(int i = 0; i< maxTableIndex; i++)
            Debug.Log("Index : " + squadData.GetSquadPatternMember(i).index);
        Debug.Log("MaxTableIndex : " + maxTableIndex);
    }
    public void SetMaxSquadCount(int num)
    {
        maxSquadCount = num;
    }
    public void GenerateSquad()
    {
        Squad temp = Instantiate(Resources.Load<Squad>("Prefabs/Monster/Squad"), battleManager);
        enemySquad.Add(temp);
    }
    public void SetSquad(int battleroomIndex, int roomNum, int _type)
    {
        enemySquad[battleroomIndex].type = _type;
        enemySquad[battleroomIndex].roomNum = roomNum;
        enemySquad[battleroomIndex].monsterInfo = squadData.GetStructByIndex(_type, tempStageNum);
        enemySquad[battleroomIndex].SetSquad();

        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.SetUpSquadsInfo(enemySquad);
        enemySquad[battleroomIndex].gameObject.SetActive(false);
    }
    void SetSquadPosition()
    {
        for (int i = 0; i < enemySquad.Count; i++)
        {
            enemySquad[i].SetSquad();
        }
    }

}
