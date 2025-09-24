using System;
using UnityEngine;

[Serializable]
public class ProjectileData : EquipmentItem
{
    [field: SerializeField] public Projectile.ProjectileType Type { get; set; }

    public ProjectileData()
    {
        SlotType = SlotType.Projectile;
    }
}
