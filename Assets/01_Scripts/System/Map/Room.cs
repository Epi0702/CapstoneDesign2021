using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapAlgo;

public class Room : MonoBehaviour
{
    //RoomData roomInfo;
    RectTransform rectTrans;
    public RoomData roominfo;
    // Start is called before the first frame update
    void Start()
    {
        //TestMain.Instance.MapManager
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetRoom(RoomData _roomData)
    {
        roominfo = _roomData;
    }

}
