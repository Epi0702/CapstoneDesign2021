using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapAlgo;

public class Passage : MonoBehaviour
{

    public PassageData passageinfo;

    // Start is called before the first frame update
    void Awake()
    {
        //rectTrans = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetRoom(PassageData _passageData)
    {
        passageinfo = _passageData;
    }
    public void SetPositon(MapSize _mapsize, AreaSize _areasize, int _scale)
    {
        int realLoca = 0;
        //realLoca = ((int)_mapsize * (int)_areasize + (int)_mapsize - 2) / 2;

        //rectTrans.anchoredPosition = new Vector2((roominfo.GetRoomLoca().x - realLoca) * _scale, (roominfo.GetRoomLoca().y - realLoca) * _scale);
        transform.position = new Vector2((passageinfo.GetRoomLoca().x - realLoca), (passageinfo.GetRoomLoca().y - realLoca));
    }

}
