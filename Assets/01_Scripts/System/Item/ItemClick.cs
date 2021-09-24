using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : MonoBehaviour
{
    Item item;

    // Start is called before the first frame update
    void Start()
    {
        item = this.GetComponent<Item>();
    }

    private void OnMouseDown()
    {
        if (item.isSetted == true)
            item.OnClickFunction();
    }
}
