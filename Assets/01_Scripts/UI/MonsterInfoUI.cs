using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MonsterInfoUI : MonoBehaviour
{
    [SerializeField]
    TextMeshPro monstername;
    [SerializeField]
    TextMeshPro currentHP;
    [SerializeField]
    TextMeshPro maxHP;
    [SerializeField]
    TextMeshPro atk;
    [SerializeField]
    TextMeshPro def;
    [SerializeField]
    TextMeshPro spd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetMonsterInfo(Monster monster)
    {
        monstername.text = monster.name.ToString();
        currentHP.text = monster.stats.currentHp.ToString();
        maxHP.text = monster.stats.maxHp.ToString();
        atk.text = monster.stats.attackDamage.ToString();
        def.text = monster.stats.defense.ToString();
        spd.text = monster.stats.speed.ToString();
    }
}
