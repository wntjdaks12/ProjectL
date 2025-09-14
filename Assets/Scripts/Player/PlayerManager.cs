using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private List<ProjectileData> projectileDatas;
    private List<Projectile> projectiles;
    public List<ProjectileData> ProjectileDatas => projectileDatas;
    [SerializeField] private List<HeroData> heroDatas;
    [SerializeField] private List<CharacterEquipment> characterEquipments;
    [SerializeField] private List<Weapon> weapons;

    public List<HeroData> HeroDatas => heroDatas;

    private static PlayerManager instance;
    public static PlayerManager Instance { get => instance ??= FindObjectOfType<PlayerManager>(); }

    private void Awake()
    {
        projectileDatas = new List<ProjectileData>();
        projectiles = new List<Projectile>();
        heroDatas = new List<HeroData>();
        characterEquipments = new List<CharacterEquipment>();
        weapons = new List<Weapon>();

        projectileDatas.Add(new ProjectileData { Id = 50001, Type = Projectile.ProjectileType.Shuriken, Count = 1 });
        projectileDatas.Add(new ProjectileData { Id = 50002, Type = Projectile.ProjectileType.Shuriken, Count = 1 });
        projectiles.Add(new Projectile { Id = 50001, Type = Projectile.ProjectileType.Shuriken });
        projectiles.Add(new Projectile { Id = 50002, Type = Projectile.ProjectileType.Shuriken });

        heroDatas.Add(new HeroData { Id = 30001 });

        characterEquipments.Add(new CharacterEquipment { CharacterId = 30001, ItemId = 40001 });
        weapons.Add(new Weapon { Id = 40001, Type = Weapon.WeaponType.Ranged });
    }

    public Weapon GetWeapon(int characterId)
    {
        CharacterEquipment characterEquipment = characterEquipments.Where(x => x.CharacterId == characterId).FirstOrDefault();

        if (characterEquipment != null)
        {
            Weapon weapon = weapons.Where(x => x.Id == characterEquipment.ItemId).FirstOrDefault();

            if (weapon != null)
            {
                return weapon;
            }
        }

        return null;
    }

    public Projectile GetProjectile(Projectile.ProjectileType type)
    {
        return projectiles.Where(x => x.Type == type).FirstOrDefault();
    }
}
