using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField]
    TextMeshPro playerClass;
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
    public void GetPlayerInfo(Character player)
    {
        playerClass.text = player.className.ToString();
        currentHP.text = player.stats.currentHp.ToString();
        maxHP.text = player.stats.maxHp.ToString();
        atk.text = player.stats.attackDamage.ToString();
        def.text = player.stats.defense.ToString();
        spd.text = player.stats.speed.ToString();
    }
}
