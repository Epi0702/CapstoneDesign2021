﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapData
{
    //upper class than passage
    class Aisle
    {
        Room startRoom;
        Room endRoom;
        int areasize;
        int mapsize;
        List<Passage> passage = new List<Passage>();

        public void SetInfo(Room _startroom, Room _endroom, AreaSize _areasize, MapSize _mapsize)
        {
            areasize = SetAreaSize(_areasize);
            mapsize = SetMapSize(_mapsize);
            startRoom = _startroom;
            endRoom = _endroom;
        }
        void CreatePassage(int _x, int _y)
        {
            Passage temppassage = new Passage();
            temppassage.SetPassageLoca(_x, _y);
            passage.Add(temppassage);
        }
        public void GeneratePassage()
        {
            Debug.Log("Start!!!");
            if (startRoom.roomRel.left == endRoom)
            {
                ConnectHorizontal(endRoom, startRoom);
            }
            //else if (startRoom.roomRel.right == endRoom)
            //{
            //    ConnectHorizontal(startRoom, endRoom);
            //}
            //else if (startRoom.roomRel.top == endRoom)
            //{
            //    ConnectVertial(endRoom, startRoom);
            //}
            else if (startRoom.roomRel.bottom == endRoom)
            {
                ConnectVertial(startRoom, endRoom);
            }
            else
            {
                Debug.LogError("PassageInfo Error!!" + startRoom.GetRoomAreaNum());
            }
            Debug.Log("End!!!");
            for (int i = 0; i < passage.Count; i++)
            {
                Debug.Log("(" + passage[i].GetLoca() + ")");
            }
        }
        int SetAreaSize(AreaSize _areasize)
        {
            return (int)_areasize;
        }
        int SetMapSize(MapSize _mapsize)
        {
            return (int)_mapsize;
        }
        void ConnectHorizontal(Room _startroom, Room _endroom)
        {
            for (int i = _startroom.GetRoomLoca().x + 1;
                 i <= (_startroom.GetRoomAreaNum() % mapsize) * (areasize + 1) + (areasize - 1); i++)
            {
                CreatePassage(i, _startroom.GetRoomLoca().y);
            }

            if (_startroom.GetRoomLoca().y <= _endroom.GetRoomLoca().y)        //start 가 아래
            {
                for (int i = _startroom.GetRoomLoca().y; i <= _endroom.GetRoomLoca().y; i++)
                {
                    CreatePassage((_startroom.GetRoomAreaNum() % mapsize) * (areasize + 1) + areasize, i);
                }
            }
            else    //start가 위
            {
                for (int i = _startroom.GetRoomLoca().y; i >= _endroom.GetRoomLoca().y; i--)
                {
                    CreatePassage((_startroom.GetRoomAreaNum() % mapsize) * (areasize + 1) + areasize, i);
                }
            }
            for (int i = (_startroom.GetRoomAreaNum() % mapsize + 1) * (areasize + 1); i < _endroom.GetRoomLoca().x; i++)
            {
                CreatePassage(i, _endroom.GetRoomLoca().y);
            }
        }
        void ConnectVertial(Room _startroom, Room _endroom)
        {
            for (int i = _startroom.GetRoomLoca().y + 1;
                i <= (_startroom.GetRoomAreaNum() / mapsize) * (areasize + 1) + (areasize - 1); i++)
            {
                CreatePassage(_startroom.GetRoomLoca().x, i);
            }
            if (_startroom.GetRoomLoca().x <= _endroom.GetRoomLoca().x)    //start가 왼쪽
            {
                for (int i = _startroom.GetRoomLoca().x; i <= _endroom.GetRoomLoca().x; i++)
                {
                    CreatePassage(i, (_startroom.GetRoomAreaNum() / mapsize) * (areasize + 1) + areasize);
                }
            }
            else
            {
                {
                    for (int i = _startroom.GetRoomLoca().x; i >= _endroom.GetRoomLoca().x; i--)
                    {
                        CreatePassage(i, (_startroom.GetRoomAreaNum() / mapsize) * (areasize + 1) + areasize);
                    }
                }
            }
            for (int i = (_startroom.GetRoomAreaNum() / mapsize + 1) * (areasize + 1); i < _endroom.GetRoomLoca().y; i++)
            {
                CreatePassage(_endroom.GetRoomLoca().x, i);
            }
        }
    }
}

