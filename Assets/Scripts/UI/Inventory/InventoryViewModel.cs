public class InventoryViewModel : ViewModel
{
    private InventoryModel model;

    public InventoryViewModel(InventoryModel model)
    {
        this.model = model;
    }

    public void EquipItem(Item item)
    {
        PlayerManager.Instance.EquipItem(item);
    }

    public Item[] GetItems(ItemType itemType)
    {
        return model.GetItems(itemType);
    }
}
