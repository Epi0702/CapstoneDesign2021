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
    void Awake()
    {
        rectTrans = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetRoom(RoomData _roomData)
    {
        roominfo = _roomData;
    }
    public void SetPositon(MapSize _mapsize, AreaSize _areasize, int _scale)
    {
        int realLoca = 0;
        realLoca = ((int)_mapsize * (int)_areasize + (int)_mapsize - 2) / 2;

        rectTrans.anchoredPosition = new Vector2((roominfo.GetRoomLoca().x - realLoca) * _scale, (roominfo.GetRoomLoca().y - realLoca) * _scale);
    }

}
