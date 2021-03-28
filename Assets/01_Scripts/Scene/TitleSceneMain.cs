using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneMain : BaseSceneMain
{
    public GameObject LoginPanel;

    public void ChangeLoginScene()
    {
        LoginPanel.SetActive(true);
    }
}
