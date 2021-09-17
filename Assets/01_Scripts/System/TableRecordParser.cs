using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Text;
using System.Reflection;

public class MarshalTableConstant
{
    public const int charBufferSize = 256;
}
public class TableRecordParser<TMarchalStruct>
{
    public TMarchalStruct ParseRecordLine(string line)
    {
        //TMarchalStruct 크기에 맞춰서 Byte 배열 할당
        Type type = typeof(TMarchalStruct);
        int structSize = Marshal.SizeOf(type);      //System.Runtime.InteropServices.Marshal
        byte[] structBytes = new byte[structSize];
        int structBytesIndex = 0;

        //line 문자열을 spliter로 자름
        const string spliter = ",";
        string[] fieldDataList = line.Split(spliter.ToCharArray());
        //타입을 보고 바이너리에 파싱하여 삽입
        Type dataType;
        string splited;
        byte[] fieldByte;
        byte[] keyBytes;

        FieldInfo[] fieldInfos = type.GetFields();      //System.Reflection.FieldInfo
        for (int i = 0; i < fieldInfos.Length; i++)
        {
            dataType = fieldInfos[i].FieldType;
            splited = fieldDataList[i];

            fieldByte = new byte[4];
            MakeBytesByFieldType(out fieldByte, dataType, splited);

            //fieldByte의 값을 structBytes에 누적
            //for (int index = 0; index < fieldByte.Length; index++)
            //{
            //    structBytes[structBytesIndex++] = fieldByte[index];
            //}

            Buffer.BlockCopy(fieldByte, 0, structBytes, structBytesIndex, fieldByte.Length);
            structBytesIndex += fieldByte.Length;

            //첫번째 필드를 key값으로 사용하기 위해 백업
            if (i == 0)
                keyBytes = fieldByte;
        }
        //mashaling
        TMarchalStruct tStruct = MakeStructFromBytes<TMarchalStruct>(structBytes);
        //AddData(KeyBytes, tStruct);
        return tStruct;
    }


    //문자열을 splite를 주어진 dataType에 맞게 fieldByte 배열에 변환해서 반환
    //fieldByte : 결과값을 받을 배열
    //dataType  : splite를 변환할때 사용될 자료형
    //splite    : 변환할 값이 있는 문자열
    protected void MakeBytesByFieldType(out byte[] fieldByte, Type dataType, string splite)
    {
        fieldByte = new byte[1];

        if (typeof(int) == dataType)
        {
            fieldByte = BitConverter.GetBytes(int.Parse(splite));
        }
        else if (typeof(long) == dataType)
        {
            fieldByte = BitConverter.GetBytes(long.Parse(splite));
        }
        else if (typeof(float) == dataType)
        {
            fieldByte = BitConverter.GetBytes(float.Parse(splite));
        }
        else if (typeof(bool) == dataType)
        {
            bool value = bool.Parse(splite);
            int temp = value ? 1 : 0;
            fieldByte = BitConverter.GetBytes((int)temp);
        }
        else if (typeof(string) == dataType)
        {
            fieldByte = new byte[MarshalTableConstant.charBufferSize];      //마샬링을 하기위해서 고정크기 버퍼를 생성
            byte[] byteArr = Encoding.UTF8.GetBytes(splite);                //system.text.encoding
            //변환된 byte 배열을 고정크기 버퍼에 복사
            Buffer.BlockCopy(byteArr, 0, fieldByte, 0, byteArr.Length);     //system.buffer
        }
    }


    //마샬링을 통한 byte 배열의 T형 구조체 변환
    public static T MakeStructFromBytes<T>(byte[] bytes)
    {
        int size = Marshal.SizeOf(typeof(T));
        IntPtr ptr = Marshal.AllocHGlobal(size);        //메모리 할당

        Marshal.Copy(bytes, 0, ptr, size);              //복사

        T tStruct = (T)Marshal.PtrToStructure(ptr, typeof(T));  //메모리로부터 T형 구조체로 변환
        Marshal.FreeHGlobal(ptr);       //할당된 메모리 해제
        return tStruct;
    }

}
