using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : Character
{
    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Setup()
    {
        base.Setup();
        className = "Priest";
    }
    public override void InitCharacterStats()
    {
        InitEntity(100, 100, 20, 5, 11, 20);
        ResetStats();
        InitTempStats();
        InitCharacter();
    }
}
