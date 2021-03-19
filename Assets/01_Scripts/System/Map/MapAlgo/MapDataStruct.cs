using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapAlgo
{
    public enum RoomEventType
    {
        None,
        Battle,
    }
    public struct RoomRelation
    {
        public RoomData left;
        public RoomData right;
        public RoomData top;
        public RoomData bottom;

        public AisleData leftAisle;
        public AisleData rightAisle;
        public AisleData topAisle;
        public AisleData bottomAisle;
    }
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
    public  class MapDataStruct
    {
    }
}
