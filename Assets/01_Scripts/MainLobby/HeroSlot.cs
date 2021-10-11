using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeroSlot : MonoBehaviour
{
    public SaveCharacter characterStats;

    [SerializeField]
    GameObject[] NIcon;
    [SerializeField]
    GameObject[] SIcon;
    [SerializeField]
    GameObject Select;
    [SerializeField]
    TextMeshProUGUI Level;

    [SerializeField]
    GameObject SelectButton;
    [SerializeField]
    GameObject InputButton;
    [SerializeField]
    GameObject OutputButton;

    
    public GameObject SelectFrame;
    // Start is called before the first frame update
    void Start()
    {
        //SelectFrame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetSlot(SaveCharacter data)
    {
        this.name = $"slot_{Random.Range(0, 10000)}";

        SaveCharacter temp = new SaveCharacter();
        temp = data;

        this.characterStats = new SaveCharacter()
        {
            characterClass = temp.characterClass,
            sp = temp.sp,

            heroNum = temp.heroNum,

            skill01Index = temp.skill01Index,
            skill02Index = temp.skill02Index,
            skill03Index = temp.skill03Index,
            skill04Index = temp.skill04Index,

            level = temp.level,
            maxExp = temp.maxExp,
            currentExp = temp.currentExp,

            maxHp = temp.maxHp,
            currentHp = temp.currentHp,
            origin_attackDamage = temp.origin_attackDamage,
            origin_defense = temp.origin_defense,
            origin_speed = temp.origin_speed,
            origin_critical = temp.origin_critical,
        };
        //Level.text = ("Lv. " + this.characterStats.level.ToString());

        SetClass();
    }
    public void SetClass()
    {

        switch (this.characterStats.characterClass)
        {
            case PlayerCharacterClass.Knight:
                SetIcon(0);
                break;
            case PlayerCharacterClass.Fighter:
                SetIcon(1);
                break;
            case PlayerCharacterClass.Warrior:
                SetIcon(2);
                break;
            case PlayerCharacterClass.Caster:
                SetIcon(3);
                break;
            case PlayerCharacterClass.Archer:
                SetIcon(4);
                break;
            case PlayerCharacterClass.Debuffer:
                SetIcon(5);
                break;
            case PlayerCharacterClass.Priest:
                SetIcon(6);
                break;
            case PlayerCharacterClass.Paladin:
                SetIcon(7);
                break;
            default:
                UnIcon();
                break;
        }
    }
    public void SetIcon(int num)
    {
        for (int i = 0; i < 8; i++)
        {
            SIcon[i].SetActive(false);
            NIcon[i].SetActive(false);
        }
        SIcon[num].SetActive(true);
        NIcon[num].SetActive(true);
    }
    public void UnIcon()
    {
        for (int i = 0; i < 8; i++)
        {
            SIcon[i].SetActive(false);
            NIcon[i].SetActive(false);
        }
    }

    public void SetINButton()
    {
        InputButton.SetActive(true);
        OutputButton.SetActive(false);
        SetSelectFrame(false);
    }
    public void SetOUTButtons()
    {
        InputButton.SetActive(false);
        OutputButton.SetActive(true);
        SetSelectFrame(true);
    }
    public void UnInButton()
    {
        InputButton.SetActive(false);
    }
    public void UnOutButton()
    {
        OutputButton.SetActive(false);
    }
    public void SetSelectFrame(bool onoff)
    {
        Select.SetActive(onoff);
    }
    public void HireButton()
    {
        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().allCharacters.Add(this.characterStats);
        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().HeroManager.UpdateScrollView();
        this.gameObject.SetActive(false);
        SystemManager.Instance.JsonParse.SaveAllCharacter();
        SystemManager.Instance.JsonParse.SavePartyCharacter();
    }
    public void NoHireButton()
    {
        this.gameObject.SetActive(false);
    }
    public void OnInputButton()
    {
        if (SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters.Count < 4)
        {
            SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters.Add(this.characterStats);
            SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().HeroManager.SetClassIcon();
            SetOUTButtons();

        }
        SystemManager.Instance.JsonParse.SaveAllCharacter();
        SystemManager.Instance.JsonParse.SavePartyCharacter();
    }
    public void OnOutputButton()
    {
        for (int i = 0; i < 4; i++)
        {
            if (SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters[i].heroNum == this.characterStats.heroNum)
            {
                SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters.RemoveAt(i);
                SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().HeroManager.SetClassIcon();
                SetINButton();
                break;
            }
        }
        SystemManager.Instance.JsonParse.SaveAllCharacter();
        SystemManager.Instance.JsonParse.SavePartyCharacter();
    }
    public void SetLevet()
    {
        Level.text = ("Lv. " + this.characterStats.level.ToString());
        Debug.Log("Player Num : " + this.characterStats.heroNum);
        Debug.Log(this.characterStats.level);
        Debug.Log("Lv. " + this.characterStats.level.ToString());
    }
    public void SelectHero()
    {
        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().HeroManager.SelectedIndex = this.characterStats.heroNum;
        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().HeroManager.FrameOff();
        this.SelectFrame.SetActive(true);
        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().HeroManager.SetSelectedInfo();
        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().HeroManager.skillPanel.SetPanel();
        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().HeroManager.PanelButton.SetActive(true);
        
    }
}
