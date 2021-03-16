using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapData
{
    enum MapSize
    {
        TwobyTwo = 2,
        ThreebyThree = 3,
        FourbyFour = 4,
    };
    enum AreaSize
    {
        SixbySix = 6,
        NinebyNine = 9,
    };
    class Map
    {
        List<Room> rooms = new List<Room>();
        List<Aisle> passages = new List<Aisle>();
        MapSize settedMapSize;
        AreaSize settedAreaSize;
        int startRoomIndex;
        public void InitMap(MapSize _mapsize, AreaSize _areasize)
        {
            settedMapSize = _mapsize;
            settedAreaSize = _areasize;
            GenerateRooms(_mapsize, _areasize);
            SetMapPatternVH();
            ConnectRooms(_mapsize);
            Debug.Log("Map Initialize Complete!!");
        }
        void GenerateRooms(MapSize _mapSize, AreaSize _areaSize)
        {
            for (int i = 0; i < ((int)_mapSize * (int)_mapSize); i++)
            {
                CoupleInt temp;
                temp.x = (i % (int)_mapSize) * (int)_areaSize + (i % (int)_mapSize);
                temp.y = (i / (int)_mapSize) * (int)_areaSize + (i / (int)_mapSize);
                CreateRoom(i, _areaSize, temp);
                rooms[i].PrintRoomInfo();
            }
        }
        void CreateRoom(int _areaNum, AreaSize _areasize, CoupleInt _arealocation)
        {
            Room room = new Room();
            CoupleInt rand;
            rand.x = Random.Range(1, (int)_areasize - 1);
            rand.y = Random.Range(1, (int)_areasize - 1);

            room.SetRoomLocation(_areaNum, _arealocation, rand);
            room.InitRoomRel();
            rooms.Add(room);
        }
        void SetMapPatternVH()      //vertical horizontal
        {
            int rand = 0;
            //rand = Random.Range(0, 2);
            Debug.Log("Pattern Rand num : " + rand);
            switch (rand)
            {
                case 0:
                    VerticalRoomRel();
                    break;
                case 1:
                    HorizontalRoomRel();
                    break;
                default:
                    Debug.LogError("pattern num error!!");
                    break;
            }
        }
        void VerticalRoomRel()
        {
            for (int i = 0; i < rooms.Count - (int)settedMapSize; i++)
            {
                rooms[i].roomRel.bottom = rooms[i + (int)settedMapSize];
                rooms[i + (int)settedMapSize].roomRel.top = rooms[i];
            }
        }
        void HorizontalRoomRel()
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i % (int)settedMapSize !=0 && i % (int)settedMapSize != (int)settedMapSize - 1)
                {
                    rooms[i].roomRel.left = rooms[i - 1];
                    rooms[i].roomRel.right = rooms[i + 1];
                }
                else if(i%(int)settedMapSize == 0)
                {
                    rooms[i].roomRel.right = rooms[i + 1];
                }
                else if(i % (int)settedMapSize == (int)settedMapSize -1)
                {
                    rooms[i].roomRel.left = rooms[i - 1];
                }
            }
        }
        void GenerateAisle(Room _startRoom, Room _endRoom)
        {
            Aisle temp = new Aisle();

            temp.SetInfo(_startRoom, _endRoom, settedAreaSize, settedMapSize);
            temp.GeneratePassage();
            passages.Add(temp);
        }
        void ConnectRooms(MapSize _mapsize)
        {
            for(int i = 0; i< ((int)_mapsize * (int)_mapsize); i++)
            {
                if (rooms[i].roomRel.left != null)
                    GenerateAisle(rooms[i], rooms[i].roomRel.left);
                if (rooms[i].roomRel.bottom != null)
                    GenerateAisle(rooms[i], rooms[i].roomRel.bottom);
            }
        }
        void SetStartRoomIndex()
        {

        }
    }
}
