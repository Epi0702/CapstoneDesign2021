using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest03 : MonoBehaviour
{

    Transform temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = this.transform;
        Instantiate(Resources.Load<GameObject>("Prefabs/Test/Cube"), temp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
