using System;
using System.Collections.Generic;
using System.Linq;

public class InventoryModel
{
    private List<Item> items = new List<Item>();

    public event Action<Item> OnItemEquipped;

    public void AddItem(List<Item> items)
    {
        this.items = items;
    }

    public Item[] GetItems(ItemType itemType)
    {
        switch (itemType)
        {
            case ItemType.Equipment: return items.Where(x => x is EquipmentItem).ToArray();
            case ItemType.Consumable: return items.Where(x => x is ConsumableItem).ToArray();
            case ItemType.Misc: return items.Where(x => x is MiscItem).ToArray();
            default: return Array.Empty<Item>();
        }
    }
}




