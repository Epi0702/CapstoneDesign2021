using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : Character
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
        speed = 10;
    }
}
