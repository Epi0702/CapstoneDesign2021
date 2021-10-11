using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    [SerializeField]
    GameObject Content;
    RectTransform contentTrans;

    [SerializeField]
    GameObject[] playerObject;

    public int SelectedIndex;

    Rect recttrans;
    public List<HeroSlot> heroes = new List<HeroSlot>();
    // Start is called before the first frame update
    void Start()
    {
        SelectedIndex = 0;
        InitHeros();
        SetCrollView();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitHeros()
    {

    }
    public void CreateHero(SaveCharacter character)
    {
        HeroSlot temp;
        temp =  Instantiate(Resources.Load<HeroSlot>("Prefabs/Shop/HeroSlot"));
        temp.transform.parent = Content.gameObject.transform;
        temp.SetSlot(character);

        heroes.Add(temp);
    }
    public void SetCrollView()
    {
        heroes.Clear();
        for (int i = 0; i< SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().allCharacters.Count; i++)
        {
            CreateHero(SystemManager.Instance.GetCurrentSceneMain<MainLobbySceneMain>().allCharacters[i]);
        }
        //Content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, heroes.Count * 180);
    }
    public void SetPlayerImg(PlayerCharacterClass data)
    {
        for(int i = 0; i< playerObject.Length; i++)
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
}
