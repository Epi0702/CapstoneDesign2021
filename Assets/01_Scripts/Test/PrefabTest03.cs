using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest03 : MonoBehaviour
{
    [SerializeField]
    GameObject Prefab;

    Transform temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = this.transform;
        Instantiate(Resources.Load<GameObject>("Prefabs/Cube"), temp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
