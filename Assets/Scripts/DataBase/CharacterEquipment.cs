using System;
using UnityEngine;

[Serializable]
public class CharacterEquipment
{
    [field: SerializeField] public int CharacterId { get; set; }
    [field: SerializeField] public int ItemId { get; set; }
}
