using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : LivingEntity
{
    protected GameObject monsterSprite;
    protected MonsterAnimation anim;

    protected Difficulty difficulty;

    // Start is called before the first frame update
    void Awake()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void TransformPosition() //for monster
    {
        switch (position)
        {
            case CharacterPosition.First:
                this.transform.localPosition = new Vector3(2.4f, this.transform.position.y, 0);
                break;
            case CharacterPosition.Second:
                this.transform.localPosition = new Vector3(0.8f, this.transform.position.y, 0);
                break;
            case CharacterPosition.Third:
                this.transform.localPosition = new Vector3(-0.8f, this.transform.position.y, 0);
                break;
            case CharacterPosition.Fourth:
                this.transform.localPosition = new Vector3(-2.4f, this.transform.position.y, 0);
                break;
            default:
                break;
        }
    }
    public override void Setup()
    {
        base.Setup();
        this.isMonster = true;
        monsterSprite = transform.Find("Monster").gameObject;

        anim = monsterSprite.GetComponent<MonsterAnimation>();

    }

    public virtual void SetDifficulty(Difficulty dif)
    {

    }

    public override void OnDamage(int damage)
    {
        base.OnDamage(damage);
    }
    public override void Attack()
    {
        int randnum = UnityEngine.Random.Range(0, 4);

        switch (randnum)
        {
            case 0:
                Skill01();
                break;
            case 1:
                Skill01();
                break;
            case 2:
                Skill01();
                break;
            case 3:
                Skill01();
                break;
        }
    }
    public virtual void Skill00()
    {

    }
    public virtual void Skill01()
    {

    }
    public virtual void Skill02()
    {

    }
    public virtual void Skill03()
    {

    }

}
