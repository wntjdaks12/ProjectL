using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private List<Item> items;

    private void Awake()
    {
        items = new List<Item>();
    }
}
