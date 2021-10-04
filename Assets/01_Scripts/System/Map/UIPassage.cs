using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapAlgo;
public class UIPassage : MonoBehaviour
{
    public PassageData passageinfo;
    [SerializeField]
    RectTransform rect;

    [SerializeField]
    GameObject CurrentPassageIcon;
    // Start is called before the first frame update
    void Awake()
    {
        rect = this.GetComponent<RectTransform>();
        CurrentPassageIconInActive();
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
        realLoca = ((int)_mapsize * (int)_areasize + (int)_mapsize - 2) / 2;

        //Debug.Log(passageinfo.GetRoomLoca().x + ", " + passageinfo.GetRoomLoca().y);
        //Debug.Log(realLoca);
        rect.anchoredPosition = new Vector2((passageinfo.GetRoomLoca().x - realLoca) * _scale, (passageinfo.GetRoomLoca().y - realLoca) * _scale);
    }
    public void CurrentPassageIconInActive()
    {
        CurrentPassageIcon.SetActive(false);
    }
    public void CurrentPassageIconActive()
    {
        CurrentPassageIcon.SetActive(true);
        //Debug.Log(this.passageinfo.GetLoca());
    }
    public void SetSize(int size)
    {
        this.rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, size);
        this.rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size);
    }
}
