using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapAlgo;


public class MapManager : MonoBehaviour
{
    public MapData gameWorld;

    [SerializeField]
    RoomData[] rooms;
    [SerializeField]
    PrefabCacheData[] Passage;
    private void Awake()
    {
        gameWorld = new MapData();
        gameWorld.InitMap(MapSize.ThreebyThree, AreaSize.NinebyNine);
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Map Initialize Complete!!");

        rooms = new RoomData[gameWorld.GetRoomCount()];

        for(int i = 0; i<gameWorld.GetRoomCount(); i++)
        {
            //rooms[i] = Resources.Load<Room>("Prefabs/Room");
        }

    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.R))
    //    {

    //    }
    //}

}


