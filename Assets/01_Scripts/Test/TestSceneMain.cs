using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneMain : BaseSceneMain
{
    [SerializeField]
    Character player;
    [SerializeField]
    LivingEntity monster;

    [SerializeField]
    Item playerSkill;

    [SerializeField]
    HPbar hpbar;

    public LivingEntity target = null;

    public bool delay;
    int count = 0;
    int count2 = 0;
    [SerializeField]
    DamageText dmgtxt;
    // Start is called before the first frame update

    GameObject BG;
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnDebug()
    {
        Debug.Log("Player  : " + player.stats.currentHp);
        Debug.Log("Monster : " + monster.stats.currentHp);
    }
    public void OnTestHPbar()
    {
        dmgtxt.PrintDamage(50);
    }
    public void OnTestDelay()
    {
        Debug.Log("Invoke1");
        if (!delay)
            StartCoroutine("DelayTest");
        if (!delay)
            Debug.Log("Invoke2");
    }
    public void TestAnim()
    {
        player.TestAnimation();
    }
    IEnumerator DelayTest()
    {
        delay = true;
        yield return new WaitForSeconds(2f);
        Debug.Log("Coroutine Called!!");
        delay = false;
    }

    IEnumerator StopTest()
    {

        while(true)
        {
            count++;
            Debug.Log(count);
            yield return new WaitForSeconds(1f);
        }
    } 
    IEnumerator StopTest2()
    {

        while(true)
        {
            if (count >= 5)
                StopAllCoroutines();
            count2++;
            Debug.Log(count2);
            yield return new WaitForSeconds(1f);
        }
    }

}
