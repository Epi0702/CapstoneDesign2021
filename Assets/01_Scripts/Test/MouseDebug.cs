using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDebug : MonoBehaviour
{
    Vector3 mouseposition;
    // Start is called before the first frame update
    void Start()
    {
        mouseposition = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        touchClick();
    }
    void touchClick()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit hit;

        //    Ray touchray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    Physics.Raycast(touchray, out hit);
        //    if (hit.collider != null)
        //    {
        //        Debug.Log(hit.collider.gameObject.name);
        //    }

        //}
        if(Input.GetMouseButtonDown(0))
        {
            mouseposition = Input.mousePosition;
            Debug.Log(mouseposition.x + ", " + mouseposition.y);
        }

    }
}
