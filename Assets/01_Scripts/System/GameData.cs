using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class GameData
{
    public string User_id = "test";
    public string PW = "1234";

    public int gold;

    public SaveCharacter[] partyCharacter;
    public SaveCharacter[] characters;

    public SaveItem[] inventory;
    public SaveItem[] insafe;
}
