using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryTabbar : MonoBehaviour
{
    public ItemType CurrentItemType { get; private set; }

    public event Action<ItemType> OnClick;

    [SerializeField] private Button equipButton;
    [SerializeField] private Button consButton;
    [SerializeField] private Button miscButton;

    public void Awake()
    {
        equipButton?.onClick.AddListener(() =>
        {
            CurrentItemType = ItemType.Equipment;

            OnClick?.Invoke(CurrentItemType);
        });

        consButton?.onClick.AddListener(() =>
        {
            CurrentItemType = ItemType.Consumable;

            OnClick?.Invoke(CurrentItemType);
        });

        miscButton?.onClick.AddListener(() =>
        {
            CurrentItemType = ItemType.Misc;

            OnClick?.Invoke(CurrentItemType);
        });
    }
}
