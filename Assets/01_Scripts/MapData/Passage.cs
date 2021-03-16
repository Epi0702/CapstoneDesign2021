using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapData
{
    enum PassageEventType
    {

    }
    class Passage
    {
        Location locationInfo;// = new Location();
        PassageEventType passageevent;
        
        public Passage()
        {
            locationInfo = new Location();
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
