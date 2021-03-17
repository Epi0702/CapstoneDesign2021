using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapData;

public class MapViewer : MonoBehaviour
{
    Map _gameWorld;


    // Start is called before the first frame update
    void Start()
    {
        _gameWorld = TestMain.Instance.MapManager.gameWorld;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
