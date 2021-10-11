using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeroManager : MonoBehaviour
{
    [SerializeField]
    GameObject Content;

    [SerializeField]
    GameObject HIre_Content;

    [SerializeField]
    GameObject[] playerObject;

    public int SelectedIndex;

    [SerializeField]
    ClassIcon[] classicons;

    [SerializeField]
    GameObject HIreList;

    [SerializeField]
    GameObject FireButton;
    [SerializeField]
    TextMeshProUGUI LevelInt;
    [SerializeField]
    TextMeshProUGUI Levelstring;
    [SerializeField]
    GameObject[] Stats;
    [SerializeField]
    TextMeshProUGUI[] stats_int;

    public PlayerSkillSelectPanel skillPanel;
    public GameObject PanelButton;

    bool hireonoff;
    Rect recttrans;
    public List<HeroSlot> heroes = new List<HeroSlot>();
    public List<HeroSlot> hire_heroes = new List<HeroSlot>();
    public List<SaveCharacter> hire_heroes_stats = new List<SaveCharacter>();

    public int selected_hire;

    bool skillselectPanel;

    // Start is called before the first frame update
    void Start()
    {
        hireonoff = false;
        InitHeros();
        skillselectPanel = false;
        PanelButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void InitHeros()
    {
        //hire_heroes_stats = null;
        SelectedIndex = 0;
        //InitHeros();
        GenerateHireHero();
        GenerateHireHero();
        GenerateHireHero();
        SetCrollView();
    }
    public void CreateHero(SaveCharacter character)
    {
        HeroSlot temp;

        temp = Instantiate(Resources.Load<HeroSlot>("Prefabs/Shop/HeroSlot"));
        temp.transform.parent = Content.gameObject.transform;
        temp.SetSlot(character);
        Debug.Log("!!!!" + temp.characterStats.heroNum);
        heroes.Add(temp);
    }
    public void CreateHero_hire(SaveCharacter character)
    {
        HeroSlot temp2;
        temp2 = Instantiate(Resources.Load<HeroSlot>("Prefabs/Shop/HeroSlot_2"));
        temp2.transform.parent = HIre_Content.gameObject.transform;
        temp2.SetSlot(character);

        hire_heroes.Add(temp2);
    }
    public void SetCrollView()
    {
        heroes.Clear();

        for (int i = 0; i < 100; i++)
        {
            //CreateHero(SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().allCharacters[i]);
            CreateNullItem();
            heroes[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < hire_heroes_stats.Count; i++)
        {
            CreateHero_hire(hire_heroes_stats[i]);
        }
        UpdateScrollView();
    }
    public void UpdateScrollView()
    {
        for (int i = 0; i < SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().allCharacters.Count; i++)
        {
            heroes[i].gameObject.SetActive(true);
            heroes[i].SetSlot(SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().allCharacters[i]);
            heroes[i].SetLevet();
        }
        for (int i = SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().allCharacters.Count; i < heroes.Count; i++)
        {
            heroes[i].gameObject.SetActive(false);
        }
        CheckParty();
    }
    public void CreateNullItem()
    {
        //Debug.Log("CreateNullItem called!!");
        SaveCharacter none = new SaveCharacter();
        none.Init();

        HeroSlot temp;
        temp = Instantiate(Resources.Load<HeroSlot>("Prefabs/Shop/HeroSlot"));
        temp.transform.parent = Content.transform;
        temp.SetSlot(none);
        heroes.Add(temp);
        //Debug.Log(invenitem.Count);

    }

    public void SetPlayerImg(PlayerCharacterClass data)
    {
        for (int i = 0; i < playerObject.Length; i++)
        {
            playerObject[i].SetActive(false);
        }
        switch (data)
        {
            case PlayerCharacterClass.None:
                break;
            case PlayerCharacterClass.Knight:
                playerObject[0].SetActive(true);
                break;
            case PlayerCharacterClass.Fighter:
                playerObject[1].SetActive(true);
                break;
            case PlayerCharacterClass.Warrior:
                playerObject[2].SetActive(true);
                break;
            case PlayerCharacterClass.Caster:
                playerObject[3].SetActive(true);
                break;
            case PlayerCharacterClass.Archer:
                playerObject[4].SetActive(true);
                break;
            case PlayerCharacterClass.Debuffer:
                playerObject[5].SetActive(true);
                break;
            case PlayerCharacterClass.Priest:
                playerObject[6].SetActive(true);
                break;
            case PlayerCharacterClass.Paladin:
                playerObject[7].SetActive(true);
                break;
            default:
                break;
        }
    }
    public void UpdateHeros()
    {
        heroes[SelectedIndex].SetIcon((int)heroes[SelectedIndex].characterStats.characterClass);
    }
    public void GenerateHireHero()
    {
        SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().HeroCreator.OnCharacterAddButton();
    }

    public void OnTest()
    {
        heroes.Clear();
        hire_heroes.Clear();
    }

    public void SetActiveButtons()
    {
        for (int i = 0; i < heroes.Count; i++)
        {
            if (heroes[i].characterStats.heroNum == SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters[0].heroNum)
                heroes[i].SetOUTButtons();
            else if (heroes[i].characterStats.heroNum == SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters[1].heroNum)
                heroes[i].SetOUTButtons();
            else if (heroes[i].characterStats.heroNum == SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters[2].heroNum)
                heroes[i].SetOUTButtons();
            else if (heroes[i].characterStats.heroNum == SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters[3].heroNum)
                heroes[i].SetOUTButtons();
        }
    }
    public void CheckParty()
    {
        FullParty();
        EmptyParty();
    }
    public void FullParty()
    {
        if (SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters.Count == 4)
        {
            for (int i = 0; i < heroes.Count; i++)
            {
                heroes[i].UnInButton();
            }
        }
    }
    public void EmptyParty()
    {
        if (SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters.Count == 0)
        {
            for (int i = 0; i < heroes.Count; i++)
            {
                heroes[i].UnOutButton();
            }
        }
    }
    public void SetClassIcon()
    {
        for (int i = 0; i < classicons.Length; i++)
        {
            if (SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters.Count > i)
                classicons[i].SetIcon(SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters[i].characterClass);
            else
            {
                classicons[i].Init();
            }
        }
    }
    public void OnHirePanel()
    {
        if (!hireonoff)
        {
            HIreList.SetActive(true);
            hireonoff = true;
        }

        else
        {
            HIreList.SetActive(false);
            hireonoff = false;
        }
    }
    public void FireHero()
    {
        for (int i = 0; i < SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().allCharacters.Count; i++)
        {
            if (SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().allCharacters[i].heroNum == SelectedIndex)
            {
                SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().allCharacters.RemoveAt(i);
            }

        }
        for (int i = 0; i < SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters.Count; i++)
        {
            if (SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters[i].heroNum == SelectedIndex)
            {
                SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().partyCharacters.RemoveAt(i);
            }
        }
        UpdateScrollView();
        UnActiveSelected();
    }
    public void FrameOff()
    {
        for (int i = 0; i < heroes.Count; i++)
        {
            heroes[i].SelectFrame.SetActive(false);
        }
    }
    public void UnActiveSelected()
    {
        for (int i = 0; i < playerObject.Length; i++)
        {
            playerObject[i].SetActive(false);
        }
        FireButton.SetActive(false);
        LevelInt.gameObject.SetActive(false);
        Levelstring.gameObject.SetActive(false);

        for (int i = 0; i < Stats.Length; i++)
        {
            Stats[i].SetActive(false);
            stats_int[i].gameObject.SetActive(false);
        }
    }

    public void SetSelectedInfo()
    {
        UnActiveSelected();
        SaveCharacter temp = new SaveCharacter();
        for (int i = 0; i < SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().allCharacters.Count; i++)
        {
            if (SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().allCharacters[i].heroNum == SelectedIndex)
            {
                temp = SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().allCharacters[i];
            }
        }

        switch (temp.characterClass)
        {
            case PlayerCharacterClass.Knight:
                playerObject[0].SetActive(true);
                break;
            case PlayerCharacterClass.Fighter:
                playerObject[1].SetActive(true);
                break;
            case PlayerCharacterClass.Warrior:
                playerObject[2].SetActive(true);
                break;
            case PlayerCharacterClass.Caster:
                playerObject[3].SetActive(true);
                break;
            case PlayerCharacterClass.Archer:
                playerObject[4].SetActive(true);
                break;
            case PlayerCharacterClass.Debuffer:
                playerObject[5].SetActive(true);
                break;
            case PlayerCharacterClass.Priest:
                playerObject[6].SetActive(true);
                break;
            case PlayerCharacterClass.Paladin:
                playerObject[7].SetActive(true);
                break;
            default:
                break;
        }
        LevelInt.text = temp.level.ToString();
        FireButton.SetActive(true);
        LevelInt.gameObject.SetActive(true);
        Levelstring.gameObject.SetActive(true);
        for (int i = 0; i < Stats.Length; i++)
        {
            Stats[i].SetActive(true);
            stats_int[i].gameObject.SetActive(true);
        }

        stats_int[0].text = temp.maxHp.ToString();
        stats_int[1].text = temp.origin_attackDamage.ToString();
        stats_int[2].text = temp.origin_defense.ToString();
        stats_int[3].text = temp.origin_speed.ToString();
        SystemManager.Instance.JsonParse.SaveAllCharacter();
        SystemManager.Instance.JsonParse.SavePartyCharacter();
    }

    public void SkillSelectPanel()
    {
        if (skillselectPanel)
        {
            skillPanel.gameObject.SetActive(false);
            skillselectPanel = false;
        }
        else
        {
            skillPanel.gameObject.SetActive(true);
            skillselectPanel = true;
        }
    }
}
