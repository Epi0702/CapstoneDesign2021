using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;




[System.Serializable]
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct MonsterStruct
{
    public int index;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MarshalTableConstant.charBufferSize)]
    public string FilePath;
}




public class MonsterTable : TableLoader<MonsterStruct>
{
    Dictionary<int, MonsterStruct> tableDatas = new Dictionary<int, MonsterStruct>();

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }

    protected override void AddData(MonsterStruct data)
    {
        tableDatas.Add(data.index, data);
    }

    public MonsterStruct GetMonster(int index)
    {
        if(!tableDatas.ContainsKey(index))
        {
            Debug.LogError("GetMonster ERROR!! index = " + index);
            return default(MonsterStruct);
        }
        return tableDatas[index];
    }
}
