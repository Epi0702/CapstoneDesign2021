using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapAlgo;

public class MapViewer : MonoBehaviour
{
    [SerializeField]
    int scale;
    MapData gameWorldInMap;

    Room[] room;
    Aisle[] aisle;

    // Start is called before the first frame update
    void Start()
    {
        //temp = this.transform;

        gameWorldInMap = TestMain.Instance.MapManager.gameWorld;
        room = new Room[gameWorldInMap.rooms.Count];
        //aisle = new Aisle[gameWorldInMap.passages.Count];

        Debug.Log(gameWorldInMap.rooms.Count);

        PrintRoom();
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
        for(int i = 0; i< gameWorldInMap.rooms.Count; i++)
        {
            room[i] = Instantiate(Resources.Load<Room>("Prefabs/Room")) as Room;
            room[i].transform.SetParent(this.transform, false);
            room[i].roominfo = gameWorldInMap.rooms[i];
            Debug.Log(room[i].roominfo.GetRoomLoca().x + ", " + room[i].roominfo.GetRoomLoca().y);

            room[i].SetPositon(gameWorldInMap.settedMapSize, gameWorldInMap.settedAreaSize, scale);
        }
        //Instantiate(Resources.Load<GameObject>("Prefabs/Test/Cube"), temp);
        //room.transform.parent = this.transform;

    }
}
