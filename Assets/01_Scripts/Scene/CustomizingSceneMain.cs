using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizingSceneMain : BaseSceneMain
{
    [SerializeField]
    Playerlook playerLook;
    public Playerlook Playerlook
    {
        get
        {
            return playerLook;
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
