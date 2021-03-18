using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapAlgo;

public class MapViewer : MonoBehaviour
{
    MapData _gameWorld;
    Room[] rooms;

    // Start is called before the first frame update
    void Start()
    {
        _gameWorld = TestMain.Instance.MapManager.gameWorld;
        //rooms = new Room[_gameWorld.GetRoomCount()];
        //SetRoomData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetRoomData()
    {
        for (int i = 0; i< rooms.Length; i++)
        {
            rooms[i].SetRoomInfo(_gameWorld.GetRoomDatas(i));
        }
    }
    void PrintRoom()
    {
        
    }
}
