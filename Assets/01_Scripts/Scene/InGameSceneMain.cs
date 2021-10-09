using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSceneMain : BaseSceneMain
{

    [SerializeField]
    MapManager mapManager;
    public MapManager MapManager
    {
        get
        {
            return mapManager;
        }
    }    
    [SerializeField]
    BattleManager battleManager;
    public BattleManager BattleManager
    {
        get
        {
            return battleManager;
        }
    }
    [SerializeField]
    BattleResultManager battleResultManager;
    [SerializeField]
    BGManager bGManager;
    public BGManager BGManager
    {
        get
        {
            return bGManager;
        }
    }
    [SerializeField]
    UIMapViewer uiMapViewer;
    public UIMapViewer UIMapViewer
    {
        get
        {
            return uiMapViewer;
        }
    }

    public BattleResultManager BattleResultManager
    {
        get
        {
            return battleResultManager;
        }
    }
    [SerializeField]
    EnemySpawner enemySpawner;
    public EnemySpawner EnemySpawner
    {
        get
        {
            return enemySpawner;
        }
    }
    [SerializeField]
    PlayerController playerController;
    public PlayerController PlayerController
    {
        get
        {
            return playerController;
        }
    }
    [SerializeField]
    SquadController squadController;
    public SquadController SquadController
    {
        get
        {
            return squadController;
        }
    }
    [SerializeField]
    ItemManager itemManager;
    public ItemManager ItemManager
    {
        get
        {
            return itemManager;
        }
    }
    [SerializeField]
    AnimationManager animationManager;
    public AnimationManager AnimationManager
    {
        get
        {
            return animationManager;
        }
    }
    PrefabCacheSystem prefabCacheSystem = new PrefabCacheSystem();
    public PrefabCacheSystem PrefabCacheSystem
    {
        get
        {
            return prefabCacheSystem;
        }
    }
    [SerializeField]
    Player player;
    public Player Hero
    {
        get
        {
            if (!player)
            {
                Debug.LogError("Main Player is not setted!");
            }

            return player;
        }
    }

    public int StageNum;


    protected override void OnAwake()
    {
        base.OnAwake();
    }
    protected override void OnStart()
    {
        base.OnStart();
        StageNum = 0;

        GameStart();
    }

    protected override void UpdateScene()
    {
        base.UpdateScene();

            
        
    }
    public void test()
    {

    }
    void GameStart()
    {
        playerController.LoadPlayerCharacter();
        player.TestSkillSet();

        BattleManager.SetSelectedFirst();
        MapManager.CreateWorld();
    }
}
