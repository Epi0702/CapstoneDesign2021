using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapAlgo;

public class Room : MonoBehaviour
{
    RoomData roomInfo;
    RectTransform rectTrans;
    // Start is called before the first frame update
    void Start()
    {
        roomInfo = GetComponent<RoomData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetRoomInfo(RoomData _roomData)
    {
        roomInfo = _roomData;
    }
}
