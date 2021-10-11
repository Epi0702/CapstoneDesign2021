using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkillSelectPanel : MonoBehaviour
{
    [SerializeField]
    Button[] SkillButtons = new Button[8];
    bool[] SkillSelected = new bool[8];
    [SerializeField]
    GameObject[] SkillSelectedFrame = new GameObject[8];

    [SerializeField]
    MainLobbySceneMain main;
    [SerializeField]
    HeroManager heromanager;

    int classnum;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetIcons(int num)
    {
        classnum = num;
        for (int i = 0; i < 8; i++)
            SkillButtons[i].image.sprite = Resources.Load<Sprite>(SystemManager.Instance.ItemTable.GetItem(num + i).itemImgPath);
    }
    public void SetPanel()
    {
        classnum = SetInt();
        SetIcons(classnum);
        SetFrame();
    }
    public void SetFrame()
    {
        for (int i = 0; i < 8; i++)
        {
            SkillSelected[i] = false;
            SkillSelectedFrame[i].SetActive(false);
        }
        for (int i = 0; i < 8; i++)
        {
            if (main.allCharacters[heromanager.SelectedIndex].skill01Index - classnum == i)
            {
                SkillSelected[i] = true;
                SkillSelectedFrame[i].SetActive(true);
            }            
            if (main.allCharacters[heromanager.SelectedIndex].skill02Index - classnum == i)
            {
                SkillSelected[i] = true;
                SkillSelectedFrame[i].SetActive(true);
            }
            if (main.allCharacters[heromanager.SelectedIndex].skill03Index - classnum == i)
            {
                SkillSelected[i] = true;
                SkillSelectedFrame[i].SetActive(true);
            }
            if (main.allCharacters[heromanager.SelectedIndex].skill04Index - classnum == i)
            {
                SkillSelected[i] = true;
                SkillSelectedFrame[i].SetActive(true);
            }
        }
    }
    public int SetInt()
    {
        SaveCharacter temp = new SaveCharacter();
        temp = main.allCharacters[SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().HeroManager.SelectedIndex];

        switch (temp.characterClass)
        {
            case PlayerCharacterClass.Knight:
                return (1000);
            case PlayerCharacterClass.Fighter:
                return (1010);
            case PlayerCharacterClass.Warrior:
                return (1020);
            case PlayerCharacterClass.Caster:
                return (1030);
            case PlayerCharacterClass.Archer:
                return (1040);
            case PlayerCharacterClass.Debuffer:
                return (1050);
            case PlayerCharacterClass.Priest:
                return (1060);
            case PlayerCharacterClass.Paladin:
                return (1070);

            default:
                return 0;
        }
    }
    public bool Check()
    {
        int check = 0;

        for (int i = 0; i < 8; i++)
        {
            if (SkillSelected[i])
                check++;
        }
        if (check < 4)
            return true;
        else
            return false;
    }
    public void CheckJB(int skillnum)
    {
        
    }
    public void AddSkill(int skillnum)
    {

        if (main.allCharacters[heromanager.SelectedIndex].skill01Index != skillnum &&
            (main.allCharacters[heromanager.SelectedIndex].skill01Index / classnum !=1))
        {
                main.allCharacters[heromanager.SelectedIndex].skill01Index = skillnum;
        }

        else if (main.allCharacters[heromanager.SelectedIndex].skill02Index != skillnum &&
            (main.allCharacters[heromanager.SelectedIndex].skill02Index / classnum != 1))
        {
                main.allCharacters[heromanager.SelectedIndex].skill02Index = skillnum;


        }
        else if (main.allCharacters[heromanager.SelectedIndex].skill03Index != skillnum &&
            (main.allCharacters[heromanager.SelectedIndex].skill03Index / classnum != 1))
        {
                main.allCharacters[heromanager.SelectedIndex].skill03Index = skillnum;

        }
        else if (main.allCharacters[heromanager.SelectedIndex].skill04Index != skillnum &&
            (main.allCharacters[heromanager.SelectedIndex].skill04Index / classnum != 1))
        {
                main.allCharacters[heromanager.SelectedIndex].skill04Index = skillnum;

        }
    }
    public void OnResetButton()
    {
        for (int i = 0; i < 8; i++)
        {
            SkillSelected[i] = false;
            SkillSelectedFrame[i].gameObject.SetActive(false);
        }
        main.allCharacters[heromanager.SelectedIndex].skill01Index = -1;
        main.allCharacters[heromanager.SelectedIndex].skill02Index = -1;
        main.allCharacters[heromanager.SelectedIndex].skill03Index = -1;
        main.allCharacters[heromanager.SelectedIndex].skill04Index = -1;
    }
    public void OnButton00()
    {
        if (SkillSelected[0] == false)
        {
            AddSkill(classnum);

            SkillSelected[0] = true;
            SkillSelectedFrame[0].SetActive(true);

        }
    }
    public void OnButton01()
    {
        if (SkillSelected[1] == false && Check())
        {
            AddSkill(classnum + 1);
            {
                SkillSelected[1] = true;
                SkillSelectedFrame[1].SetActive(true);
            }
        }
    
    }
    public void OnButton02()
    {
        if (SkillSelected[2] == false && Check())
        {
            AddSkill(classnum + 2);
            {
                SkillSelected[2] = true;
                SkillSelectedFrame[2].SetActive(true);
            }
        }
    
    }
    public void OnButton03()
    {
        if (SkillSelected[3] == false && Check())
        {
            AddSkill(classnum + 3);
            {
                SkillSelected[3] = true;
                SkillSelectedFrame[3].SetActive(true);
            }
        }
      
    }
    public void OnButton04()
    {
        if (SkillSelected[4] == false && Check())
        {
            AddSkill(classnum + 4);
            {
                SkillSelected[4] = true;
                SkillSelectedFrame[4].SetActive(true);
            }
        }
       
    }
    public void OnButton05()
    {
        if (SkillSelected[5] == false && Check())
        {
            AddSkill(classnum + 5);
            {
                SkillSelected[5] = true;
                SkillSelectedFrame[5].SetActive(true);
            }
        }
        
    }
    public void OnButton06()
    {
        if (SkillSelected[6] == false && Check())
        {
            AddSkill(classnum + 6);
            {
                SkillSelected[6] = true;
                SkillSelectedFrame[6].SetActive(true);
            }
        }
      
    }
    public void OnButton07()
    {
        if (SkillSelected[7] == false && Check())
        {
            AddSkill(classnum + 7);
            {
                SkillSelected[7] = true;
                SkillSelectedFrame[7].SetActive(true);
            }
        }
      
    }

}
