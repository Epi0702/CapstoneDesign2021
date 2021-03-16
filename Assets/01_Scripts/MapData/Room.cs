using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapData
{
    enum RoomEventType
    {
        None,
        Battle,
    }
    struct RoomRelation
    {
        public Room left;
        public Room right;
        public Room top;
        public Room bottom;

        public Aisle leftAisle;
        public Aisle rightAisle;
        public Aisle topAisle;
        public Aisle bottomAisle;
    }
    class Room
    {
        Location locationInfo = new Location();
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
        public void PrintRoomInfo()
        {
            Debug.Log("Room Num : " + locationInfo.areanum + ", " + locationInfo.locationIndex.x+ ", " + locationInfo.locationIndex.y);
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
    }
}
