using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroCreator : MonoBehaviour
{
    SaveCharacter[] createdCharacter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCharacterAddButton()
    {
        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().allCharacters.Add(CreateCharacter());
        SystemManager.Instance.JsonParse.SaveAllCharacter();
    }
    public SaveCharacter CreateCharacter()
    {
        int classnum = Random.Range(0, 8);
        SaveCharacter temp = new SaveCharacter();
        temp.Init();
        temp.characterClass = SetClass(classnum);
        return temp;
    }
    public PlayerCharacterClass SetClass(int num)
    {
        switch (num)
        {
            case 0:
                return PlayerCharacterClass.Knight;
            case 1: 
                return PlayerCharacterClass.Fighter;
            case 2:
                return PlayerCharacterClass.Warrior;
            case 3:
                return PlayerCharacterClass.Caster;
            case 4:
                return PlayerCharacterClass.Archer;
            case 5:
                return PlayerCharacterClass.Debuffer;
            case 6:
                return PlayerCharacterClass.Priest;
            case 7:
                return PlayerCharacterClass.Paladin;
            default:
                return PlayerCharacterClass.None;
        }
    }
}
