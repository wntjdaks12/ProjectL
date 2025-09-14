using Newtonsoft.Json;
using System;
using UnityEngine;

public enum ItemType
{
    Equipment,      // ���
    Consumable,     // �Һ�
    Misc            // ��Ÿ
}

[Serializable]
public class Item 
{
    [field: SerializeField] public int Id { get; set; }
    [field: SerializeField] public int Count { get; set; }

    public void AddItem(int cocunt)
    {
        Count += cocunt;
    }

    public void ConsumeItem(int count)
    {
        var val = Count - count;

        Count = Mathf.Clamp(val, 0, val);
    }
}