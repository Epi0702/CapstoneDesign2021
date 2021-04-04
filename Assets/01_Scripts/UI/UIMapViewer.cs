using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapAlgo;

public class UIMapViewer : MonoBehaviour
{
    [SerializeField]
    int scale;
    MapData gameWorldInMap;

    UIRoom[] room;
    UIPassage[] passage;

    AisleData[] aisle;

    int passageIndex;

    public void OnStart()
    {
        //temp = this.transform;
        passageIndex = 0;
        gameWorldInMap = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().MapManager.gameWorld;
        room = new UIRoom[gameWorldInMap.rooms.Count];
        aisle = new AisleData[gameWorldInMap.passages.Count];


        for (int i = 0; i < gameWorldInMap.passages.Count; i++)
        {
            aisle[i] = gameWorldInMap.passages[i];

            passageIndex += aisle[i].GetPassageCount();
        }
        passage = new UIPassage[passageIndex];

        Debug.Log(gameWorldInMap.rooms.Count);

        PrintRoom();
        PrintPassage();
    }
    void PrintRoom()
    {
        for (int i = 0; i < gameWorldInMap.rooms.Count; i++)
        {
            room[i] = Instantiate(Resources.Load<UIRoom>("Prefabs/Map/RoomUI")) as UIRoom;
            room[i].transform.SetParent(this.transform, false);
            room[i].roominfo = gameWorldInMap.rooms[i];
            room[i].SetPositon(gameWorldInMap.settedMapSize, gameWorldInMap.settedAreaSize, scale);
        }
    }
    void PrintPassage()
    {
        for (int i = 0; i < gameWorldInMap.passages.Count; i++)
        {
            for (int j = 0; j < gameWorldInMap.passages[i].GetPassageCount(); j++)
            {
                passage[i + j] = Instantiate(Resources.Load<UIPassage>("Prefabs/Map/PassageUI")) as UIPassage;
                passage[i + j].transform.SetParent(this.transform, false);
                passage[i + j].passageinfo = gameWorldInMap.passages[i].passage[j];

                passage[i + j].SetPositon(gameWorldInMap.settedMapSize, gameWorldInMap.settedAreaSize, scale);
            }
        }

    }
}
