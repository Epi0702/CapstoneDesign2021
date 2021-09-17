using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "NewItem/item")]
public class Item : ScriptableObject
{
    public string itemName; //아이템 이름
    public Sprite itemImage; //아이템 이미지
    public ItemType itemType;

    public enum ItemType
    {
        Used,
        Ingredient,
    }
}
