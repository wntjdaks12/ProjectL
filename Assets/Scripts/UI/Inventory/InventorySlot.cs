using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private Button slotButton;
    [SerializeField] private Image iconImage;
    [SerializeField] private Image selectedImage;
    [SerializeField] private GameObject equipPanel;

    private int index;
    private Item item;
    private Action<InventorySlot> onClicked;

    public Item Item => item;

    public void Init(int index, Item item, Action<InventorySlot> onClicked, bool isEquiped = false)
    {
        this.index = index;
        this.item = item;
        this.onClicked = onClicked;

        if (slotButton != null)
        {
            slotButton.onClick.RemoveAllListeners();
            slotButton.onClick.AddListener(() =>
            {
                onClicked?.Invoke(this);
            });
        }

        UpdateUI(isEquiped);
    }

    public void UpdateUI(bool isEquiped = false)
    {
        IconInfo iconInfo = GameApplication.Instance.GameModel.PresetData.ReturnData<IconInfo>(nameof(IconInfo), item.Id);

        if (iconImage != null) iconImage.sprite = Resources.Load<Sprite>(iconInfo.Path);
        if (countText != null) countText.text = item.Count.ToString();
        UpdateDeselectedUI();
        UpdateUnequipPanelUI();

        if (isEquiped)
            UpdateEquipPanelUI();
        else
            UpdateUnequipPanelUI();
    }

    public void UpdateEquipPanelUI()
    {
        if (equipPanel == null) return;

        equipPanel.gameObject.SetActive(true);
    }

    public void UpdateUnequipPanelUI()
    {
        if (equipPanel == null) return;

        equipPanel.gameObject.SetActive(false);
    }

    public void UpdateSelectedUI()
    {
        if (selectedImage == null) return;

        selectedImage.gameObject.SetActive(true);
    }

    public void UpdateDeselectedUI()
    {
        if (selectedImage == null) return;

        selectedImage.gameObject.SetActive(false);
    }
}
