using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Squad squad;

    [SerializeField]
    HPbar[] EnemyHpBar;

    int[] beforeHp = new int[4];
    // Start is called before the first frame update
    void Start()
    {
        squad = null;
        SetEnemyHPbar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSquad(Squad squad)
    {
        this.squad = squad;
        ActiveEnemyHPbar();
    }
    public void SetEnemyHPbar()
    {
        for (int i = 0; i < 4; i++)
        {
            EnemyHpBar[i].SetOnOff(false);
        }
    }

    public void ActiveEnemyHPbar()
    {
        for (int i = 0; i < squad.enemy.Count; i++)
        {
            if (!squad.enemy[i].dead && squad.enemy[i] != null)
            {
                EnemyHpBar[i].SetOnOff(true);
                EnemyHpBar[i].InitHPbar(squad.enemy[i].stats.maxHp, squad.enemy[i].stats.currentHp);
                beforeHp[i] = squad.enemy[i].stats.currentHp;
            }
        }
    }
    public void PrintCurrentHp()
    {
        for (int i = 0; i < squad.enemy.Count; i++)
        {
            EnemyHpBar[i].DecreaseHP(squad.enemy[i].stats.currentHp);
        }
    }
}
