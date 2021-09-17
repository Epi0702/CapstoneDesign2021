using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapAlgo
{

    public class RoomData
    {
        LocationData locationInfo = new LocationData();
        public RoomEventType roomevent = RoomEventType.None;

        public RoomRelation roomRel;

        public Squad squad;
        public int squadTypeNum;
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

            squadTypeNum = UnityEngine.Random.Range(0,4);
        }

        //mapmanager 에서 맵뷰 room 에 초기 정보 전달
        public void SetRoomLocation(CoupleInt _areaLoaction, RoomRelation _roomRel)
        {
            locationInfo.locationIndex = _areaLoaction;
            roomRel = _roomRel;
        }
        public void PrintRoomInfo()
        {
            //Debug.Log("Room Num : " + locationInfo.areanum + ", " + locationInfo.locationIndex.x + ", " + locationInfo.locationIndex.y+"  "+ roomevent);
            //Debug.Log("Room NUM : " + locationInfo.areanum+"  "+ roomevent);
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

            squad = null;
        }
        public CoupleInt GetRoomLoca()
        {
            return locationInfo.locationIndex;
        }
        public bool CompareRoomLoca(CoupleInt coupleInt)
        {
            if (this.GetRoomLoca().x == coupleInt.x && this.GetRoomLoca().y == coupleInt.y)
                return true;
            else
                return false;
        }
        public int GetRoomAreaNum()
        {
            return locationInfo.areanum;
        }
        public RoomRelation GetRoomRel()
        {
            return roomRel;
        }
        public AisleData GetAisle(RoomData _targetRoom)
        {
            if (roomRel.left == _targetRoom)
            {
                return roomRel.leftAisle;
            }
            else if (roomRel.right == _targetRoom)
            {
                return roomRel.rightAisle;
            }
            else if (roomRel.top == _targetRoom)
            {
                return roomRel.topAisle;
            }
            else if (roomRel.bottom == _targetRoom)
            {
                return roomRel.bottomAisle;
            }
            else
            {
                Debug.LogError("null ERROR!!");
                return null;
            }
        }
        public void SetRoomEvent()
        {
            int rand;
            rand = Random.Range(0, 10);
            if (rand > 4)
            {
                this.roomevent = RoomEventType.Battle;
            }
            else
            {
                this.roomevent = RoomEventType.None;
            }
        }

    }
}
