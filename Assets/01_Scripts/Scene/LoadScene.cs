using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SceneName
{
    TitleScene = 0,
    CustomizingScene = 1,
    MainMenuScene = 2,
    InGameScene = 3,
}

public class LoadScene : MonoBehaviour
{
    public Slider loadingSlider;
    //public GameObject Img;
    //public SceneName currentSceneIndex;


    //private static LoadScene instance;
    //public static LoadScene Instance        //singleT
    //{
    //    get
    //    {
    //        if (!instance)
    //        {
    //            instance = FindObjectOfType(typeof(LoadScene)) as LoadScene;

    //            if (instance == null)
    //                Debug.Log("no Singleton obj");
    //        }
    //        return instance;
    //    }
    //}
    //private void Awake()
    //{
    //    if (instance != null)
    //    {
    //        Debug.LogWarning("Can't have two instance of singletone");
    //        DestroyImmediate(this);
    //        return;
    //    }
    //    instance = this;
    //    DontDestroyOnLoad(this);
    //}

    public void SceneLoader(/*SceneName scenenameint*/ int sceneindex)
    {
        //Img.SetActive(true);
        StartCoroutine(LoadAsynchronously(sceneindex));
    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingSlider.value = progress;

            yield return null;
        }
        //Img.SetActive(false);
    }
    public void SetSceneManager()
    {
        BaseSceneMain baseSceneMain = GameObject.FindObjectOfType<BaseSceneMain>();
        SystemManager.Instance.CurrentSceneMain = baseSceneMain;
      
    }
}
