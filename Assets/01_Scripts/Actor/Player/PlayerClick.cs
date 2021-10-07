using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    Character character;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Debug.Log("Player Clicked!!");
        if (!SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.isBattle && !character.dead)
        {
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().selectedCharacter = character;
            SystemManager.Instance.GetCurrentSceneMain<InGameSceneMain>().BattleManager.SetSelectedPlayer();
        }

    }

    //private void OnMou
}
