using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneMain : BaseSceneMain
{
    private string userID;
    private string userPW;
    [SerializeField]
    LoadScene loadScene;
    public LoadScene LoadScene
    {
        get
        {
            return loadScene;
        }
    }
    protected override void OnStart()
    {
        base.OnStart();
        userID = DataController.Instance.gameData.User_id;
        userPW = DataController.Instance.gameData.PW;
    }

    public void MoveToCustomizingScene()
    {
        //LoadScene.Instance.SceneLoader(SceneName.CustomizingScene);
        loadScene.gameObject.SetActive(true);
        loadScene.SceneLoader(1);
    }

    public void MoveToMainLobbyScene()
    {
        loadScene.gameObject.SetActive(true);
        SceneManager.LoadScene("MainLobbyScene");
        //LoadScene.Instance.SceneLoader(SceneName.MainMenuScene);
    }
}
