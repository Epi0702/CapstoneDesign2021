using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapAlgo
{

    public class PassageData
    {
        LocationData locationInfo = new LocationData();
        public PassageEventType passageevent = PassageEventType.None;
        
        public PassageData()
        {
            locationInfo = new LocationData();
        }
        public void SetPassageLoca(int _x, int _y)
        {
            locationInfo.locationIndex.x = _x;
            locationInfo.locationIndex.y = _y;
        }

        public string GetLoca()
        {
            return (locationInfo.locationIndex.x + ", " + locationInfo.locationIndex.y);
        }
        public CoupleInt GetRoomLoca()
        {
            return locationInfo.locationIndex;
        }
    }
}
