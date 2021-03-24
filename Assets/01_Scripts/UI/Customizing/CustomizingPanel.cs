using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
public class CustomizingPanel : MonoBehaviour
{
    [SerializeField]
    SpriteLibraryAsset[] facespriteLibraryAsset;
    [SerializeField]
    SpriteResolver face;

    [SerializeField]
    SpriteResolver hair;
    [SerializeField]
    int HairCount;

    [SerializeField]
    SpriteResolver beard;
    [SerializeField]
    int beardCount;


    int faceIndex;
    int hairIndex;
    int beardindex;
    // Start is called before the first frame update
    void Start()
    {
        faceIndex = 0;
        hairIndex = 0;
        beardindex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //setFace
    public void UpdateFace()
    {
        face.spriteLibrary.spriteLibraryAsset = facespriteLibraryAsset[faceIndex];
    }
    public void OnClickUpFaceIndex()
    {
        if(faceIndex < facespriteLibraryAsset.Length -1)
        {
            faceIndex++;
        }
        else
        {
            faceIndex = 0;
        }
        UpdateFace();
    }
    public void OnClickDownFaceIndex()
    {
        if (faceIndex > 0)
        {
            faceIndex--;
        }
        else
        {
            faceIndex = facespriteLibraryAsset.Length - 1;
        }
        UpdateFace();
    }
    //setHair
    public void UpdateHair()
    {
        hair.SetCategoryAndLabel("Hair", "Hair" + hairIndex);
        Debug.Log(hairIndex);

    }
    public void OnClickUpHairIndex()
    {
        if (hairIndex < HairCount)
        {
            hairIndex++;
        }
        else
        {
            hairIndex = 0;
        }
        UpdateHair();
    }
    public void OnClickDownHairIndex()
    {
        if (hairIndex > 0)
        {
            hairIndex--;
        }
        else
        {
            hairIndex = HairCount;
        }
        UpdateHair();
    }
    //setBeard
    public void UpdateBeard()
    {
        beard.SetCategoryAndLabel("Beard", "Beard" + beardindex);
        Debug.Log(beardindex);
    }
    public void OnClickUpBeardIndex()
    {
        if (beardindex < beardCount)
        {
            beardindex++;
        }
        else
        {
            beardindex = 0;
        }
        UpdateBeard();
    }
    public void OnClickDownBeardIndex()
    {
        if (beardindex > 0)
        {
            beardindex--;
        }
        else
        {
            beardindex = beardCount;
        }
        UpdateBeard();
    }

}
