using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        var heroId = PlayerManager.Instance.HeroDatas[0].Id;
        Weapon weapon = PlayerManager.Instance.GetWeapon();

        HeroObject heroObj= GameApplication.Instance.EntityController.Spawn<Hero, HeroObject>(heroId, Vector3.zero, Quaternion.identity);
        WeaponObject weaponObj = GameApplication.Instance.EntityController.Spawn<Weapon, WeaponObject>(weapon, Vector3.zero, Quaternion.identity, heroObj.WeaponNode);
        heroObj.SetWeapon(weaponObj);

        GameApplication.Instance.EntityController.Spawn<Monster, MonsterObject>(10001, new Vector3(0, 0, 10), Quaternion.identity);
    }
}   