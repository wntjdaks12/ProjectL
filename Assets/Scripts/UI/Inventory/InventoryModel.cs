using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryModel
{
    private Dictionary<int, Item> itemInfos = new Dictionary<int, Item>();
    private Dictionary<int, Item> equipItemInfos = new Dictionary<int, Item>();

    public event Action<Item> OnInventoryChanged;
    public event Action<Item> OnItemEquipped;

    public void AddItem(IEnumerable<Item> items)
    {
        foreach (var item in items)
        {
            AddItem(item);
        }
    }

    public void AddItem(Item item)
    {
        if (itemInfos.TryGetValue(item.Id, out Item value))
        {
            value.AddItem(item.Count);
        }
        else
        {
            itemInfos[item.Id] = item;
        }

        OnInventoryChanged?.Invoke(item);
    }

    public bool ConsumeItem(Item item, int count)
    {
        var isConsumed = false;

        if (itemInfos.TryGetValue(item.Id, out Item value))
        {
            if (value.Count < count)
            {
                isConsumed = false;
            }
            else if (value.Count == count)
            {
                RemoveItem(item);

                isConsumed = true;
            }
            else
            {
                value.ConsumeItem(count);

                isConsumed = true;
            }
        }

        return isConsumed;
    }


    public bool ConsumeItem(int id, int count)
    {
        var isConsumed = false;

        if (itemInfos.TryGetValue(id, out Item value))
        {
            if (value.Count < count)
            {
                isConsumed = false;
            }
            else if (value.Count == count)
            {
                RemoveItem(id);

                isConsumed = true;
            }
            else
            {
                value.ConsumeItem(count);

                isConsumed = true;
            }
        }

        return isConsumed;
    }

    public void RemoveItem(Item item)
    {
        if (equipItemInfos.ContainsKey(item.Id))
        {
            equipItemInfos.Remove(item.Id);
        }

        if (itemInfos.ContainsKey(item.Id))
        {
            itemInfos.Remove(item.Id);
        }
    }

    public void RemoveItem(int id)
    {
        if (equipItemInfos.ContainsKey(id))
        {
            equipItemInfos.Remove(id);
        }

        if (itemInfos.ContainsKey(id))
        {
            itemInfos.Remove(id);
        }
    }

    public void EquipItem(Item item)
    {
        if (equipItemInfos.TryGetValue(item.Id, out Item value))
        {
        }
        else
        {
            equipItemInfos[item.Id] = item;
        }

        OnItemEquipped?.Invoke(item);
    }

    public Item[] GetItems(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Consumable: return itemInfos.Where(x => x.Value is ConsumableItem).Select(x => x.Value).ToArray();
            default: return Array.Empty<Item>();
        }
    }

    public Item GetEquiptItem(int id)
    {
        return equipItemInfos.Select(x => x.Value).Where(x => x.Id == id).FirstOrDefault();
    }

    public bool CheckEquipItem(int id)
    {
        if (equipItemInfos.TryGetValue(id, out Item item))
        {
            return true;
        }
        return false;
    }
}




