using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Rendering;

public enum CharacterPosition
{
    First,
    Second,
    Third,
    Fourth,
}
public struct Resistence
{
    public int bleeding_resi;
    public int strun_resi;
}
public struct Debuff
{
    public bool isBleeding;
    public bool isStruned;

    public int bleedingCount;
    public int strunCount;
}
public struct Stats
{
    public int maxHp;
    public int currentHp;// { get; set; }
    public int attackDamage;
    public int defense;
    public int speed;
    public int critical;

    public int origin_attackDamage;
    public int origin_defense;
    public int origin_speed;
    public int origin_critical;
}
public struct TempChangeStats
{
    public int temp_attackDamage;
    public int temp_defense;
    public int temp_speed;
    public int temp_critical;

    public int temp_atk_count;
    public int temp_def_count;
    public int temp_spd_count;
    public int temp_crt_count;
}
public abstract class LivingEntity : MonoBehaviour
{
    public Stats stats;
    public TempChangeStats tempStats;
    public Resistence resi;
    public Debuff debuff;

    public CharacterPosition position;
    protected int size;

    public bool isMonster;

    public int gettedDamage;

    public bool dead { get; set; }
    public event Action onDeath;

    public SortingGroup renderer;

    DamageText dmgtxt;

    //활성화 리셋
    protected virtual void OnEnable()
    {
        dead = false;
        stats.currentHp = stats.maxHp;
    }
    public virtual void Setup()
    {
        gettedDamage = 0;
        renderer = this.GetComponent<SortingGroup>();
        dmgtxt = transform.GetComponentInChildren<DamageText>();
    }
    public virtual void Attack()
    {

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
        gettedDamage = (damage - stats.defense);
        dmgtxt.PrintDamage(gettedDamage);
    }
    public virtual void GetDamage()
    {
        this.stats.currentHp -= gettedDamage;

        if (this.stats.currentHp <= 0)
            this.stats.currentHp = 0;
        Debug.Log("currentHP : " + stats.currentHp);
        gettedDamage = 0;
        if (stats.currentHp <= 0 && !dead)
        {
            Die();
        }
    }

    public virtual void IsDead()
    {
        if (stats.currentHp <= 0 && !dead)
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
        //this.gameObject.SetActive(false);
    }


    public void OnDebug()
    {
        Debug.Log("Max HP : " + stats.maxHp + ", currentHP : " + stats.currentHp);
    }

    public void InitEntity(int maxhp, int currenthp, int atk, int def, int spd, int crt)
    {
        this.stats.maxHp = maxhp;

        this.stats.currentHp = currenthp;
        this.stats.origin_attackDamage = atk;
        this.stats.origin_defense = def;
        this.stats.origin_speed = spd;
        this.stats.origin_critical = crt;
    }

    public void ResetStats()
    {
        this.stats.attackDamage = this.stats.origin_attackDamage;
        this.stats.defense = this.stats.origin_defense;
        this.stats.speed = this.stats.origin_speed;
        this.stats.critical = this.stats.origin_critical;
    }
    public void InitTempStats()
    {
        this.tempStats.temp_attackDamage = 0;
        this.tempStats.temp_defense = 0;
        this.tempStats.temp_speed = 0;
        this.tempStats.temp_critical = 0;

        this.tempStats.temp_attackDamage = 0;
        this.tempStats.temp_defense = 0;
        this.tempStats.temp_speed = 0;
        this.tempStats.temp_critical = 0;
    }
    public void InitDebuff()
    {
        this.debuff.isStruned = false;
        this.debuff.isBleeding = false;

        this.debuff.strunCount = 0;
        this.debuff.bleedingCount = 0;
    }

    public void GetSturn(int turn)
    {
        this.debuff.isStruned = true;
        this.debuff.strunCount = turn;
    }
    public void SturnActive()
    {
        this.debuff.strunCount -= 1;
        if (this.debuff.strunCount == 0)
            this.debuff.isStruned = false;
    }

    public void GetBleeding(int turn)
    {
        this.debuff.isBleeding = true;
        this.debuff.bleedingCount = turn;
    }
    public void BleedingActive()
    {
        this.debuff.bleedingCount -= 1;
        if (this.debuff.bleedingCount == 0)
            this.debuff.isBleeding = false;
    }

    public virtual void SetAnimation(Acting act)
    {

    }
    public virtual void SetAnimation(MonsterActing act)
    {

    }
}