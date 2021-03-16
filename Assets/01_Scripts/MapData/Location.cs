using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapData
{
    enum LocationCategory
    {
        CT_None,
        CT_Room,
        CT_Passage,
    }
    struct CoupleInt
    {
        public int x;
        public int y;
    }
    class Location
    {
        public int areanum;               //구획번호
        public CoupleInt locationIndex;       //좌표
        public LocationCategory loCT;     //방종류

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
