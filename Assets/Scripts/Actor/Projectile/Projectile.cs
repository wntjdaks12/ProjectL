using System;
using UnityEngine;

[Serializable]
public class Projectile : Actor
{
    public enum ProjectileType
    {
        Shuriken,
        Bullet
    }

    [field: SerializeField] public ProjectileType Type { get; set; }
}
