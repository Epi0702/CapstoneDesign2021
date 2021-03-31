using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 1.0f;
    [SerializeField]
    int maxSize;
    [SerializeField]
    int minSize;

    private Camera mainCamera;


    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        Zoom();
    }

    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * (-1) * zoomSpeed;
        //if (distance != 0)
        //{

        //}
        if (mainCamera.orthographicSize >= minSize && mainCamera.orthographicSize <= maxSize)
        {
            mainCamera.orthographicSize += distance;
        }
        else if (mainCamera.orthographicSize < minSize)
        {
            if (distance > 0)
                mainCamera.orthographicSize += distance;
        }
        else if (mainCamera.orthographicSize > maxSize)
        {
            if (distance < 0)
                mainCamera.orthographicSize += distance;

        }
    }

}