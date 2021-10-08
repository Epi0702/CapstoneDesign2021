using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;


public class DataController : MonoBehaviour
{
    static GameObject _container;
    static GameObject Container
    {
        get
        {
            return _container;
        }
    }
    static DataController _instance;
    public static DataController Instance
    {
        get
        {
            if (!_instance)
            {
                _container = new GameObject();
                _container.name = "DataController";
                _instance = _container.AddComponent(typeof(DataController)) as DataController;
                DontDestroyOnLoad(_container);
                if (_instance == null)
                    Debug.Log("no DataController!!");
            }
            return _instance;
        }
    }

    public string GameDataFileName = "TRPGSAVE.json";
    public GameData _gameDAta;
    public JsonParse _jsonP;
    public GameData gameData
    {
        get
        {
            if (_gameDAta == null)
            {
                LoadGameData();
                SaveGameData();
            }
            return _gameDAta;
        }
    }
    public void LoadGameData()
    {
        string filePath = Application.persistentDataPath + GameDataFileName;

        if (File.Exists(filePath))
        {
            Debug.Log("Load Success!!");
            string FromJsonData = File.ReadAllText(filePath);
            _gameDAta = JsonUtility.FromJson<GameData>(FromJsonData);
            //_jsonP.LoadCharacter();
        }
        else
        {
            Debug.Log("새로운 파일 생성");

            _gameDAta = new GameData();
        }
    }
    public void SaveGameData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + GameDataFileName;
        File.WriteAllText(filePath, ToJsonData);
        Debug.Log("Save Success!!");
    }
    private void OnApplicationQuit()
    {
        Debug.Log("Quit Auto Save");
        SaveGameData();
    }    
}


