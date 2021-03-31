using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDragMove : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    private Transform tr;

    private Vector2 prevPos = Vector2.zero;
    float prevDistance = 0f;


    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        OnDrag();
    }

    void OnDrag()
    {
        int touchCount = Input.touchCount;

        if(touchCount == 1)
        {
            if(prevPos == Vector2.zero)
            {
                prevPos = Input.GetTouch(0).position;
                return;
            }

            Vector2 dir = (Input.GetTouch(0).position - prevPos).normalized;
            Vector3 vec = new Vector3(dir.x, 0,  dir.y);

            tr.position -= vec * moveSpeed * Time.deltaTime;
            prevPos = Input.GetTouch(0).position;
        }
        else if(touchCount == 2)
        {
            if(prevDistance == 0)
            {
                prevDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                return;
            }
            float curDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
            float move = prevDistance - curDistance;

            Vector3 pos = tr.position;

            if (move < 0)
                pos.y -= moveSpeed * Time.deltaTime;
            else if (move > 0)
                pos.y += moveSpeed * Time.deltaTime;

            tr.position = pos;
            prevDistance = curDistance;
        }
    }
    void ExitDrag()
    {
        prevPos = Vector2.zero;
        prevDistance = 0f;
    }
}
