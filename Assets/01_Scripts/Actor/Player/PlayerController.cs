using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    HPbar[] PlayerHpBar;

    int[] beforeHp = new int[4];
    // Start is called before the first frame update
    void Start()
    {
        SetPlayerHPbar();
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadPlayerCharacter()
    {
        player.SetUpCharacter(0);
        player.SetUpCharacter(0);
        player.SetUpCharacter(1);
        player.SetUpCharacter(1);


        player.SetPosition(0, 1, 2, 3);

        SetPlayerHPbar();

    }

    public void SetPlayerHPbar()
    {
        for(int i = 0; i <4; i++)
        {
            PlayerHpBar[i].SetOnOff(false);
        }
        for(int i =0; i<player.playerCharacter.Count; i++)
        {
            if (!player.playerCharacter[i].dead)
            {
                PlayerHpBar[i].SetOnOff(true);
                PlayerHpBar[i].InitHPbar(player.playerCharacter[i].stats.maxHp, player.playerCharacter[i].stats.currentHp);
                beforeHp[i] = player.playerCharacter[i].stats.currentHp;
            }

        }
    }

    public void PrintCurrentHp()
    {
        for (int i = 0; i < player.playerCharacter.Count; i++)
        {
            PlayerHpBar[i].DecreaseHP(player.playerCharacter[i].stats.currentHp);
        }
    }
    public void SetPlayerAnim(Acting act)
    {
        for(int i = 0; i<player.playerCharacter.Count; i++)
        {
            player.playerCharacter[i].SetAnimation(act);
        }
    }
}
