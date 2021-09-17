using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadController : MonoBehaviour
{
    [SerializeField]
    SquadCreator squadCreator;

    List<Squad> squads = new List<Squad>();

    [SerializeField]
    PrefabCacheData[] squadFiles;

    public List<Squad> Squads
    {
        get
        {
            return Squads;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Prepare();
    }
    public void Prepare()
    {
        for(int i = 0; i< squadFiles.Length; i++)
        {
            
            GameObject go = squadCreator.Load(squadFiles[i].filePath);
            Debug.Log(squadFiles[i].filePath);
            Debug.Log(squadFiles[i].cacheCount);
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().PrefabCacheSystem.GenerateCache(squadFiles[i].filePath, go, squadFiles[i].cacheCount);
        }
    }
}
