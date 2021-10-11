using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JsonParse : MonoBehaviour
{
    //GameData _gameData;


    List<SaveCharacter> saveCharacterList = new List<SaveCharacter>();
    List<SaveItem> saveitemList = new List<SaveItem>();

    List<SaveCharacter> characterList = new List<SaveCharacter>();
    List<MainLobbyItem> itemList = new List<MainLobbyItem>();
    public SaveCharacter CreateSaveCharacter(Character character)
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
    public Character CreateCharacter(SaveCharacter character)
    {
        Character _character = new Character();
        _character.characterClass = character.characterClass;
        _character.skill01Index = character.skill01Index;
        _character.skill02Index = character.skill02Index;
        _character.skill03Index = character.skill03Index;
        _character.skill04Index = character.skill04Index;

        _character.level = character.level;
        _character.maxExp = character.maxExp;
        _character.currentExp = character.currentExp;

        _character.stats.maxHp = character.maxHp;
        _character.stats.currentHp = character.currentHp;
        _character.stats.origin_attackDamage = character.origin_attackDamage;
        _character.stats.origin_defense = character.origin_defense; ;
        _character.stats.origin_speed = character.origin_speed;
        _character.stats.origin_critical = character.origin_critical;

        return _character;
    }
    public SaveItem CreateSaveItem(MainLobbyItem item)
    {
        SaveItem InnerItem = new SaveItem();

        InnerItem.itemCode = item.itemCode;
        InnerItem.count = item.count;

        return InnerItem;
    }
    public MainLobbyItem CreateItem(SaveItem item)
    {
        MainLobbyItem _item = new MainLobbyItem();

        _item.itemCode = item.itemCode;
        _item.count = item.count;

        return _item;
    }


    public void SavePartyCharacter()
    {
        saveCharacterList.Clear();
        for (int i = 0; i < SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters.Count; i++)
        {
            saveCharacterList.Add(SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters[i]);
        }
        DataController.Instance.gameData.partyCharacter = null;
        DataController.Instance.gameData.partyCharacter = saveCharacterList.ToArray();
    }
    public void SaveAllCharacter()
    {
        saveCharacterList.Clear();
        for (int i = 0; i < SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().allCharacters.Count; i++)
        {
            saveCharacterList.Add(SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().allCharacters[i]);
        }
        DataController.Instance.gameData.characters = null;
        DataController.Instance.gameData.characters = saveCharacterList.ToArray();
    }
    public List<SaveCharacter> LoadPartyCharacter()
    {
        characterList.Clear();
        saveCharacterList.Clear();

        for (int i = 0; i < DataController.Instance.gameData.partyCharacter.Length; i++)
        {
            saveCharacterList.Add(DataController.Instance.gameData.partyCharacter[i]);
            characterList.Add((saveCharacterList[i]));
        }

        return characterList;
    }
    public List<SaveCharacter> LoadAllCharacter()
    {
        characterList.Clear();
        saveCharacterList.Clear();

        for (int i = 0; i < DataController.Instance.gameData.characters.Length; i++)
        {
            saveCharacterList.Add(DataController.Instance.gameData.characters[i]);
            characterList.Add(saveCharacterList[i]);
        }

        return characterList;
    }





    public void SaveInventoryItem()
    {
        saveitemList.Clear();
        for (int i = 0; i < SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().inventory.Count; i++)
        {
            saveitemList.Add(CreateSaveItem(SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().inventory[i]));
        }
        DataController.Instance.gameData.inventory = null;
        DataController.Instance.gameData.inventory = saveitemList.ToArray();
    }
    public void SaveInSafeItem()
    {
        saveitemList.Clear();
        for (int i = 0; i < SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().InSafe.Count; i++)
        {
            saveitemList.Add(CreateSaveItem(SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().InSafe[i]));
        }
        DataController.Instance.gameData.insafe = null;
        DataController.Instance.gameData.insafe = saveitemList.ToArray();
    }
    public List<MainLobbyItem> LoadInSafeItem()
    {
        itemList.Clear();
        saveitemList.Clear();

        for (int i = 0; i < DataController.Instance.gameData.insafe.Length; i++)
        {
            saveitemList.Add(DataController.Instance.gameData.insafe[i]);
            itemList.Add(CreateItem(saveitemList[i]));
        }

        return itemList;

    }
}

[System.Serializable]
public class SaveCharacter
{
    public PlayerCharacterClass characterClass;

    public int sp;//stat point

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

    public void Init()
    {
        //characterClass = PlayerCharacterClass.Knight;
        sp = 0;
        skill01Index = 1000;
        skill02Index = 1000;
        skill03Index = 1000;
        skill04Index = 1000;

        level = 1;
        maxExp = 10;
        currentExp = 0;

        maxHp = 100;
        currentHp = maxHp;

        origin_attackDamage = 20;
        origin_defense = 5;
        origin_speed = 10;
        origin_critical = 0;
    }
}

[System.Serializable]
public class SaveItem
{
    public int itemCode;
    public int count;
}