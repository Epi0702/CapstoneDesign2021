using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test02 : MonoBehaviour
{
    Test01 test;
    // Start is called before the first frame update
    void Start()
    {
        test = GetComponent<Test01>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            test.Score++;
            test.PrintScore();
        }
    }
}
