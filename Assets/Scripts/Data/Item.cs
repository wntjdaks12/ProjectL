using Newtonsoft.Json;
using System;

public enum ItemType
{
    Equipment,      // ���
    Consumable,     // �Һ�
    Misc            // ��Ÿ
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

    // ������ �߰�
    public void AddItem(int count)
    {
        this.count += count;
    }

    // ������ ���
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