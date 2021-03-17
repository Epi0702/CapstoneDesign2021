using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapData;


public class MapManager : MonoBehaviour
{
    public Map gameWorld;

    [SerializeField]
    Room[] rooms;
    [SerializeField]
    PrefabCacheData[] Passage;

    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        gameWorld = new Map();
        gameWorld.InitMap(MapSize.ThreebyThree, AreaSize.NinebyNine);
        Debug.Log("Map Initialize Complete!!");

        rooms = new Room[gameWorld.GetRoomCount()];

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


