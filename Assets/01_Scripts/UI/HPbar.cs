using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{
    [SerializeField]
    Image filled;

    [SerializeField]
    Image filled_before;

    int maxHP;
    int currentHP;

    float filled_p;
    float filled_before_p;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitHPbar(int maxHP, int currentHP)
    {
        this.maxHP = maxHP;
        this.currentHP = currentHP;

        filled_p = filled_before_p = CurrentHpPercentage();
        SetHpBar();
        SetBeforeHpBar();
    }
    //public void DecreaseHP(int damage)
    //{
    //    currentHP = currentHP - damage;
    //    filled_p = CurrentHpPercentage();
    //    SetHpBar();                 //현재 체력 감소까지


    //    Debug.Log("currentHP : " + filled.fillAmount);
    //    StartCoroutine("Decrease");

    //}

    public void DecreaseHP(int currentHp)
    {
        this.currentHP = currentHp;
        filled_p = CurrentHpPercentage();
        SetHpBar();
        StartCoroutine("Decrease");
    }
    IEnumerator Decrease()
    {
        float temp;
        temp = filled_before_p - filled_p;
        //filled.fillAmount = (float)targetHP;
        for (int i = 0; i < 50; i++)
        {
            filled_before.fillAmount -= temp / 50;
            yield return new WaitForSeconds(0.015f);
        }
        filled_before_p = CurrentHpPercentage();
    }

    float CurrentHpPercentage()
    {
        return (float)currentHP / maxHP;
    }
    void SetHpBar()
    {
        filled.fillAmount = filled_p;
    }
    void SetBeforeHpBar()
    {
        filled_before.fillAmount = filled_before_p;
    }
    public void SetOnOff(bool active)
    {
        this.gameObject.SetActive(active);
    }

}
