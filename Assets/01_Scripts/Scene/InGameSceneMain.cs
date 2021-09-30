using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSceneMain : BaseSceneMain
{
    [SerializeField]
    MapManager mapmanager;
    public MapManager MapManager
    {
        get
        {
            return mapmanager;
        }
    }
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
        StageNum = 0;
    }
    protected override void OnStart()
    {
        base.OnStart();
        playerController.LoadPlayerCharacter();
        player.TestSkillSet();
        ItemManager.PlayerSkillSet(player.playerCharacter[0]);
    }

    protected override void UpdateScene()
    {
        base.UpdateScene();
    }
}
