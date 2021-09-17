using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : LivingEntity   //각 캐릭터
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void TransformPosition()
    {
        Debug.Log("Characater Transfomr Position Called!!");
        switch (position)
        {
            case CharacterPosition.First:
                this.transform.localPosition = new Vector3(2.4f, 0, 0);
                break;
            case CharacterPosition.Second:
                this.transform.localPosition = new Vector3(0.8f, 0, 0);
                break;
            case CharacterPosition.Third:
                this.transform.localPosition = new Vector3(-0.8f, 0, 0);
                break;
            case CharacterPosition.Fourth:
                this.transform.localPosition = new Vector3(-2.4f, 0, 0);
                break;
            default:
                break;
        }
    }
}
