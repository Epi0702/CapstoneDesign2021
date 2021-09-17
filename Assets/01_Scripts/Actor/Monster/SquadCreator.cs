using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadCreator : MonoBehaviour
{
    public const string squadPath = "Prefabs/Monster/Squad";
    Dictionary<string, GameObject> squadFileCache = new Dictionary<string, GameObject>();
    // Start is called before the first frame update
    public GameObject Load(string resourcePath)
    {
        GameObject go = null;

        if (squadFileCache.ContainsKey(resourcePath))
        {
            go = squadFileCache[resourcePath];
        }

        else
        {
            go = Resources.Load<GameObject>(resourcePath);
            if (!go)
            {
                Debug.LogError("Load error! path = " + resourcePath);
                return null;
            }
            squadFileCache.Add(resourcePath, go);

        }
        return go;
    }
}
