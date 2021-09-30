using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : LivingEntity   //각 캐릭터
{
    public int skill01Index;
    public int skill02Index;
    public int skill03Index;
    public int skill04Index;

    public int level;
    public int maxExp;
    public int currentExp;

    public string className;

    HumanoidAnimation anim;
    GameObject characterSprite;

    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public virtual void SetStats()
    {

    }
    public override void Setup()
    {
        base.Setup();
        this.isMonster = false;
        characterSprite = transform.Find("Character").gameObject;

        anim = characterSprite.GetComponent<HumanoidAnimation>();
    }
    public override void TransformPosition()
    {
        Debug.Log("Characater Transfomr Position Called!!");
        switch (position)
        {
            case CharacterPosition.First:
                this.transform.localPosition = new Vector3(2.49f, 0, 0);
                break;
            case CharacterPosition.Second:
                this.transform.localPosition = new Vector3(0.83f, 0, 0);
                break;
            case CharacterPosition.Third:
                this.transform.localPosition = new Vector3(-0.83f, 0, 0);
                break;
            case CharacterPosition.Fourth:
                this.transform.localPosition = new Vector3(-2.49f, 0, 0);
                break;
            default:
                break;
        }
    }
    public void SetDataForTest(int skill01Num, int skill02Num, int skill03Num, int skill04Num)
    {
        this.skill01Index = skill01Num;
        this.skill02Index = skill02Num;
        this.skill03Index = skill03Num;
        this.skill04Index = skill04Num;
    }
    public void LoadStats(int level, int maxHp, int currentHp,int atk, int def, int spd, int cri, int curExp)
    {
        this.level = level;
        SetMaxEXPByLevel();
        this.maxHp = maxHp;
        this.currentHp = currentHp;
        this.attackDamage = atk;
        this.defense = def;
        this.speed = spd;
        this.critical = cri;
        this.currentExp = curExp;
    }
    public void InitCharacter()
    {
        this.level = 1;
        SetMaxEXPByLevel();
        this.currentExp = 0;
    }
    public override void Attack()
    {
        
    }
    public void TestAnimation()
    {
        anim.SetAnimation(Acting.Smash);
        anim.SetAnimation(Acting.Idle);
    }
    public void SetMaxEXPByLevel()
    {
        switch (level)
        {
            case 1:
                this.maxExp = 10;
                break;
            case 2:
                this.maxExp = 30;
                break;
            case 3:
                this.maxExp = 90;
                break;
            case 4:
                this.maxExp = 270;
                break;
            case 5:
                this.maxExp = 810;
                break;

            default:
                Debug.LogError("Level Range ERROR!!");
                break;
        }
    }
    public void LevelUp()
    {
        if(currentExp >= maxExp)
        {
            currentExp -= maxExp;
            level++;
            SetMaxEXPByLevel();
        }
    }
}
