using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapAlgo;


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


    int maxPassageIndex;
    public int currentPassageIndex;

    public int endRoomIndex;

    [SerializeField]
    GameObject PassageIndexPlusForDebug;

    void Awake()
    {
        currentRoomIndex = 0;
        currentAisle = null;
        currentPassageIndex = 0;
        prevRoomIndex = 0;
        PassageIndexPlusForDebug.SetActive(false);
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
        gameWorld = new MapData();
        gameWorld.InitMap(mapSize, areaSize);
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.OnStart();

        InitWorld();
    }
    void InitWorld()
    {
        currentRoomIndex = gameWorld.startRoomIndex;
        endRoomIndex = gameWorld.endRoomIndex;
        Debug.Log(currentRoomIndex);
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.SetCurrentRoom();
    }

    public void CurrentRoomRelSet()
    {
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.SetCurrentRoom();
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.PrevRoomSet();
        
    }
    void EnterRoomInMap()
    {
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().Hero.EnterRoom(gameWorld.rooms[currentRoomIndex]);
        if(SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().Hero.playerState == PlayerState.None)
        {
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.SetCurrentRoom();
        }
    }
    public void EnterAisle()
    {
        PassageIndexPlusForDebug.SetActive(true);
        currentAisle = gameWorld.rooms[prevRoomIndex].GetAisle(gameWorld.rooms[currentRoomIndex]);
        maxPassageIndex = currentAisle.passage.Count;

        if(currentPassageIndex < maxPassageIndex)
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().Hero.EnterPassgae(currentAisle.passage[currentPassageIndex]);
        else if(currentPassageIndex == maxPassageIndex)
        {
            EnterRoomInMap();
            currentAisle = null;
            currentPassageIndex = 0;
        }

    }




    public void PlusIndex()
    {
        currentPassageIndex++;
        PassageIndexPlusForDebug.SetActive(false);
        
    }

}


