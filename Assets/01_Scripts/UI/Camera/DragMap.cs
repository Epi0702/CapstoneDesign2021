using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMap : MonoBehaviour
{
    private float dist = -10;
    private Vector3 MouseStart;
    private Vector3 derp;
    [SerializeField]
    float speed;
    void Start()
    {
        //dist = -10;  // Distance camera is above map
        dist = transform.position.z;  // Distance camera is above map
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            MouseStart = Camera.main.ScreenToWorldPoint(MouseStart);
            MouseStart.z = transform.position.z;

        }
        else if (Input.GetMouseButton(0))
        {
            var MouseMove = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
            MouseMove = Camera.main.ScreenToWorldPoint(MouseMove);
            MouseMove.z = transform.position.z;
            transform.position = transform.position - (MouseMove - MouseStart);

            MouseStart = MouseMove;
        }
    }
}
//transform.position -= new Vector3(MouseMove.x - MouseStart.x, MouseMove.y - MouseStart.y, 0);

