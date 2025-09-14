using System;
using UnityEngine;

[Serializable]
public class ProjectileData : ConsumableItem
{
    [field: SerializeField] public Projectile.ProjectileType Type { get; set; }
}
