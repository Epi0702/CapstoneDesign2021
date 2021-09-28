using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Monster
{
    private void Awake()
    {
        this.isMonster = true;

        Setup();
    }
    private void Start()
    {

    }
    void Update()
    {

    }
    public override void Setup()
    {
        maxHp = 20;
        currentHp = maxHp;

        attackDamage = 5;
        speed = 5;
    }

    public override void Attack()
    {

    }
    public void OnDamageEvent()
    {

    }
    public override void Die()
    {
        base.Die();
    }

    public void Test()
    {
        Debug.Log("Bat HP : " + currentHp);
    }
}
