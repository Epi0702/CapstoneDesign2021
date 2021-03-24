using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizingSceneMain : BaseSceneMain
{
    [SerializeField]
    Playerlook playerLook;
    public Playerlook playerlook
    {
        get
        {
            return playerlook;
        }
    }

    [SerializeField]
    ClassSelectPanel classSelectPanel;
    public ClassSelectPanel ClassSelectPanel
    {
        get
        {
            return classSelectPanel;
        }
    }
    protected override void OnAwake()
    {

    }
    protected override void OnStart()
    {

    }
    protected override void UpdateScene()
    {

    }
}
