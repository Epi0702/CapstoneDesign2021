using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : LivingEntity   //각 캐릭터
{
    public int skill01Index;
    public int skill02Index;
    public int skill03Index;
    public int skill04Index;

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
    public override void Setup()
    {
        base.Setup();
        this.isMonster = false;
        characterSprite = transform.Find("Character").gameObject;

        anim = characterSprite.GetComponent<HumanoidAnimation>();
        Debug.Log(anim);
    }
    public override void TransformPosition()
    {
        Debug.Log("Characater Transfomr Position Called!!");
        switch (position)
        {
            case CharacterPosition.First:
                this.transform.localPosition = new Vector3(2.4f, 0, 0);
                break;
            case CharacterPosition.Second:
                this.transform.localPosition = new Vector3(0.8f, 0, 0);
                break;
            case CharacterPosition.Third:
                this.transform.localPosition = new Vector3(-0.8f, 0, 0);
                break;
            case CharacterPosition.Fourth:
                this.transform.localPosition = new Vector3(-2.4f, 0, 0);
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

    public override void Attack()
    {
        
    }
    public void TestAnimation()
    {
        anim.SetAnimation(Acting.Smash);
        anim.SetAnimation(Acting.Idle);
    }
}
