using System;
using System.Collections.Generic;

public class ItemHUDModel
{
    private List<Item> equipedItems = new List<Item>();


    public void AddItem(List<Item> items)
    {
        equipedItems = items;
    }

    public List<Item> GetItems()
    {
        return equipedItems;
    }

}
