using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMap : MonoBehaviour
{
    private float dist = -10;
    private Vector3 MouseStart;
    private Vector3 derp;
    private Vector3 CurrentMouse;
    [SerializeField]
    float speed;
    [SerializeField]
    int MinimapSize;
    [SerializeField]
    int MinimapX;
    [SerializeField]
    int MinimapY;

    int startRoomindex;
    void Start()
    {
        startRoomindex = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().MapManager.gameWorld.startRoomIndex;
        this.transform.position = new Vector3( SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().MapManager.gameWorld.rooms[startRoomindex].GetRoomLoca().x,
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().MapManager.gameWorld.rooms[startRoomindex].GetRoomLoca().y, -10);
        dist = transform.position.z;  // Distance camera is above map
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CurrentMouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);
        }
        if (CurrentMouse.x >= MinimapX && CurrentMouse.x <= MinimapX + MinimapSize &&
            CurrentMouse.y >= MinimapY && CurrentMouse.y <= MinimapY + MinimapSize)
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
                transform.position = transform.position - (MouseMove - MouseStart) * speed;

                MouseStart = MouseMove;
            }
        }

    }
}
//transform.position -= new Vector3(MouseMove.x - MouseStart.x, MouseMove.y - MouseStart.y, 0);

