using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassIcon : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject[] Icons;
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init()
    {
        for (int i = 0; i < Icons.Length; i++)
            Icons[i].SetActive(false);
    }
    public void SetIcon(PlayerCharacterClass data)
    {
        switch (data)
        {
            case PlayerCharacterClass.None:
                Init();
                break;
            case PlayerCharacterClass.Knight:
                Init();
                Icons[0].SetActive(true);
                break;
            case PlayerCharacterClass.Fighter:
                Init();
                Icons[1].SetActive(true); break;
            case PlayerCharacterClass.Warrior:
                Init();
                Icons[2].SetActive(true); break;
            case PlayerCharacterClass.Caster:
                Init();
                Icons[3].SetActive(true); break;
            case PlayerCharacterClass.Archer:
                Init();
                Icons[4].SetActive(true); break;
            case PlayerCharacterClass.Debuffer:
                Init();
                Icons[5].SetActive(true); break;
            case PlayerCharacterClass.Priest:
                Init();
                Icons[6].SetActive(true); break;
            case PlayerCharacterClass.Paladin:
                Init();
                Icons[7].SetActive(true); break;
            default:
                break;
        }
    }
}
