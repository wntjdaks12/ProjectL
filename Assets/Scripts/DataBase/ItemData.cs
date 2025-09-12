using System;
using UnityEngine;

[Serializable]
public class ItemData
{
    [field: SerializeField] public int Id { get; set; }
    [field: SerializeField] public int ItemType { get; set; }
}
