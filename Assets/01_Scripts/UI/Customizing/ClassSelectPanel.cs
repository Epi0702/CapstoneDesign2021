using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;


public class ClassSelectPanel : MonoBehaviour
{
    [SerializeField]
    Playerlook playerlook;
    [SerializeField]
    SpriteLibraryAsset[] spriteLibrary;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickClassButton(int _num)
    {
        playerlook.GetSpriteLibraryAsset(spriteLibrary[_num]);
    }    

}
