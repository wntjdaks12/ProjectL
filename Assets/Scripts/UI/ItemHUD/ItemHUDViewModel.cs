using System.Collections.Generic;

public class ItemHUDViewModel : ViewModel
{
    private ItemHUDModel model;

    public ItemHUDViewModel(ItemHUDModel model)
    {
        this.model = model;
    }

    public List<Item> GetEquipedItems()
    {
        return model.GetItems();
    }
}
