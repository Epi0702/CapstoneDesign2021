using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public ItemTable itemDataTable;

    public Item[] inventory = new Item[1];

    public Item[] playerskill = new Item[4];

    public bool isSkillActive;

    // Start is called before the first frame update
    void Start()
    {
        //itemDataTable.Load();
        isSkillActive = false;
        for (int i = 0; i < inventory.Length; i++)
            inventory[i].InitItem();
    }
    public void OnTestButton()
    {
        inventory[0].SetItemInfo(itemDataTable.GetItem(1000));
    }

    public void PlayerSkillSet(Character character)
    {
        playerskill[0].SetItemInfo(itemDataTable.GetItem(character.skill01Index));
        playerskill[1].SetItemInfo(itemDataTable.GetItem(character.skill02Index));
        playerskill[2].SetItemInfo(itemDataTable.GetItem(character.skill03Index));
        playerskill[3].SetItemInfo(itemDataTable.GetItem(character.skill04Index));
    }

    public void SetSkillSelectedFrameAllOff()
    {
        for (int i = 0; i < 4; i++)
            playerskill[i].skillClick.SelectedFrameOnOff(false);
    }

    public void SetSkillClickedFalse()
    {
        for (int i = 0; i < 4; i++)
            playerskill[i].skillSelected = false;
    }


}
