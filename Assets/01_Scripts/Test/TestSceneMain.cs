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

    // Start is called before the first frame update

    void Start()
    {
        hpbar.InitHPbar(100, 100);
        delay = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnDebug()
    {
        Debug.Log("Player  : " + player.currentHp);
        Debug.Log("Monster : " + monster.currentHp);
    }
    public void OnTestHPbar()
    {
        hpbar.DecreaseHP(10);
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
}
