using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        var heroId = PlayerManager.Instance.HeroDatas[0].Id;
        Weapon weapon = PlayerManager.Instance.GetWeapon(heroId);

        HeroObject heroObj= GameApplication.Instance.EntityController.Spawn<Hero, HeroObject>(heroId, Vector3.zero, Quaternion.identity);
        WeaponObject weaponObj = GameApplication.Instance.EntityController.Spawn<Weapon, WeaponObject>(weapon, Vector3.zero, Quaternion.identity, heroObj.WeaponNode);
        heroObj.SetWeapon(weaponObj);
    }
}   