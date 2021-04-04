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
    public int currentRoomIndex;
    public int prevRoomIndex;
    public int currentAisleIndex;
    public int currentPassageIndex;

    public int endRoomIndex;

    void Awake()
    {
        currentRoomIndex = 0;
        currentAisleIndex = 0;
        currentPassageIndex = 0;
        prevRoomIndex = 0;
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
        //gameWorld.InitMap(MapSize.FourbyFour, AreaSize.NinebyNine);
        gameWorld.InitMap(mapSize, areaSize);
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.OnStart();

        InitWorld();
        CurrentRoomRelSet();
    }
    void InitWorld()
    {
        currentRoomIndex = gameWorld.startRoomIndex;
        endRoomIndex = gameWorld.endRoomIndex;
    }

    public void CurrentRoomRelSet()
    {
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.SetCurrentRoom();
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.PrevRoomSet();
        
    }

}


