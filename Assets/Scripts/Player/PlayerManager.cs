using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private List<HeroData> heroDatas;

    [field: SerializeField] public List<Item> EquipedItems { get; private set; } = new List<Item>();

    [field: SerializeField] public List<Item> InvenItems { get; private set; } = new List<Item>();

    public List<HeroData> HeroDatas => heroDatas;

    private static PlayerManager instance;
    public static PlayerManager Instance { get => instance ??= FindObjectOfType<PlayerManager>(); }

    private void Awake()
    {
        heroDatas = new List<HeroData>();

        heroDatas.Add(new HeroData { Id = 30001 });

        EquipedItems.Add(new WeaponData { Id = 40001, ItemType = ItemType.Equipment, RuleType = RuleType.NonStackable});
        EquipedItems.Add(new ProjectileData { Id = 50001, ItemType = ItemType.Equipment, Type = Projectile.ProjectileType.Shuriken, Count = 1, RuleType = RuleType.NonStackable });

        InvenItems.Add(new ProjectileData { Id = 50002, ItemType = ItemType.Equipment, Type = Projectile.ProjectileType.Shuriken, Count = 1, RuleType = RuleType.NonStackable });
    }

    public void EquipItem(Item item)
    {
        if (item.RuleType == RuleType.NonStackable) //장착할 아이템이 중복 불가일 경우
        {
            if (InvenItems.Contains(item))
            {
                InvenItems.Remove(item);
            }

            var equipedItem = EquipedItems.Find(x => x.SlotType == item.SlotType);
            if (equipedItem != null)
            {
                InvenItems.Add(equipedItem);
                EquipedItems.Remove(equipedItem);
            }

            EquipedItems.Add(item);
        }
    }

    public Weapon GetWeapon(int characterId)
    {
        WeaponData weaponData = EquipedItems.Where(x => x is WeaponData).Select(x => x as WeaponData).FirstOrDefault();
        Weapon weapon = new Weapon { Id = weaponData.Id, Type = weaponData.Type };

        return weapon;
    }

    public Projectile GetProjectile(Projectile.ProjectileType type)
    {
        ProjectileData projectileData = EquipedItems.Where(x => x is ProjectileData).Select(x => x as ProjectileData).FirstOrDefault();
        Projectile projectile = new Projectile { Id = projectileData.Id, Type = projectileData.Type };

        return projectile;
    }
}
