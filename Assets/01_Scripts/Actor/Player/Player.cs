using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    PlayerState playerState;

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
}
