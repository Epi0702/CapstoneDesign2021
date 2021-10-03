using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class statusUpdate : MonoBehaviour
{
    public TMP_Text energy;
    public TMP_Text gem;
    public TMP_Text gold;
    // Start is called before the first frame update
    void Start()
    {
        energy.text = GameManager.getEnergy().ToString() + " / 100";
        gem.text = GameManager.getGem().ToString();
        gold.text = GameManager.getGold().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
