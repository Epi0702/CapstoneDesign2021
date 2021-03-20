using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    void Awake()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float scaleheignt = ((float)Screen.width / Screen.height) / ((float)16 / 9);        //가로/세로
        float scalewidth = 1f / scaleheignt;
        if (scaleheignt < 1)
        {
            rect.height = scaleheignt;
            rect.y = (1f - scaleheignt) / 2f;
        }
        else
        {
            rect.width = scalewidth;
            rect.x = (1f - scalewidth) / 2f;
        }
        camera.rect = rect;
    }
}
