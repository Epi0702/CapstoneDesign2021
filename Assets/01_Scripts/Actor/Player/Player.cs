﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MapAlgo;

public enum PlayerState
{
    None,
    NoneInRoom,
    BattleInRoom,
    NoneInPassage,
    MoveForwardInPassage,
    BattleInPassage,
}
public class Player : MonoBehaviour
{
    [SerializeField]
    Character[] PlayerCharacter;

    public PlayerState playerState;

    //Room currentRoom;
    //Aisle currentAisle;
    //Passage currentPassage;
    private void Awake()
    {
        playerState = PlayerState.None;
        //currentRoom = null;
        //currentAisle = null;
        //currentPassage = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float num = 0;
        //num += (1 * Time.deltaTime);
        //Debug.Log(num);
    }
    void UpdateCurrentLocation()
    {

    }
    public void EnterRoom(RoomData _room)
    {
        if (_room.roomevent == RoomEventType.None)
        {
            playerState = PlayerState.NoneInRoom;
        }
        else if (_room.roomevent == RoomEventType.Battle)
        {
            playerState = PlayerState.BattleInRoom;
        }
        Debug.Log(playerState);
    }
    public void EnterPassgae(PassageData _passage)
    {
        if (_passage.passageevent == PassageEventType.None)
        {
            playerState = PlayerState.NoneInPassage;
        }
        else if (_passage.passageevent == PassageEventType.Battle)
        {
            playerState = PlayerState.BattleInPassage;
        }
        Debug.Log(playerState);
    }
}
