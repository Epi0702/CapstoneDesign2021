using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapAlgo
{
    enum LocationCategory
    {
        CT_None,
        CT_Room,
        CT_Passage,
    }
    public struct CoupleInt
    {
        public int x;
        public int y;
    }
    class LocationData
    {
        public int areanum { get; set; }             //구획번호
        public CoupleInt locationIndex;       //좌표
        public LocationCategory loCT;     //방종류

        public LocationData()
        {
            this.InitLocation();
        }
        public void InitLocation()
        {
            areanum = 0;
            locationIndex.x = 0;
            locationIndex.y = 0;
            loCT = LocationCategory.CT_None;
        }
        public virtual void SetLocation(int _num, int _x, int _y, LocationCategory _loCT)
        {
            areanum = _num;
            locationIndex.x = _x;
            locationIndex.y = _y;
            loCT = _loCT;
        }
        public virtual void SetLocation(int _num ,CoupleInt _locationXY, LocationCategory _loCT)
        {
            areanum = _num;
            locationIndex = _locationXY;
            loCT = _loCT;
        }
        
    }
}
