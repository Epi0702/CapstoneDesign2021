using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public ItemTable itemDataTable;

    public Item[] inventory = new Item[1];
    // Start is called before the first frame update
    void Start()
    {
        //itemDataTable.Load();

        for (int i = 0; i < inventory.Length; i++)
            inventory[i].InitItem();
    }
    public void OnTestButton()
    {
        inventory[0].SetItemInfo(itemDataTable.GetItem(0));
    }

    
}
