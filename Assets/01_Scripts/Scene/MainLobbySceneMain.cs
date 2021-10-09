using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainLobbySceneMain : BaseSceneMain
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
    // Start is called before the first frame update
    protected override void OnAwake()
    {
        base.OnAwake();
    }
    protected override void OnStart()
    {
        base.OnStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Test()
    {
        loadScene.gameObject.SetActive(true);
        loadScene.SceneLoader(3);
        //LoadScene.Instance.SceneLoader(SceneName.InGameScene);
    }
}
