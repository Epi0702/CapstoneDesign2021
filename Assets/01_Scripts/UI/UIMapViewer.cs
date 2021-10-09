using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MapAlgo;

public class UIMapViewer : MonoBehaviour
{
    [SerializeField]
    int scale;
    MapData gameWorldInMap;

    UIRoom[] room;
    UIPassage[][] passage;

   // RoomData[] roomData;
    AisleData[] aisleData;

    int passageIndex;

    int currentRoomIndexInMap;
    int prevRoomIndexInMap;

    [SerializeField]
    Slider test;

    float prev;
    float current;

    float test_num;

    public void OnStart()
    {
        //temp = this.transform;
        passageIndex = 0;
        gameWorldInMap = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().MapManager.gameWorld;
        room = new UIRoom[gameWorldInMap.rooms.Count];
        //aisleData = new AisleData[gameWorldInMap.passages.Count];

        passage = new UIPassage[gameWorldInMap.passages.Count][];

        for (int i = 0; i < gameWorldInMap.passages.Count; i++)
        {
            passage[i] = new UIPassage [gameWorldInMap.passages[i].GetPassageCount()];
        }

        //Debug.Log(gameWorldInMap.rooms.Count);

        PrintRoom();
        PrintPassage();
        prev = current = 0.5f;
    }
    private void Update()
    {
        testSlider();
        if (prev != current)
        {
            scale = (int)test_num;
            MoveRoom();
            MoveAisle();
            current = prev;
        }
    }
    void testSlider()
    {
        test_num = Mathf.Lerp(50, 75, test.value);
//        Debug.Log(test_num);
        prev = test_num;
    }
    void MoveRoom()
    {
        Debug.Log(gameWorldInMap.rooms.Count);
        for (int i = 0; i < gameWorldInMap.rooms.Count; i++)
        {
            room[i].transform.SetParent(this.transform, false);
            //room[i].roominfo = gameWorldInMap.rooms[i];
            room[i].SetRoom(gameWorldInMap.rooms[i]);
            room[i].SetPositon(gameWorldInMap.settedMapSize, gameWorldInMap.settedAreaSize, scale);
            room[i].SetSize((int)test_num);
        }

    }

    void MoveAisle()
    {
        for (int i = 0; i < gameWorldInMap.passages.Count; i++)
        {
            for (int j = 0; j < gameWorldInMap.passages[i].GetPassageCount(); j++)
            {
                passage[i][j].transform.SetParent(this.transform, false);
                passage[i][j].passageinfo = gameWorldInMap.passages[i].passage[j];

                passage[i][j].SetPositon(gameWorldInMap.settedMapSize, gameWorldInMap.settedAreaSize, scale);
                passage[i][j].SetSize((int)test_num);



            }
        }

    }

    void PrintRoom()
    {
        for (int i = 0; i < gameWorldInMap.rooms.Count; i++)
        {
            room[i] = Instantiate(Resources.Load<UIRoom>("Prefabs/Map/RoomUI")) as UIRoom;
            room[i].transform.SetParent(this.transform, false);
            //room[i].roominfo = gameWorldInMap.rooms[i];
            room[i].SetRoom(gameWorldInMap.rooms[i]);
            room[i].SetPositon(gameWorldInMap.settedMapSize, gameWorldInMap.settedAreaSize, scale);
        }
    }
    void PrintPassage()
    {
        for (int i = 0; i < gameWorldInMap.passages.Count; i++)
        {
            for (int j = 0; j < gameWorldInMap.passages[i].GetPassageCount(); j++)
            {
                passage[i][j] = Instantiate(Resources.Load<UIPassage>("Prefabs/Map/PassageUI")) as UIPassage;
                passage[i][j].transform.SetParent(this.transform, false);
                passage[i][j].passageinfo = gameWorldInMap.passages[i].passage[j];

                passage[i][j].SetPositon(gameWorldInMap.settedMapSize, gameWorldInMap.settedAreaSize, scale);
            }
        }

    }

    public void PassageInIconActive(int passageNum, int currentIndex)
    {
       passage[passageNum][currentIndex].CurrentPassageIconActive();
    } 
    public void PassageInIconInActive(int passageNum, int currentIndex)
    {
       passage[passageNum][currentIndex].CurrentPassageIconInActive();
    }

    public void PrevRoomSet()
    {
        prevRoomIndexInMap = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().MapManager.prevRoomIndex;
        room[prevRoomIndexInMap].CurrentRoomIconInActive();
        if (room[prevRoomIndexInMap].roominfo.roomRel.left != null)
        {
            room[room[prevRoomIndexInMap].roominfo.roomRel.left.GetRoomAreaNum()].ButtonInActive();
        }
        if (room[prevRoomIndexInMap].roominfo.roomRel.right != null)
        {
            room[room[prevRoomIndexInMap].roominfo.roomRel.right.GetRoomAreaNum()].ButtonInActive();
        }
        if (room[prevRoomIndexInMap].roominfo.roomRel.top != null)
        {
            room[room[prevRoomIndexInMap].roominfo.roomRel.top.GetRoomAreaNum()].ButtonInActive();
        }
        if (room[prevRoomIndexInMap].roominfo.roomRel.bottom != null)
        {
            room[room[prevRoomIndexInMap].roominfo.roomRel.bottom.GetRoomAreaNum()].ButtonInActive();
        }
    }
    public void SetCurrentRoom()
    {
        currentRoomIndexInMap = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().MapManager.currentRoomIndex;

        if(SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().MapManager.state == currentLocationState.InRoom)
            room[currentRoomIndexInMap].CurrentRoomIconActive();
    }

    public void SetRelRoomButton()
    {
        if (room[currentRoomIndexInMap].roominfo.roomRel.left != null)
        {
            room[room[currentRoomIndexInMap].roominfo.roomRel.left.GetRoomAreaNum()].ButtonActive();
        }
        if (room[currentRoomIndexInMap].roominfo.roomRel.right != null)
        {
            room[room[currentRoomIndexInMap].roominfo.roomRel.right.GetRoomAreaNum()].ButtonActive();
        }
        if (room[currentRoomIndexInMap].roominfo.roomRel.top != null)
        {
            room[room[currentRoomIndexInMap].roominfo.roomRel.top.GetRoomAreaNum()].ButtonActive();
        }
        if (room[currentRoomIndexInMap].roominfo.roomRel.bottom != null)
        {
            room[room[currentRoomIndexInMap].roominfo.roomRel.bottom.GetRoomAreaNum()].ButtonActive();
        }
    }

    public void GetCurrentPassage()
    {
        
    }
}
