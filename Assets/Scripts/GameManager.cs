using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        var heroId = PlayerManager.Instance.HeroDatas[0].Id;
        Weapon weapon = PlayerManager.Instance.GetWeapon();

        HeroObject heroObj= GameApplication.Instance.EntityController.Spawn<Hero, HeroObject>(heroId, Vector3.zero, Quaternion.identity);
        WeaponObject weaponObj = GameApplication.Instance.EntityController.Spawn<Weapon, WeaponObject>(weapon, Vector3.zero, Quaternion.identity, heroObj.WeaponNode);
        heroObj.StatAbility = PlayerManager.Instance.GetStat(heroId);

        heroObj.SetWeapon(weaponObj);

        MonsterObject monsterObj = GameApplication.Instance.EntityController.Spawn<Monster, MonsterObject>(10001, new Vector3(0, 0, 10), Quaternion.identity);

        Stat stat = GameApplication.Instance.GameModel.PresetData.ReturnData<Stat>(nameof(Stat), monsterObj.Entity.Id);
        monsterObj.StatAbility.AddStatData(StatAbility.StatInfo.StatDataType.Main, stat);
        monsterObj.StatAbility.CurrentSpeed = monsterObj.StatAbility.MaxSpeed;
        monsterObj.StatAbility.CurrentHp = monsterObj.StatAbility.MaxHp;
    }
}   