using UnityEngine;

public class WeaponData : EquipmentItem
{
    [field: SerializeField] public Weapon.WeaponType Type { get; set; }

    public WeaponData()
    {
        SlotType = SlotType.Weapon;
    }
}
