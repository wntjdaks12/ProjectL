public class InventoryViewModel : ViewModel
{
    private InventoryModel model;

    public InventoryViewModel(InventoryModel model)
    {
        this.model = model;
        this.model.OnInventoryChanged += OnInventoryChanged;
    }

    private void OnInventoryChanged(Item item)
    {
        OnPropertyChanged();
    }

    public void AddItem(Item item)
    {
        model.AddItem(item);
    }

    public void RemoveItem(Item item)
    {
        model.RemoveItem(item);
    }

    public void ConsumeItem(Item item, int count)
    {
        model.ConsumeItem(item, count);

        OnPropertyChanged();
    }

    public bool ConsumeItem(int id, int count)
    {
        if (model.ConsumeItem(id, count))
        {
            OnPropertyChanged();

            return true;
        } 
        else
        {

            return false;
        }

    }

    public void EquipItem(Item item)
    {
        model.EquipItem(item);
    }

    public Item[] GetItems(ItemType itemType)
    {
        return model.GetItems(itemType);
    }

    public Item GetEquiptItem(int id)
    {
        return model.GetEquiptItem(id);
    }

    public bool CheckEquipItem(int id)
    {
        return model.CheckEquipItem(id);
    }
}
