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
    Passage[] passage;
    //Aisle[] aisle;
    AisleData[] aisle;

    int passageIndex;

    // Start is called before the first frame update
    void Start()
    {
        //temp = this.transform;
        passageIndex = 0;
        gameWorldInMap = TestMain.Instance.MapManager.gameWorld;
        room = new Room[gameWorldInMap.rooms.Count];
        aisle = new AisleData[gameWorldInMap.passages.Count];
        //aisle = new Aisle[gameWorldInMap.passages.Count];

        for (int i = 0; i < gameWorldInMap.passages.Count; i++)
        {
            aisle[i] = gameWorldInMap.passages[i];

            passageIndex += aisle[i].GetPassageCount();
        }
        passage = new Passage[passageIndex];

        Debug.Log(gameWorldInMap.rooms.Count);

        PrintRoom();
        PrintPassage();
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
            room[i] = Instantiate(Resources.Load<Room>("Prefabs/Map/Room")) as Room;
            room[i].transform.SetParent(this.transform, false);
            room[i].roominfo = gameWorldInMap.rooms[i];
            Debug.Log(room[i].roominfo.GetRoomLoca().x + ", " + room[i].roominfo.GetRoomLoca().y);

            room[i].SetPositon(gameWorldInMap.settedMapSize, gameWorldInMap.settedAreaSize, scale);
        }
        //Instantiate(Resources.Load<GameObject>("Prefabs/Test/Cube"), temp);
        //room.transform.parent = this.transform;
    }
    void PrintPassage()
    {
        for (int i = 0; i < gameWorldInMap.passages.Count; i++)
        {
            for(int j = 0; j < gameWorldInMap.passages[i].GetPassageCount(); j++)
            {
                passage[i + j] = Instantiate(Resources.Load<Passage>("Prefabs/Map/Passage")) as Passage;
                passage[i + j].transform.SetParent(this.transform, false);
                passage[i + j].passageinfo = gameWorldInMap.passages[i].passage[j];

                passage[i + j].SetPositon(gameWorldInMap.settedMapSize, gameWorldInMap.settedAreaSize, scale);
            }
        }

    }
}
