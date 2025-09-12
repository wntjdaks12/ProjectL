using Newtonsoft.Json;
using System;

public enum ItemType
{
    Equipment,      // 장비
    Consumable,     // 소비
    Misc            // 기타
}

[Serializable]
public class Item : ICloneable
{
    [JsonProperty] private int id;
    [JsonProperty] private ItemType itemType;
    [JsonProperty] private int count;

    public int Id => id;
    public ItemType ItemType => itemType;
    public int Count => count;

    // 아이템 추가
    public void AddItem(int count)
    {
        this.count += count;
    }

    // 아이템 사용
    public void ConsumeItem(int count)
    {
        var curCount = this.count - count;

        this.count = Math.Clamp(curCount, 0, curCount);
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}