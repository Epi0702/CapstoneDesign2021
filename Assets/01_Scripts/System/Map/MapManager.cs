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
    public int currentAisleIndex;
    public int currentPassageIndex;

    public int endRoomIndex;

    void Awake()
    {
        currentRoomIndex = 0;
        currentAisleIndex = 0;
        currentPassageIndex = 0;
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
        InitWorld();
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().UIMapViewer.OnStart();
    }
    void InitWorld()
    {
        currentRoomIndex = gameWorld.startRoomIndex;
        endRoomIndex = gameWorld.endRoomIndex;
    }

}


