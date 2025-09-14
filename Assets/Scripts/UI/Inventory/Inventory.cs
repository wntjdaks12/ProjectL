using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventoryTabbar inventoryTabbar;
    [SerializeField] private InventorySlot inventorySlot;

    [SerializeField] private GameObject view;
    [SerializeField] private Transform slotParent;

    private InventoryViewModel viewModel;

    public InventoryViewModel InventoryViewModel => viewModel;

    private InventorySlot selectedInvenSlot;

    private void Start()
    {
        InventoryModel model = new InventoryModel();
        model.AddItem(PlayerManager.Instance.ProjectileDatas);

        // 나중에 수정
        viewModel = new InventoryViewModel(model);
        Bind(viewModel);

        inventoryTabbar.OnClick += UpdateUI;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (view.activeSelf)
                Hide();
            else
                Show();
        }
    }

    public void Bind(InventoryViewModel viewModel)
    {
        this.viewModel = viewModel;

        viewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    public void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "AddItem")
        {
            UpdateUI(inventoryTabbar.CurrentItemType);
        }
        else if (e.PropertyName == "OnInventoryChanged")
        {
            UpdateUI(inventoryTabbar.CurrentItemType);
        }
        else if (e.PropertyName == "ConsumeItem")
        {
            UpdateUI(inventoryTabbar.CurrentItemType);
        }
    }

    public void Show()
    {
        view.SetActive(true);

        OnShow();

        Cursor.lockState = CursorLockMode.None; // 마우스를 중앙에 고정
        Cursor.visible = true; // 커서 숨김
    }

    private void OnShow()
    {
        UpdateUI(inventoryTabbar.CurrentItemType);
    }

    public void Hide()
    {
        view.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked; // 마우스를 중앙에 고정
        Cursor.visible = false; // 커서 숨김
    }

    public void UpdateUI(ItemType itemType)
    {
        // 슬롯 풀링 구현 시 삭제
        // 임시로 DestroyImmediate 사용
        if (slotParent.childCount > 0)
        {
            for (int i = slotParent.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(slotParent.GetChild(i).gameObject);
            }
        }

        Item[] items = viewModel.GetItems(itemType);
        for (int i = 0; i < items.Length; i++)
        { 
            InventorySlot slot = Instantiate(inventorySlot, slotParent);
            slot.Init(i, items[i], (x) =>
            {
                selectedInvenSlot.UpdateDeselectedUI();
                selectedInvenSlot = x;
                selectedInvenSlot.UpdateSelectedUI();
            },
            viewModel.CheckEquipItem(items[i].Id)
            ); ;

            if (items.Length > 0)
            {
                selectedInvenSlot = slot;
                selectedInvenSlot.UpdateSelectedUI();
            }
        }
    }
}
