using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapAlgo;

public class MapViewer : MonoBehaviour
{
    MapData gameWorldInMap;
    // Start is called before the first frame update
    void Start()
    {
        gameWorldInMap = TestMain.Instance.MapManager.gameWorld;
        Debug.Log(gameWorldInMap.rooms.Count);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void SetRoomData()
    {
    }
    void PrintRoom()
    {
        
    }
}
