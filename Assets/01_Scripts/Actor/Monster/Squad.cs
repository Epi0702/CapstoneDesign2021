using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squad : MonoBehaviour
{
    //squadTable data
    public int type;
    public int roomNum;

    public List<LivingEntity> enemy = new List<LivingEntity>();

    public MonsterSquadStruct monsterInfo;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {

        //SetUpSquad();
        //SetSquadPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSquad()
    {
        SetUpMonster(monsterInfo.enemy00);
        SetUpMonster(monsterInfo.enemy01);
        SetUpMonster(monsterInfo.enemy02);
        SetUpMonster(monsterInfo.enemy03);
        enemy[0].SetPositionData(monsterInfo.enemy00pos);
        enemy[1].SetPositionData(monsterInfo.enemy01pos);
        enemy[2].SetPositionData(monsterInfo.enemy02pos);
        enemy[3].SetPositionData(monsterInfo.enemy03pos);
        enemy[0].TransformPosition();
        enemy[1].TransformPosition();
        enemy[2].TransformPosition();
        enemy[3].TransformPosition();
    }
    public void SetUpMonster(int monsterType)
    {
        LivingEntity temp;
        switch (monsterType)
        {
            case 0:
                temp = Instantiate(Resources.Load<Zombie>("Prefabs/Monster/Zombie"), this.transform);
                enemy.Add(temp);
                break;
            case 1:
                temp = Instantiate(Resources.Load<Bat>("Prefabs/Monster/Bat"), this.transform);
                enemy.Add(temp);
                break;
            default:
                Debug.LogError("Monster Type ERROR!!");
                break;
        }
    }

    public bool CreateMonster(MonsterSquadStruct data)
    {
        string FilePath = SystemManager.Instance.MonsterTable.GetMonster(data.enemy00).FilePath;
        GameObject go = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().PrefabCacheSystem.Archive(FilePath);

        

        return true;
    }
}
