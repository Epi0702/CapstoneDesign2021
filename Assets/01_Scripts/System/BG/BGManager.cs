using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BGManager : MonoBehaviour
{
    [SerializeField]
    GameObject Black;
    [SerializeField] SpriteRenderer[] RoomBG;
    [SerializeField] BGScroll[] AisleBG;

    public int currentStageIndex;


    Animator anim;

    Action<bool> ChangeEvent;

    bool roomAisle;

    bool enterTerm;
    // Start is called before the first frame update
    void Start()
    {
        anim = Black.GetComponent<Animator>();
        ChangeEvent = null;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetCurrentStage(int stage)
    {
        currentStageIndex = stage;

    }
    public void SetCurrentRoomBG()
    {
        roomAisle = true;
        ChangeEvent += IsRoom;
        RoomChange();
    }
    public void SetCurrentAisleBG()
    {
        roomAisle = false;
        ChangeEvent += IsRoom;
        RoomChange();
    }
    public void RoomChange()
    {
        StartCoroutine("FadeInOut");
    }
    public BGScroll GetCurrentAisle()
    {
        return AisleBG[currentStageIndex];
    }

    void IsRoom(bool onoff)
    {
        RoomBG[currentStageIndex].gameObject.SetActive(onoff);
        AisleBG[currentStageIndex].gameObject.SetActive(!onoff);
    }

    IEnumerator FadeInOut()
    {
        enterTerm = false;
        anim.Play("Black_fadeIn");
        yield return new WaitForSeconds(1f);
        ChangeEvent(roomAisle);
        yield return new WaitForSeconds(1f);
        anim.Play("Black_fadeOut");
        ChangeEvent = null;
        enterTerm = true;
    }
    public void EnterRoom()
    {
        SetCurrentRoomBG();
        StartCoroutine("EnterRoomTerm");
    }
    IEnumerator EnterRoomTerm()
    {
        while(!enterTerm)
        {
            yield return null;
        }
        SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().MapManager.EnterRoomInMap();
    }
}
