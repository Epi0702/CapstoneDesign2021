using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderTest : MonoBehaviour
{
    LivingEntity monster;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log(monster.GetType());
        SystemManager.Instance.GetCurrentSceneMain<TestSceneMain>().target = monster;
    }
}
