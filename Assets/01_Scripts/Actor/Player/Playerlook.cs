using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;


public class Playerlook : MonoBehaviour
{
    SpriteLibrary spriteLibrary;
    void Start()
    {
        spriteLibrary = this.GetComponent<SpriteLibrary>();
    }

    public void GetSpriteLibraryAsset(SpriteLibraryAsset _spriteLibraryAsset)
    {
        spriteLibrary.spriteLibraryAsset = _spriteLibraryAsset;
    }
}
