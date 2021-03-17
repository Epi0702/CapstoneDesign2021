using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapData;


public class MapManager : MonoBehaviour
{
    CoupleInt rand;
    Map gameWorld;
    int num;
    [SerializeField]
    PrefabCacheData[] Rooms;
    [SerializeField]
    PrefabCacheData[] Passage;

    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        gameWorld = new Map();
        gameWorld.InitMap(MapSize.ThreebyThree, AreaSize.NinebyNine);
        Debug.Log("Map Initialize Complete!!");

    }
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.R))
    //    {

    //    }
    //}
    public void Prepare()
    {
        for(int i = 0; i< Rooms.Length; i++)
        {

        }
    }
}


