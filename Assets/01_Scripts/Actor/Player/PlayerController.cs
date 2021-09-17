using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Player player;
    // Start is called before the first frame update
    void Start()
    {

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
        
    }
}
