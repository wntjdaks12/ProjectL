using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ItemHUD : MonoBehaviour
{
    [SerializeField] private GameObject view;

    [SerializeField] private Image[] itemImage = new Image[0];

    private ItemHUDViewModel viewModel;

    private void Start()
    {
        ItemHUDModel model = new ItemHUDModel();
        model.AddItem(PlayerManager.Instance.EquipedItems);
        ItemHUDViewModel viewModel = new ItemHUDViewModel(model);

        Bind(viewModel);

        Show();
    }

    public void Bind(ItemHUDViewModel viewModel)
    {
        this.viewModel = viewModel;
        viewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    public void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
    }

    public void Show()
    {
        view.SetActive(true);

        OnShow();
    }

    private void OnShow()
    {
        UpdateUI();
    }

    public void Hide()
    {
        view.SetActive(false);
    }

    public void UpdateUI()
    {
        var equipedItems = viewModel.GetEquipedItems();

        var index = 0;
        foreach (var item in equipedItems)
        {
            if (itemImage.Length > index)
            {
                IconInfo iconInfo = GameApplication.Instance.GameModel.PresetData.ReturnData<IconInfo>(nameof(IconInfo), item.Id);

                itemImage[index].sprite = Resources.Load<Sprite>(iconInfo.Path);

                index++;
            }
        }
    }
}
