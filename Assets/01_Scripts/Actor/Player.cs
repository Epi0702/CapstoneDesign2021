using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class Player : MonoBehaviour
{
    SpriteLibrary spriteLibrary;
    // Start is called before the first frame update
    void Start()
    {
        spriteLibrary = this.GetComponent<SpriteLibrary>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            spriteLibrary.spriteLibraryAsset = Resources.Load<SpriteLibraryAsset>("Test/Acolyte Sprite Library Asset");
        }
    }
}
