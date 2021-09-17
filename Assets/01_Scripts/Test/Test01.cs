using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public enum charType
{
    player = 0,
    monster = 1,
}
public class TestStruct
{
    public charType type;
    public int index;
    public int spd;

    public void DebugAttack()
    {
        Debug.Log("Type : " + this.type + ", index : " + this.index + ", spd : " + this.spd);
        Debug.Log("ATTACK!!");
    }
}
public class Test01 : MonoBehaviour
{
    TestStruct tempStruct(charType type, int x, int y)
    {
        TestStruct temp = new TestStruct();
        temp.type = type;
        temp.index = x;
        temp.spd = y;
        return temp;
    }

    TestStruct temp;
        
    public int Score;
    public float fl = 1.0f;

    List<TestStruct> playerChar = new List<TestStruct>();
    List<TestStruct> monsterChar = new List<TestStruct>();

    //List<TestStruct> playerBySpd = new List<TestStruct>();
    //List<TestStruct> monsterBySpd = new List<TestStruct>();

    List<TestStruct> TurnManager = new List<TestStruct>();

    public int attackcount;
    public int turn;

    bool attackterm;
    bool turnEnd;
    // Start is called before the first frame update
    void Start()
    {
        attackterm = false;
        turnEnd = true;
        turn = 0;

        playerChar.Add(tempStruct(charType.player,0,1));
        playerChar.Add(tempStruct(charType.player, 1,4));
        playerChar.Add(tempStruct(charType.player, 2,3));
        playerChar.Add(tempStruct(charType.player, 3,2));

        monsterChar.Add(tempStruct(charType.monster, 0, 2));
        monsterChar.Add(tempStruct(charType.monster, 1, 2));
        monsterChar.Add(tempStruct(charType.monster, 2, 3));
        monsterChar.Add(tempStruct(charType.monster, 3, 3));


        Debug.Log("Start!!");


    }
    // Update is called once per frame
    void Update()
    {
        Battle();
    }
    public void Battle()
    {
        if(turnEnd)
        {
            TurnSet();
            //for (int i = 0; i < TurnManager.Count; i++)
            //    Debug.Log("Type : " + TurnManager[i].type + ", index : " + TurnManager[i].index + ", spd : " + TurnManager[i].spd);
            turnEnd = false;
            attackcount = 0;
            turn = 1;
            attackterm = false;     //false면 공격가능 , true면 쿨탐
            Debug.Log("Turn START!!");
        }
        
        if(attackterm == false)
        {
            StartCoroutine("BattleAnimationDelay");

        }



        TurnEnd(TurnManager);
    }
    //public void PlayerSortBySpd()
    //{
    //    playerBySpd = playerChar.ToList();
    //    playerBySpd.Sort(delegate (TestStruct x, TestStruct y)
    //    {
    //        return x.spd.CompareTo(y.spd);
    //    });
    //    playerBySpd.Reverse();
    //}
    //public void MonsterSortBySpd()
    //{
    //    monsterBySpd = monsterChar.ToList();
    //    monsterBySpd.Sort(delegate (TestStruct x, TestStruct y)
    //    {
    //        return x.spd.CompareTo(y.spd);
    //    });
    //    monsterBySpd.Reverse();
    //}
    public void TurnSet()
    {
        for (int i = 0; i < monsterChar.Count; i++)
        {
            TurnManager.Add(monsterChar[i]);
        }
        for (int i  =0; i< playerChar.Count; i++)
        {
            TurnManager.Add(playerChar[i]);
        } 

        TurnManager.Sort(delegate (TestStruct x, TestStruct y)
        {
            return x.spd.CompareTo(y.spd);
        });
        TurnManager.Reverse();
    }
    IEnumerator BattleAnimationDelay()
    {
        attackterm = true;
        yield return new WaitForSeconds(3f);
        TurnManager[attackcount].DebugAttack();
        attackcount++;
        attackterm = false;
    }
    public void TurnStart()
    {

    }
    public void TurnEnd(List<TestStruct> list)
    {
        if (attackcount == list.Count)
        {
            turnEnd = true;
            Debug.Log("Turn " + turn + " 종료");
            turn++;
        }

    }
    
    public void PrintScore()
    {
        Debug.Log(Score);
    }
}
