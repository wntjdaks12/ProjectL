using System;
using UnityEngine;

public enum ItemType
{
    Equipment,      // ���
    Consumable,     // �Һ�
    Misc            // ��Ÿ
}

public enum RuleType
{
    Normal, // ���� x (��øo, �ߺ�o ���)
    Unique, // ����
    NonStackable // �ߺ� �Ұ�
}

public enum SlotType
{
    Weapon, // ����
    Projectile // ����ü
}

[Serializable]
public class Item 
{
    [field: SerializeField] public int Id { get; set; }
    [field: SerializeField] public int Count { get; set; }
    [field: SerializeField] public SlotType SlotType { get; protected set; }
    [field: SerializeField] public ItemType ItemType { get; set; }
    [field: SerializeField] public RuleType RuleType { get; set; }

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