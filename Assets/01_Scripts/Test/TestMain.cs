﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMain : MonoBehaviour
{
    private static TestMain instance;

    public static TestMain Instance        //singleT
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(TestMain)) as TestMain;

                if (instance == null)
                    Debug.Log("no Singleton obj");
            }
            return instance;
        }
    }
    [SerializeField]
    MapManager mapmanager;
    public MapManager MapManager
    {
        get
        {
            return mapmanager;
        }
    }
}