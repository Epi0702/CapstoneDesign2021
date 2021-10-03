using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainLobbyManager : MonoBehaviour
{
    public TMP_Text level;
    public TMP_Text username;
    public TMP_Text exp;
    public TMP_Text energy;
    public TMP_Text gem;
    public TMP_Text gold;

    void Start()
    {
        level.text = GameManager.getLevel().ToString();
        username.text = GameManager.getUsername();
        exp.text = GameManager.getExp().ToString() + " / 1000";
        energy.text = GameManager.getEnergy().ToString() + " / 100";
        gem.text = GameManager.getGem().ToString();
        gold.text = GameManager.getGold().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
