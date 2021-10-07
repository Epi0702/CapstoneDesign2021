using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageText : MonoBehaviour
{
    public float moveSpeed;
    public float alphaSpeed;
    public float destroyTime;
    TextMeshPro text;
    Color alpha;
    public int damage;

    public bool enable;

    
    RectTransform recttrans;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        alpha = text.color;
        enable = false;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (enable)
        {
            DamageTextIncrease();
        }
            
    }
    public void PrintDamage(int dmg)
    {
        Debug.Log("Called!!");
        damage = dmg;
        text.text = damage.ToString();


        this.gameObject.SetActive(true);
        enable = true;

        Invoke("Init", destroyTime);
    }

    public void  DamageTextIncrease()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0)); // 텍스트 위치
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed); // 텍스트 알파값
        text.alpha = alpha.a;
    }
    public void Init()
    {
        enable = false;
        //transform.position = new Vector3(0, 0, 0);
        transform.localPosition = new Vector3(0,0,0);
        
        //recttrans.anchoredPosition = new Vector3(0, 0, 0);
        alpha.a = 1;
        this.gameObject.SetActive(false);
    }
}
