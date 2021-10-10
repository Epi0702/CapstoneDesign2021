using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    private static SystemManager instance;

    public static SystemManager Instance        //singleT
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(SystemManager)) as SystemManager;

                if (instance == null)
                    Debug.Log("no Singleton obj");
            }
            return instance;
        }
    }
    BaseSceneMain currentSceneMain;
    public BaseSceneMain CurrentSceneMain
    {
        set
        {
            Debug.Log("!!Input Start");
            currentSceneMain = value;
            if (currentSceneMain == null)
                Debug.Log("!!");
            else
                Debug.Log("!!"+currentSceneMain.GetType());
        }
    }
    [SerializeField]
    MonsterTable monsterTable;
    public MonsterTable MonsterTable
    {
        get
        {
            return monsterTable;
        }
    }
    [SerializeField]
    ItemTable itemTable;
    public ItemTable ItemTable
    {
        get
        {
            return itemTable;
        }
    }

    [SerializeField]
    TestSceneMain testSceneMain;
    public TestSceneMain TestSceneMain
    {
        get
        {
            return testSceneMain;
        }
    }  
    [SerializeField]
    JsonParse jsonParse;
    public JsonParse JsonParse
    {
        get
        {
            return jsonParse;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.LogError("SystemManager is initialized twice!");
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);


    }
    void Start()
    {
        BaseSceneMain baseSceneMain = GameObject.FindObjectOfType<BaseSceneMain>();
        Debug.Log("OnSceneLoaded! baseSceneMain.name = " + baseSceneMain.name);
        SystemManager.Instance.CurrentSceneMain = baseSceneMain;
    }
    public T GetCurrentSceneMain<T>() where T : BaseSceneMain
    {
        return currentSceneMain as T;
    }

}
