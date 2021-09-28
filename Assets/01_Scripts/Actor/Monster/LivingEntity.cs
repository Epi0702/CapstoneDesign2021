using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum CharacterPosition
{
    First,
    Second,
    Third,
    Fourth,
}
public abstract class LivingEntity : MonoBehaviour
{
    public int maxHp = 100;
    public int currentHp { get; set; }
    public int attackDamage;
    public int speed;
    public CharacterPosition position;
    protected int size;

    public bool isMonster;

    public bool dead { get; set; }
    public event Action onDeath;


    //활성화 리셋
    protected virtual void OnEnable()
    {
        dead = false;
        currentHp = maxHp;
    }
    public virtual void Setup()
    {

    }
    public virtual void Attack()
    {
        int randnum = UnityEngine.Random.Range(0, 4);

        switch (randnum)
        {
            case 0:
                Skill00();
                break;
            case 1:
                Skill01();
                break;
            case 2:
                Skill02();
                break;
            case 3:
                Skill03();
                break;
        }
    }
    public virtual void SetPositionData(int pos)
    {
        switch (pos)
        {
            case 0:
                position = CharacterPosition.First;
                break;
            case 1:
                position = CharacterPosition.Second;
                break;
            case 2:
                position = CharacterPosition.Third;
                break;
            case 3:
                position = CharacterPosition.Fourth;
                break;
            default:
                Debug.LogError("position ERROR!!");
                break;
        }
    }
    public virtual void TransformPosition() //for monster
    {

    }
    public virtual void OnDamage(int damage)
    {
        this.currentHp -= damage;
        if (this.currentHp <= 0)
            this.currentHp = 0;
        Debug.Log("currentHP : " + currentHp);
        if (currentHp <= 0 && !dead)
        {
            Die();
        }

    }

    public virtual void Die()
    {
        if (onDeath != null)
        {
            onDeath();
        }
        dead = true;
        Debug.Log("Dead!!");
        this.gameObject.SetActive(false);
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

    public void OnDebug()
    {
        Debug.Log("Max HP : " + maxHp + ", currentHP : " + currentHp);
    }
}