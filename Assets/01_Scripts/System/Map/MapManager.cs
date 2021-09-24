using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapAlgo;

public enum currentLocationState
{
    InRoom,
    InAsile,
}
public class MapManager : MonoBehaviour
{
    [SerializeField]
    MapSize mapSize;
    [SerializeField]
    AreaSize areaSize;
    public MapData gameWorld;
    public AisleData currentAisle;
    public int currentRoomIndex;
    public int prevRoomIndex;

    public currentLocationState state;

    public bool enterAisleDir; // 역순이면 false,
    public bool isBattle;

    public int maxPassageIndex;
    public int currentPassageIndex;
    public int endRoomIndex;

    public int battleRoomCount;
    EnemySpawner enemySpawner;

    [SerializeField]
    GameObject PassageIndexPlusForDebug;    
    [SerializeField]
    GameObject PassageIndexMinusForDebug;

    void Awake()
    {
        battleRoomCount = 0;
        currentRoomIndex = 0;
        currentAisle = null;
        currentPassageIndex = 0;
        prevRoomIndex = 0;
        PassageIndexPlusForDebug.SetActive(false);
        //PassageIndexMinusForDebug.SetActive(false);
        isBattle = false;
    }
    void Start()
    {
        CreateWorld();
    }
    void Update()
    {

    }
    void CreateWorld()          //세이브 데이터에 맵 없을시 생성
    {
        int battleroomIndex = 0;
        gameWorld = new MapData();
        gameWorld.InitMap(mapSize, areaSize);
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.OnStart();
        state = currentLocationState.InRoom;
        InitWorld();
        for(int i = 0; i < gameWorld.rooms.Count; i++)
        {
            if (gameWorld.rooms[i].roomevent == RoomEventType.Battle)
                battleRoomCount++;
        }
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().EnemySpawner.initSpawner();
        for (int i = 0; i < gameWorld.rooms.Count; i++)
        {
            if(gameWorld.rooms[i].roomevent == RoomEventType.Battle)
            {
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().EnemySpawner.GenerateSquad();// gameWorld.rooms[i].GetRoomAreaNum(), gameWorld.rooms[i].squadTypeNum);
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().EnemySpawner.SetSquad(battleroomIndex ,gameWorld.rooms[i].GetRoomAreaNum(), gameWorld.rooms[i].squadTypeNum); ;
                battleroomIndex++;
            }
        }
    }
    void InitWorld()
    {
        currentRoomIndex = gameWorld.startRoomIndex;
        endRoomIndex = gameWorld.endRoomIndex;
        //Debug.Log(currentRoomIndex);
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.SetCurrentRoom();
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.SetRelRoomButton();
    }

    public void CurrentRoomRelSet()
    {
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.SetCurrentRoom();
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.PrevRoomSet();
        
    }
    void EnterRoomInMap()
    {
        //Debug.Log("EnterRoomInMap called!!");
        PassageIndexPlusForDebug.SetActive(false);
        //PassageIndexMinusForDebug.SetActive(false);
        currentAisle = null;
        currentPassageIndex = 0;
        maxPassageIndex = 0;

        //Debug.Log("enter");
        state = currentLocationState.InRoom;
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().Hero.EnterRoom(gameWorld.rooms[currentRoomIndex]);

        //if(SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().Hero.playerState == PlayerState.None)
        //{
        //    SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.SetCurrentRoom();
        //}
        if(gameWorld.rooms[currentRoomIndex].roomevent == RoomEventType.Battle)
        {
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.StartBattle(currentRoomIndex);
        }
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.SetCurrentRoom();

        if (SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.isBattle == false)
        {
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.SetRelRoomButton();
        }
    }
    public void EnterAisle()
    {
        //Debug.Log("EnterAisle called!!");
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.PrevRoomSet();
        PassageIndexPlusForDebug.SetActive(true);
        //PassageIndexMinusForDebug.SetActive(true);

        state = currentLocationState.InAsile;

        currentAisle = gameWorld.rooms[prevRoomIndex].GetAisle(gameWorld.rooms[currentRoomIndex]);
        maxPassageIndex = currentAisle.passage.Count;
        //Debug.Log("MaxPassageIndex : " + maxPassageIndex);

        if (gameWorld.rooms[prevRoomIndex].CompareRoomLoca(currentAisle.GetStartRoom()))
        {
            //Debug.Log("정순");
            enterAisleDir = true;
            currentPassageIndex = 0;

            //Debug.Log("MaxPassageIndex : " + maxPassageIndex);
            //Debug.Log("currentPassageIndex : " + currentPassageIndex);
            //Debug.Log("");
        }
        else if(gameWorld.rooms[prevRoomIndex].CompareRoomLoca(currentAisle.GetEndRoom()))
        {
            //Debug.Log("역순");
            enterAisleDir = false;
            currentPassageIndex = (maxPassageIndex - 1);

            //Debug.Log("MaxPassageIndex : " + maxPassageIndex);
            //Debug.Log("currentPassageIndex : " + currentPassageIndex);
            //Debug.Log("");
        }
        else
        {
            Debug.LogError("Aisle Enter Dir ERROR");
        }
        //Debug.Log(currentAisle.GetStartRoom());


        ExitAisle();
    }

    public void ExitAisle()
    {
        //Debug.Log("ExitAisle called!!");
        if (enterAisleDir == true)
        {
            if (currentPassageIndex + 1 > maxPassageIndex)
            {
                state = currentLocationState.InRoom;
                EnterRoomInMap();
                //Debug.Log("EnterRoom!!");
                //Debug.Log("CurrentRoomNUM : " + currentRoomIndex);
            }
            else
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.PassageInIconActive(currentAisle.AisleNum, currentPassageIndex);

        }
        else
        {
            if(currentPassageIndex < 0)
            {
                state = currentLocationState.InRoom;
                EnterRoomInMap();
                //Debug.Log("EnterRoom!!");
                //Debug.Log("CurrentRoomNUM : " + currentRoomIndex);
            }
            else
                SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.PassageInIconActive(currentAisle.AisleNum, currentPassageIndex);

        }
    }



    public void PlusIndex()
    {
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.PassageInIconInActive(currentAisle.AisleNum, currentPassageIndex);

        if (enterAisleDir == true)
        {
            currentPassageIndex++;
            //Debug.Log("이동");
        }

        else
        {
            currentPassageIndex--;
            //Debug.Log("이동");
        }

        //Debug.Log("MaxPassageIndex : " + maxPassageIndex);
        //Debug.Log("currentPassageIndex : " + currentPassageIndex);
        //Debug.Log("");

        ExitAisle();
    }

}


