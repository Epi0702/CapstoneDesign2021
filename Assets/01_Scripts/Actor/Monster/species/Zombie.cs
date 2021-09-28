using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Monster
{
    GameObject Image;
    Animator anim;

    // Start is called before the first frame update
    private void Awake()
    {
        this.isMonster = true;

        Setup();
        //Image = Instantiate(Resources.Load<GameObject>)
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
        speed = 7;

        size = 1;
    }
    public override void SetPositionData(int pos)
    {
        base.SetPositionData(pos);
    }
    public override void TransformPosition()
    {
        base.TransformPosition();
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
        Debug.Log("Zombie HP : " + currentHp);
    }
    

}
