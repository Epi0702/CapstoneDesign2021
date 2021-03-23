using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapAlgo
{

    public class RoomData
    {
        LocationData locationInfo = new LocationData();
        RoomEventType roomevent;

        public RoomRelation roomRel;

        public void SetLocationToRealLoca(CoupleInt _location)
        {
            locationInfo.locationIndex.x += _location.x;
            locationInfo.locationIndex.y += _location.y;
        }
        public void SetRoomLocation(int _areanum, CoupleInt _areaLocation, CoupleInt _rand)
        {
            locationInfo.areanum = _areanum;
            locationInfo.locationIndex.x = _areaLocation.x + _rand.x;
            locationInfo.locationIndex.y = _areaLocation.y + _rand.y;
            locationInfo.loCT = LocationCategory.CT_Room;
        }

        //mapmanager 에서 맵뷰 room 에 초기 정보 전달
        public void SetRoomLocation(CoupleInt _areaLoaction, RoomRelation _roomRel)
        {
            locationInfo.locationIndex = _areaLoaction;
            roomRel = _roomRel;
        }
        public void PrintRoomInfo()
        {
            Debug.Log("Room Num : " + locationInfo.areanum + ", " + locationInfo.locationIndex.x + ", " + locationInfo.locationIndex.y);
        }
        public void InitRoomRel()
        {
            roomRel.left = null;
            roomRel.right = null;
            roomRel.top = null;
            roomRel.bottom = null;

            roomRel.leftAisle = null;
            roomRel.rightAisle = null;
            roomRel.topAisle = null;
            roomRel.bottomAisle = null;
        }
        public CoupleInt GetRoomLoca()
        {
            return locationInfo.locationIndex;
        }
        public int GetRoomAreaNum()
        {
            return locationInfo.areanum;
        }
        public RoomRelation GetRoomRel()
        {
            return roomRel;
        }

    }
}
