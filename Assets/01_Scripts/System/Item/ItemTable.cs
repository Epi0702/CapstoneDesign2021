using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

[System.Serializable]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct ItemStruct
{
    public int itemCode;
    public int itemType;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MarshalTableConstant.charBufferSize)]
    public string itemImgPath;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MarshalTableConstant.charBufferSize)]
    public string itemName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MarshalTableConstant.charBufferSize)]
    public string functionName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MarshalTableConstant.charBufferSize)]
    public string description;
    public int maxCount;
    public int price;

}
public class ItemTable : TableLoader<ItemStruct>
{
    Dictionary<int, ItemStruct> itemTableDatas = new Dictionary<int, ItemStruct>();
    // Start is called before the first frame update
    void Awake()
    {
        Load();
    }

    protected override void AddData(ItemStruct data)
    {
        itemTableDatas.Add(data.itemCode, data);
        Debug.Log(data.itemCode + data.itemName);
    }

    public ItemStruct GetItem(int itemCode)
    {
        if(!itemTableDatas.ContainsKey(itemCode))
        {
            Debug.LogError("GetItem ERROR!! ItemCode = " + itemCode);
            return default(ItemStruct);
        }
        return itemTableDatas[itemCode];
    }
}
