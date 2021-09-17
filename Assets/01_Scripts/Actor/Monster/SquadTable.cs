using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct MonsterSquadStruct
{
    public int index;

    public int enemy00;
    public int enemy00pos;

    public int enemy01;
    public int enemy01pos;

    public int enemy02;
    public int enemy02pos;

    public int enemy03;
    public int enemy03pos;
}
public class SquadTable : TableLoader<MonsterSquadStruct>
{
    List<MonsterSquadStruct> tableDatas = new List<MonsterSquadStruct>();

    protected override void AddData(MonsterSquadStruct data)
    {
        tableDatas.Add(data);
    }

    public MonsterSquadStruct GetSquadPatternMember(int index)
    {
        if (index < 0 || index >= tableDatas.Count)
        {
            Debug.LogError("Pattern Error! index = " + index);
            return default(MonsterSquadStruct);
        }
        return tableDatas[index];
    }
    public int GetEnemyInfo(int index, int monsterindex)
    {
        if (index < 0 || index >= tableDatas.Count)
        {
            Debug.LogError("Pattern Error! index = " + index);
            return -1;
        }
        else
        {
            switch (monsterindex)
            {
                case 0:
                    return tableDatas[index].enemy00;
                case 1:
                    return tableDatas[index].enemy01;
                case 2:
                    return tableDatas[index].enemy02;
                case 3:
                    return tableDatas[index].enemy03;
                default:
                    Debug.LogError("MonsterPattern Error! index = " + index);
                    return -1;
            }
        }
    }
    public int GetEnemyPos(int index, int monsterindex)
    {
        if (index < 0 || index >= tableDatas.Count)
        {
            Debug.LogError("Pattern Error! index = " + index);
            return -1;
        }
        else
        {
            switch (monsterindex)
            {
                case 0:
                    return tableDatas[index].enemy00pos;
                case 1:
                    return tableDatas[index].enemy01pos;
                case 2:
                    return tableDatas[index].enemy02pos;
                case 3:
                    return tableDatas[index].enemy03pos;
                default:
                    Debug.LogError("MonsterPattern Error! index = " + index);
                    return -1;
            }
        }
    }

    public MonsterSquadStruct GetStructByIndex(int index, int currentStage)
    {
        //Debug.Log("Index : " + index + "CurrentStage : " + currentStage);
        for(int i = 0; i < tableDatas.Count; i++)
        {
            if (tableDatas[i].index /10 == currentStage && tableDatas[i].index % 10 == index)
                return tableDatas[i];
        }
        Debug.LogError("Can't Find MonsterSquadStruct");
        return tableDatas[0];
    }

    public int GetCount()
    {
        return tableDatas.Count;
    }

}
