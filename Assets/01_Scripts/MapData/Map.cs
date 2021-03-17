using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapData
{
    public enum MapSize
    {
        TwobyTwo = 2,
        ThreebyThree = 3,
        FourbyFour = 4,
    };
    public enum AreaSize
    {
        SixbySix = 6,
        NinebyNine = 9,
    };
    public class Map
    {
        List<Room> rooms = new List<Room>();
        List<Aisle> passages = new List<Aisle>();
        MapSize settedMapSize;
        AreaSize settedAreaSize;
        int startRoomIndex;
        int endRoomIndex;
        int mapPatternVH;
        public void InitMap(MapSize _mapsize, AreaSize _areasize)
        {
            settedMapSize = _mapsize;
            settedAreaSize = _areasize;
            GenerateRooms(_mapsize, _areasize);
            SetMapPatternVH();

            SetStartEndRoomIndex();
            SecondConnectRooms();
            Debug.Log(startRoomIndex + "^^" + endRoomIndex);
            ConnectRooms(_mapsize);
            Debug.Log("Map Initialize Complete!!");
            PrintRoomRel();
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
        void SetMapPatternVH()      //vertical(세로) horizontal(가로)
        {
            int rand = 1;
            //rand = Random.Range(0, 2);
            mapPatternVH = rand;
            Debug.Log("Pattern Rand num : " + rand);
            switch (mapPatternVH)
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
                if (i % (int)settedMapSize != 0 && i % (int)settedMapSize != (int)settedMapSize - 1)
                {
                    rooms[i].roomRel.left = rooms[i - 1];
                    rooms[i].roomRel.right = rooms[i + 1];
                }
                else if (i % (int)settedMapSize == 0)
                {
                    rooms[i].roomRel.right = rooms[i + 1];
                }
                else if (i % (int)settedMapSize == (int)settedMapSize - 1)
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
            for (int i = 0; i < ((int)_mapsize * (int)_mapsize); i++)
            {
                if (rooms[i].roomRel.left != null)
                    GenerateAisle(rooms[i], rooms[i].roomRel.left);
                if (rooms[i].roomRel.bottom != null)
                    GenerateAisle(rooms[i], rooms[i].roomRel.bottom);
            }
        }
        void SetStartEndRoomIndex()
        {
            int startroomrand = Random.Range(0, 4);
            int endroomrand = Random.Range(0, 2);
            int[] side = new int[4];
            side[0] = 0;
            side[1] = (int)settedMapSize - 1; ;
            side[2] = (int)settedMapSize * ((int)settedMapSize - 1); ;
            side[3] = (int)settedMapSize * (int)settedMapSize - 1; ;

            switch (startroomrand)
            {
                case 0:
                    startRoomIndex = side[0];
                    break;
                case 1:
                    startRoomIndex = side[1];
                    break;
                case 2:
                    startRoomIndex = side[2];
                    break;
                case 3:
                    startRoomIndex = side[3];
                    break;
            }
            if (mapPatternVH == 0)
            {
                if (startRoomIndex == side[0] || startRoomIndex == side[2])
                {
                    if (endroomrand == 0)
                        endRoomIndex = side[1];
                    else
                        endRoomIndex = side[3];
                }
                else if (startRoomIndex == side[1] || startRoomIndex == side[3])
                {
                    if (endroomrand == 0)
                        endRoomIndex = side[0];
                    else
                        endRoomIndex = side[2];
                }
            }
            else if (mapPatternVH == 1)
            {
                if (startRoomIndex == side[0] || startRoomIndex == side[1])
                {
                    if (endroomrand == 0)
                        endRoomIndex = side[2];
                    else
                        endRoomIndex = side[3];
                }
                else if (startRoomIndex == side[2] || startRoomIndex == side[3])
                {
                    if (endroomrand == 0)
                        endRoomIndex = side[0];
                    else
                        endRoomIndex = side[1];
                }
            }
        }
        public virtual int GetRandomNumWithout(int _startNum, int _endNum, int _withoutNum)
        {
            int rand = Random.Range(_startNum, _endNum);
            if (rand == _withoutNum)
            {
                return GetRandomNumWithout(_startNum, _endNum, _withoutNum);
            }
            else
                return rand;
        }
        void SecondConnectRooms()
        {
            int rand;
            int tempindex;
            if (mapPatternVH == 0)
            {
                for (int i = 0; i < (int)settedMapSize - 1; i++)
                {
                    if (rooms[startRoomIndex].GetRoomAreaNum() % (int)settedMapSize == i)   //ok
                    {
                        rand = GetRandomNumWithout(0, (int)settedMapSize, startRoomIndex / (int)settedMapSize);
                        tempindex = rand * (int)settedMapSize + i;
                        rooms[tempindex].roomRel.right = rooms[tempindex + 1];
                        rooms[tempindex + 1].roomRel.left = rooms[tempindex];
                    }
                    else if (rooms[endRoomIndex].GetRoomAreaNum() % (int)settedMapSize == i)    //ok
                    {
                        rand = GetRandomNumWithout(0, (int)settedMapSize, endRoomIndex / (int)settedMapSize);
                        tempindex = rand * (int)settedMapSize + i;
                        rooms[tempindex].roomRel.right = rooms[tempindex + 1];
                        rooms[tempindex + 1].roomRel.left = rooms[tempindex];
                    }
                    else if (i == (int)settedMapSize - 2)
                    {
                        int temp = 0;
                        if(startRoomIndex %(int)settedMapSize == i+1)
                        {
                            temp = startRoomIndex / (int)settedMapSize;
                        }
                        else if(endRoomIndex %(int)settedMapSize == i+1)
                        {
                            temp = endRoomIndex / (int)settedMapSize;
                        }
                        rand = GetRandomNumWithout(0, (int)settedMapSize, temp);
                        tempindex = rand * (int)settedMapSize + i;
                        rooms[tempindex].roomRel.right = rooms[tempindex + 1];
                        rooms[tempindex + 1].roomRel.left = rooms[tempindex];
                    }
                    else
                    {
                        rand = Random.Range(0, (int)settedMapSize);
                        tempindex = rand * (int)settedMapSize + i;
                        rooms[tempindex].roomRel.right = rooms[tempindex + 1];
                        rooms[tempindex + 1].roomRel.left = rooms[tempindex];
                    }
                }
            }
            else if (mapPatternVH == 1)
            {
                for (int i = 0; i < (int)settedMapSize - 1; i++)
                {
                    if (rooms[startRoomIndex].GetRoomAreaNum() / (int)settedMapSize == i)
                    {
                        rand = GetRandomNumWithout(0, (int)settedMapSize, startRoomIndex % (int)settedMapSize);
                        tempindex = i * (int)settedMapSize + rand;
                        rooms[tempindex].roomRel.bottom = rooms[tempindex + (int)settedMapSize];
                        rooms[tempindex + (int)settedMapSize].roomRel.top = rooms[tempindex];
                    }
                    else if (rooms[endRoomIndex].GetRoomAreaNum() / (int)settedMapSize == i)
                    {
                        rand = GetRandomNumWithout(0, (int)settedMapSize, endRoomIndex / (int)settedMapSize);
                        tempindex = i * (int)settedMapSize + rand;
                        rooms[tempindex].roomRel.bottom = rooms[tempindex + (int)settedMapSize];
                        rooms[tempindex + (int)settedMapSize].roomRel.top = rooms[tempindex];
                    }
                    else if (i == (int)settedMapSize - 2)
                    {
                        Debug.Log("case03");
                        int temp = 0;
                        if(startRoomIndex / (int)settedMapSize == (i+1))
                        {
                            Debug.Log(startRoomIndex);

                            temp = startRoomIndex % (int)settedMapSize;
                        }  
                        else if(endRoomIndex / (int)settedMapSize == (i+1))
                        {
                            Debug.Log(endRoomIndex);
                            temp = endRoomIndex % (int)settedMapSize;
                        }
                        Debug.Log(temp);
                        rand = GetRandomNumWithout(0, (int)settedMapSize, temp);
                        Debug.Log(rand);
                        tempindex = i * (int)settedMapSize + rand;
                        rooms[tempindex].roomRel.bottom = rooms[tempindex + (int)settedMapSize];
                        rooms[tempindex + (int)settedMapSize].roomRel.top = rooms[tempindex];
                    }
                    else
                    {
                        rand = Random.Range(0, (int)settedMapSize);
                        tempindex = i * (int)settedMapSize + rand;
                        rooms[tempindex].roomRel.bottom = rooms[tempindex + (int)settedMapSize];
                        rooms[tempindex + (int)settedMapSize].roomRel.top = rooms[tempindex];
                    }
                }
            }
        }
        public int GetRoomCount()
        {
            return rooms.Count;
        }
        public int GetAisleCount()
        {
            return passages.Count;
        }
        public int GetPassageCount(int _index)
        {
            return passages[_index].GetPassageCount();
        }
        void PrintRoomRel()
        {
            for(int i = 0; i<(int)settedMapSize * (int)settedMapSize; i++)
            {
                //if(rooms[i].roomRel.left !=null)
                //    Debug.Log("room:" + i + ", left" + rooms[i].roomRel.left.GetRoomAreaNum());
                //if(rooms[i].roomRel.right !=null)
                //    Debug.Log("room:" + i + ", right" + rooms[i].roomRel.right.GetRoomAreaNum());
                //if(rooms[i].roomRel.top !=null)
                //    Debug.Log("room:" + i + ", top" + rooms[i].roomRel.top.GetRoomAreaNum());
                //if(rooms[i].roomRel.bottom !=null)
                //    Debug.Log("room:" + i + ", bottom" + rooms[i].roomRel.bottom.GetRoomAreaNum());
               // rooms[i].SetPosition(100);
            }
        }
    }
}
