using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameSceneMain : BaseSceneMain
{
    [SerializeField]
    MapManager mapmanager;
    public MapManager MapManager
    {
        get
        {
            return mapmanager;
        }
    }
    [SerializeField]
    UIMapViewer uiMapViewer;
    public UIMapViewer UIMapViewer
    {
        get
        {
            return uiMapViewer;
        }
    }
    [SerializeField]
    Player player;
    public Player Hero
    {
        get
        {
            if (!player)
            {
                Debug.LogError("Main Player is not setted!");
            }

            return player;
        }
    }
    protected override void OnAwake()
    {
        base.OnAwake();
    }
    protected override void OnStart()
    {
        base.OnStart();
    }

    protected override void UpdateScene()
    {
        base.UpdateScene();
    }
}
