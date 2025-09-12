using System;
using UnityEngine;

[Serializable]
public class Weapon : Actor
{
    public enum WeaponType
    {
        Melee,
        Ranged
    }

    [field: SerializeField] public WeaponType Type { get; set; }
}
