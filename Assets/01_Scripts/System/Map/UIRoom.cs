using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapAlgo;
public class UIRoom : MonoBehaviour
{
    public RoomData roominfo;
    RectTransform rect;
    [SerializeField]
    GameObject Button;
    [SerializeField]
    GameObject CurrentRoomIcon;
    // Start is called before the first frame update
    void Awake()
    {
        rect = this.GetComponent<RectTransform>();
        ButtonInActive();
        CurrentRoomIconInActive();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetRoom(RoomData _roomData)
    {
        roominfo = _roomData;
    }
    public void SetPositon(MapSize _mapsize, AreaSize _areasize, int _scale)
    {
        int realLoca = 0;
        realLoca = ((int)_mapsize * (int)_areasize + (int)_mapsize - 2) / 2;

        rect.anchoredPosition = new Vector2((roominfo.GetRoomLoca().x - realLoca) * _scale, (roominfo.GetRoomLoca().y - realLoca) * _scale);
    }

    public void OnClick()
    {
        Debug.Log("Clicked!!");
        Debug.Log("!!ROOMINFO : " + roominfo);
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().MapManager.prevRoomIndex = SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().MapManager.currentRoomIndex;
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().MapManager.currentRoomIndex = roominfo.GetRoomAreaNum();
        //SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().MapManager.CurrentRoomRelSet();
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().MapManager.EnterAisle();

        //PrintRel();
    }

    public void ButtonInActive()
    {
        Button.SetActive(false);
    }
    public void ButtonActive()
    {
        Button.SetActive(true);
    }

    public void CurrentRoomIconInActive()
    {
        CurrentRoomIcon.SetActive(false);
    }
    public void CurrentRoomIconActive()
    {
        CurrentRoomIcon.SetActive(true);
    }

    public void PrintRel()
    {
        if(roominfo.GetRoomRel().left != null)
        {
            Debug.Log("Left : " + roominfo.GetRoomRel().left.GetRoomAreaNum());
        }       
        if(roominfo.GetRoomRel().right != null)
        {
            Debug.Log("Right : " + roominfo.GetRoomRel().right.GetRoomAreaNum());
        }       
        if(roominfo.GetRoomRel().top != null)
        {
            Debug.Log("Top : " + roominfo.GetRoomRel().top.GetRoomAreaNum());
        }       
        if(roominfo.GetRoomRel().bottom != null)
        {
            Debug.Log("Bottom : " + roominfo.GetRoomRel().bottom.GetRoomAreaNum());
        }
    }
}
