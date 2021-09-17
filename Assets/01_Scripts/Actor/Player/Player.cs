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
public class Player : MonoBehaviour //전체 통괄
{
    public List<LivingEntity> playerCharacter = new List<LivingEntity>();
    
    public PlayerState playerState;


    private void Awake()
    {
        playerState = PlayerState.NoneInRoom;

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
    public void SetUpCharacter(int charType)
    {
        LivingEntity temp;
        switch (charType)
        {
            case 0:
                temp = Instantiate(Resources.Load<Knight>("Prefabs/Player/Knight"), this.transform);
                playerCharacter.Add(temp);
                break;
            case 1:
                temp = Instantiate(Resources.Load<Fighter>("Prefabs/Player/Fighter"), this.transform);
                playerCharacter.Add(temp);
                break;
            default:
                Debug.LogError("Character Type ERROR!!");
                break;
        }
    }
    public void SetPosition(int position01, int position02, int position03, int position04)
    {
        playerCharacter[0].SetPositionData(position01);
        playerCharacter[1].SetPositionData(position02);
        playerCharacter[2].SetPositionData(position03);
        playerCharacter[3].SetPositionData(position04);

        playerCharacter[0].TransformPosition();
        playerCharacter[1].TransformPosition();
        playerCharacter[2].TransformPosition();
        playerCharacter[3].TransformPosition();

    }
}
