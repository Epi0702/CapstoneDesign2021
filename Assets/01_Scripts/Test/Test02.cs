using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test02 : MonoBehaviour
{
    string func1 = "HelloWorld";
    string func2 = "ByeWorld";


    // Start is called before the first frame update
    void Start()
    {
        Invoke(func2, 0);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void HelloWorld()
    {
        Debug.Log("Hello, World!!");
    }
    void ByeWorld()
    {
        Debug.Log("GoodBye, World");
    }
}
