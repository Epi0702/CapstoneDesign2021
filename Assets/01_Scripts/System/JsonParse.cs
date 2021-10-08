using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JsonParse : MonoBehaviour
{
    //GameData _gameData;

    List<SaveCharacter> characterList = new List<SaveCharacter>();


    public SaveCharacter CreateCharacter(Character character)
    {
        SaveCharacter InnerCharacter = new SaveCharacter();
        InnerCharacter.characterClass = character.characterClass;
        InnerCharacter.skill01Index = character.skill01Index;
        InnerCharacter.skill02Index = character.skill02Index;
        InnerCharacter.skill03Index = character.skill03Index;
        InnerCharacter.skill04Index = character.skill04Index;

        InnerCharacter.level = character.level;
        InnerCharacter.maxExp = character.maxExp;
        InnerCharacter.currentExp = character.currentExp;

        InnerCharacter.maxHp = character.stats.maxHp;
        InnerCharacter.currentHp = character.stats.currentHp;
        InnerCharacter.origin_attackDamage = character.stats.origin_attackDamage;
        InnerCharacter.origin_defense = character.stats.origin_defense; ;
        InnerCharacter.origin_speed = character.stats.origin_speed;
        InnerCharacter.origin_critical = character.stats.origin_critical;
        return InnerCharacter;
    }


    public void SaveCharacter()
    {
        characterList.Add(CreateCharacter(SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.player.playerCharacter[0]));
        characterList.Add(CreateCharacter(SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.player.playerCharacter[1]));
        characterList.Add(CreateCharacter(SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.player.playerCharacter[2]));
        characterList.Add(CreateCharacter(SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.player.playerCharacter[3]));

        DataController.Instance.gameData.characters = characterList.ToArray();

        //string generatedJsonString = JsonUtility.ToJson(mainObject);
        //Debug.Log("generatedJsonString: " + generatedJsonString);
    }

    public void LoadCharacter()
    {
        characterList.Clear();

        for(int i = 0; i< DataController.Instance.gameData.characters.Length; i++)
        {
            characterList.Add(DataController.Instance.gameData.characters[i]);
        }
    }


}

[Serializable]
public class SaveCharacter
{
    public PlayerCharacterClass characterClass;

    public int skill01Index;
    public int skill02Index;
    public int skill03Index;
    public int skill04Index;

    public int level;
    public int maxExp;
    public int currentExp;

    public int maxHp;
    public int currentHp;
    public int origin_attackDamage;
    public int origin_defense;
    public int origin_speed;
    public int origin_critical;
    
}