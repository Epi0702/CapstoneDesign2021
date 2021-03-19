using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapAlgo;


public class MapManager : MonoBehaviour
{
    public MapData gameWorld;
    void Awake()
    {
        gameWorld = new MapData();
        gameWorld.InitMap(MapSize.ThreebyThree, AreaSize.NinebyNine);
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }

}


