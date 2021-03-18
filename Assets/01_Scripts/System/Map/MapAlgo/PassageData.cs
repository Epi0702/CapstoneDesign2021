using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapAlgo
{
    enum PassageEventType
    {

    }
    class PassageData
    {
        LocationData locationInfo;// = new Location();
        PassageEventType passageevent;
        
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
    }
}
