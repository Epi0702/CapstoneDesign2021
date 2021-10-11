using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    GameObject SelectButton;
    [SerializeField]
    GameObject InputButton;
    [SerializeField]
    GameObject OutputButton;

    // Start is called before the first frame update
    void Start()
    {
        Select.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetSlot(SaveCharacter data)
    {
        this.name = $"slot_{Random.Range(0, 10000)}";
        this.characterStats = new SaveCharacter()
        {
            characterClass = data.characterClass,
            sp = data.sp,

            skill01Index = data.skill01Index,
            skill02Index = data.skill02Index,
            skill03Index = data.skill03Index,
            skill04Index = data.skill04Index,

            level = data.level,
            maxExp = data.maxExp,
            currentExp = data.currentExp,

            maxHp = data.maxHp,
            currentHp = data.currentHp,
            origin_attackDamage = data.origin_attackDamage,
            origin_defense = data.origin_defense,
            origin_speed = data.origin_speed,
            origin_critical = data.origin_critical,
        };

        SetClass();
    }
    public void SetClass()
    {
        switch (characterStats.characterClass)
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
                break;
        }
    }
    public void SetIcon(int num)
    {
        for(int i = 0; i< 8; i++)
        {
            SIcon[i].SetActive(false);
            NIcon[i].SetActive(false);
        }
        SIcon[num].SetActive(true);
        NIcon[num].SetActive(true);
    }

    public void SetINOUTButton()
    {
        InputButton.SetActive(true);
        InputButton.SetActive(true);
    }
    public void UnactiveButtons()
    {
        InputButton.SetActive(false);
        InputButton.SetActive(false);
    }
    public void SetSelectFrame(bool onoff)
    {
        Select.SetActive(onoff);
    }
}
