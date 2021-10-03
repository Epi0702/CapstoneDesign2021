﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneMain : BaseSceneMain
{
    [SerializeField]
    LoadScene loadScene;
    public LoadScene LoadScene
    {
        get
        {
            return loadScene;
        }
    }

    private string userID;
    private string userPW;

    protected override void OnStart()
    {
        userID = DataController.Instance.gameData.User_id;
        userPW = DataController.Instance.gameData.PW;
    }

    public void MoveToCustomizingScene()
    {
        loadScene.gameObject.SetActive(true);
        loadScene.SceneLoader(1);
    }

    public void MoveToMainLobbyScene()
    {
        loadScene.gameObject.SetActive(true);
        SceneManager.LoadScene("MainLobbyScene");
    }
}
