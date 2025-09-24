using System;
using UnityEngine;

public enum ItemType
{
    Equipment,      // 장비
    Consumable,     // 소비
    Misc            // 기타
}

public enum RuleType
{
    Normal, // 제약 x (중첩o, 중복o 등등)
    Unique, // 고유
    NonStackable // 중복 불가
}

public enum SlotType
{
    Weapon, // 무기
    Projectile // 투사체
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