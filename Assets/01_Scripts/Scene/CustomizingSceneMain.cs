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
    LoadScene loadScene;
    public LoadScene LoadScene
    {
        get
        {
            return loadScene;
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
    public void MoveToMainLobbyScene()
    {
        loadScene.gameObject.SetActive(true);
        loadScene.SceneLoader(2);
        //LoadScene.Instance.SceneLoader(SceneName.MainMenuScene);
    }
}
